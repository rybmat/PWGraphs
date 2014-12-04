using System;
using Gtk;
using Graphs;

namespace Graphs {

	[System.ComponentModel.ToolboxItem (true)]
	public partial class MovablePanel : Gtk.Bin {
		private Widget currCtrl = null;
		private Widget currClone = null;

		private int origX = 0;
		private int origY = 0;
		private int pointX = 0;
		private int pointY = 0;

		private bool isDragged = false;

		private string rightClick;
		private string doubleClick;

		public MovablePanel(string _rightClick, string _doubleClick) {		
			rightClick = _rightClick;
			doubleClick = _doubleClick;
			Build();
		}

		//Set the controls to be redrawn
		public void RefreshChildren() {
			fixed1.QueueDraw();
		}

		public void RemoveAllChildren() {
			foreach (Widget ch in fixed1.AllChildren) {
				ch.Destroy ();
			}
			RefreshChildren ();
		}
			
		public void AddNode(Widget wdg, int x, int y) {
			if (x<0) {
				x = 0;
			}
			if (y<0) {
				y = 0;
			}
				
			(wdg as NodeVisualization).X = x;
			(wdg as NodeVisualization).Y = y;

			EventBox ev = GetMovingBox(wdg);
			ev.ButtonPressEvent += new ButtonPressEventHandler(OnButtonPressed);
			ev.ButtonReleaseEvent += new ButtonReleaseEventHandler(OnButtonReleased);

			//Add to the panel
			fixed1.Put(ev, x, y);
			ShowAll();
		}
			
		private EventBox GetMovingBox(Widget wdg) { 
			EventBox rev = new EventBox();
			rev.Name = wdg.ToString();
			rev.Add(wdg);

			Console.WriteLine("Creating new moving object"+rev.Name);
			return rev;
		}
			
		private Widget CloneCurrCtrl() {
			Widget re = null;

			if (currCtrl != null) {
				if (currCtrl is EventBox) {
					Widget wdg = (currCtrl as EventBox).Child;
					(currCtrl as EventBox).Remove (wdg);
					re = GetMovingBox(wdg);
				}
			}
			return re;
		}
			
		private void MoveClone(ref Widget wdg, object eventX, object eventY) {
			if (wdg == null) {
				wdg = CloneCurrCtrl();
				fixed1.Add(wdg);		
				ShowAll();
			}
			MoveControl(wdg, eventX, eventY, true);
		}
			
		private void MoveControl(Widget wdg, object eventX, object eventY, bool isClone) {
			int destX = origX+System.Convert.ToInt32(eventX)+origX-pointX;
			int destY = origY+System.Convert.ToInt32(eventY)+origY-pointY;
			if (destX<0) {
				destX = 0;
			}
			if (destY<0) {
				destY = 0;
			}		

			fixed1.Move(wdg, destX, destY);
			if (!isClone) {
				Console.WriteLine("MovingBox KeyReleased:"+destX.ToString()+"-"+destY.ToString());
				((wdg as EventBox).Child as NodeVisualization).X = destX;
				((wdg as EventBox).Child as NodeVisualization).Y = destY;

			}
			fixed1.QueueDraw();	
		}

		//Mouse click on the controls of the panel  
		protected void OnButtonPressed(object sender, ButtonPressEventArgs a) {		
			//Right click
			if (a.Event.Button == 3) {
				if (sender is EventBox) {
					(sender as EventBox).Child.GetType().GetMethod(rightClick).Invoke((sender as EventBox).Child, null);
				}	
			}
			//Left click
			else if (a.Event.Button == 1) {
				//Double-click
				if (a.Event.Type == Gdk.EventType.TwoButtonPress) {
					if (sender is EventBox) {
						(sender as EventBox).Child.GetType().GetMethod(doubleClick).Invoke((sender as EventBox).Child, null);
					}	
				}
				else {
					//Setup the origin of the move
					isDragged = true;
					currCtrl = sender as Widget;
					currCtrl.TranslateCoordinates(fixed1, 0, 0, out origX, out origY);
					fixed1.GetPointer(out pointX, out pointY);
					Console.WriteLine("MovingBox KeyPressed");
					Console.WriteLine("Pointer:" + pointX.ToString() + "-" + pointY.ToString());
					Console.WriteLine("Origin:" + origX.ToString() + "-" + origY.ToString());
				}
			}
		}

		protected void OnButtonReleased(object sender, ButtonReleaseEventArgs a) {
			//Final destination of the control
			if (a.Event.Button == 1) {
				if (currClone!=null) {
					Widget wdg = (currClone as EventBox).Child;
					(currClone as EventBox).Remove (wdg);
					(currCtrl as EventBox).Add (wdg);

					fixed1.Remove(currClone);
					Console.WriteLine("Deleting moving object" + currClone.Name);
					currClone.Destroy();
					currClone = null;
				}
				MoveControl(currCtrl, a.Event.X, a.Event.Y, false);
				isDragged = false;
				currCtrl = null;
			}
		}

		protected virtual void OnFixed1MotionNotifyEvent (object o, Gtk.MotionNotifyEventArgs args) {
			if (isDragged) {
				//Render of a clone at the desired location
				if (currCtrl!=null) {
					MoveClone(ref currClone, args.Event.X,args.Event.Y);
				}
			}
		}
	}	
}