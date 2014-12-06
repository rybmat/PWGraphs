﻿using System;
using Gtk;
using Graphs;
using Cairo;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Graphs {

	[System.ComponentModel.ToolboxItem (true)]
	public partial class MovablePanel : Gtk.Bin {
		private Widget currCtrl = null;
		private Widget currClone = null;

		private int origX = 0;
		private int origY = 0;
		private int pointX = 0;
		private int pointY = 0;

		private bool algStartNode = false;
		private bool isDragged = false;
		private bool makeConnection = false;
		private bool removeConnection = false;

		private Dictionary<string, Func<object, IEnumerable<object>>> Algorithms = new Dictionary<string, Func<object, IEnumerable<object>>>();
		private List<object>AlgorithmResult = new List<object>();

		private object predecessor;
		public GraphVisualization Graph;

		private string rightClick;
		private string doubleClick;
		private string algName;

		public MovablePanel(string _rightClick, string _doubleClick) {		
			rightClick = _rightClick;
			doubleClick = _doubleClick;

			Build();
			Graph = new GraphVisualization (800, 600);
			fixed1.Put (Graph, 0, 0);
			ShowAll ();

			Algorithms.Add("Depth-first Search", start => Graph.Run("DFS", start));
			Algorithms.Add("Breath-first Search", start => Graph.Run("BFS", start));
			Algorithms.Add("Eulerian Path", start => Graph.Run("EulerianDirectedPath", start).Reverse());
			Algorithms.Add("Topological Sort", start => Graph.Run("SortTopologically", start));
		}

		//Set the controls to be redrawn
		public void RefreshChildren() {
			fixed1.QueueDraw();
		}

		public void RemoveAllChildren() {
			Graph.graph.GetType().GetMethod("Clear").Invoke(Graph.graph, null);
			Graph.RemoveAllNodes ();
			foreach (Widget ch in fixed1.AllChildren) {
				if (ch.GetType() == typeof(EventBox))
					ch.Destroy ();
			}
			RefreshChildren ();
			Console.WriteLine ("MovablePanel.RemoveAllChildren");
			Console.WriteLine (Graph.graph.ToString ());
		}

		public void StartConnection(NodeVisualization nv) {
			makeConnection = true;
			predecessor = nv;
		}

		public void StartRemoveConnection(NodeVisualization nv) {
			removeConnection = true;
			predecessor = nv;
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
			(wdg as NodeVisualization).graph = Graph.graph;
			(wdg as NodeVisualization).mvpanel = this;

			object[] args = {(wdg as NodeVisualization).Node};
			Graph.graph.GetType().GetMethod("AddNode").Invoke(Graph.graph, args);
			Graph.AddNode (wdg as NodeVisualization);

			EventBox ev = GetMovingBox(wdg);
			ev.ButtonPressEvent += new ButtonPressEventHandler(OnButtonPressed);
			ev.ButtonReleaseEvent += new ButtonReleaseEventHandler(OnButtonReleased);

			//Add to the panel
			fixed1.Put(ev, x, y);
			ShowAll();

			Console.WriteLine ("MovablePanel.addNode");
			Console.WriteLine (Graph.graph.ToString ());
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
			RefreshChildren ();
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
					if (makeConnection) {
						if (sender is EventBox) {
							object[] args = { predecessor };
							(sender as EventBox).Child.GetType ().GetMethod ("AddPredecessor").Invoke ((sender as EventBox).Child, args);
							Console.WriteLine (Graph.graph.ToString ());
						}
					} else if (removeConnection) {
						if (sender is EventBox) {
							object[] args = { predecessor };
							(sender as EventBox).Child.GetType ().GetMethod ("RemovePredecessor").Invoke ((sender as EventBox).Child, args);
							Console.WriteLine (Graph.graph.ToString ());
						}
					} else if (algStartNode) {
						if (sender is EventBox) {						
							RunAlgorithm (algName, ((sender as EventBox).Child as NodeVisualization).Node);
							Console.WriteLine ("Run with start node");
						}
					} else {
						//Setup the origin of the move
						isDragged = true;
						currCtrl = sender as Widget;
						currCtrl.TranslateCoordinates (fixed1, 0, 0, out origX, out origY);
						fixed1.GetPointer (out pointX, out pointY);
						Console.WriteLine ("MovingBox KeyPressed");
						Console.WriteLine ("Pointer:" + pointX.ToString () + "-" + pointY.ToString ());
						Console.WriteLine ("Origin:" + origX.ToString () + "-" + origY.ToString ());
					}
				}
			}
		}

		protected void OnButtonReleased(object sender, ButtonReleaseEventArgs a) {
			//Final destination of the control
			if (a.Event.Button == 1) {
				if (makeConnection || removeConnection) {
					makeConnection = false;
					removeConnection = false;
					predecessor = null;
					RefreshChildren ();
					return;
				}
				if (algStartNode) {
					algStartNode = false;
					return;
				}
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

		public void Run(string name, bool startNode) {
			if (startNode) {
				algStartNode = startNode;
				algName = name;
			}
			else
				RunAlgorithm (name, null);
		}

		public void RunAlgorithm(string name, object start) {
			Graph.ResetEdgesState();
			Graph.ResetNodesState();

			AlgorithmResult = Algorithms[name].Invoke(start).ToList();
			foreach( var a in AlgorithmResult)
				Console.WriteLine (a);

			object previous = null;
			bool edges_exist = true;
			foreach (var node in AlgorithmResult) {
				Graph.SetNodeState(node, true);
				CurrentAlgorithmPosition = node;

				if (previous != null && edges_exist) {
					try {
						Graph.SetEdgeState(previous, node, true);
					} catch {
						edges_exist = false;
					}
				}

				previous = node;
				RefreshChildren ();
			}

			if (!edges_exist)
				Graph.ResetEdgesState();
		}

		public void PreviousAlgorithmStep() {
			object previous = null;
			foreach (object node in AlgorithmResult.Reverse<object>()) {
				if (previous == CurrentAlgorithmPosition) {
					Graph.SetNodeState(CurrentAlgorithmPosition, false);

					try {
						Graph.SetEdgeState(node, CurrentAlgorithmPosition, false);
					} catch {

					}

					CurrentAlgorithmPosition = node;
					break;
				}

				previous = node;
			}
		}

		public void NextAlgorithmStep() {
			object previous = null;
			foreach (object node in AlgorithmResult) {
				if (previous == CurrentAlgorithmPosition) {
					Graph.SetNodeState(node, true);

					try {
						Graph.SetEdgeState(CurrentAlgorithmPosition, node, true);
					} catch {

					}

					CurrentAlgorithmPosition = node;
					break;
				}

				previous = node;
			}
		}
		public object CurrentAlgorithmPosition {
			get;
			private set;
		}
	}	
}