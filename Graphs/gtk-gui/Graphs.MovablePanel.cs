
// This file has been generated by the GUI designer. Do not modify.
namespace Graphs
{
	public partial class MovablePanel
	{
		private global::Gtk.Fixed fixed1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Graphs.MovablePanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Graphs.MovablePanel";
			// Container child Graphs.MovablePanel.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.Add (this.fixed1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.fixed1.MotionNotifyEvent += new global::Gtk.MotionNotifyEventHandler (this.OnFixed1MotionNotifyEvent);
		}
	}
}
