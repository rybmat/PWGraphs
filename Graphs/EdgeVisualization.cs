using System;
using Gtk;
using Cairo;

namespace Graphs {
	[System.ComponentModel.ToolboxItem (true)]
	public class EdgeVisualization : Gtk.DrawingArea {
		private NodeVisualization nodeFrom;
		private NodeVisualization nodeTo;
		private Point begin;
		private Point end;

		private int x, y, width, height;
		public int X { get{ return x; }}
		public int Y { get{ return y; }}
		public int Width { get{ return width; }}
		public int Height { get{ return height; }}

		public EdgeVisualization (NodeVisualization _nodeFrom, NodeVisualization _nodeTo) {
			nodeFrom = _nodeFrom;
			nodeTo = _nodeTo;
		}

		//public void Redraw() {
		//	QueueDraw();
		//}

		protected override bool OnExposeEvent (Gdk.EventExpose ev) {
			base.OnExposeEvent (ev);

			calculateCoordinates ();
			(Parent as Fixed).Move (this, x, y);

			using (Context gr = Gdk.CairoHelper.Create (ev.Window)) {
				gr.Antialias = Antialias.Gray;
				gr.LineWidth = 8;
				gr.SetSourceColor(new Color (1, 0, 0, 1));
				gr.LineCap = LineCap.Round;
				gr.MoveTo (begin.X, begin.Y);
				gr.LineTo (end.X, end.Y);
				gr.Stroke ();
			}

			return true;
		}

		private void calculateCoordinates() {
			x = Math.Min (nodeFrom.X, nodeTo.X);
			y = Math.Min (nodeFrom.Y, nodeTo.Y);
			width = Math.Abs (nodeTo.X - nodeFrom.X);
			height = Math.Abs (nodeTo.Y - nodeFrom.Y);
			SetSizeRequest(width, height);

			if (nodeFrom.X > nodeTo.X && nodeFrom.Y > nodeTo.Y) {
				begin.X = width;
				begin.Y = height;
				end.X = 0;
				end.Y = 0;
			} else if (nodeFrom.X > nodeTo.X && nodeFrom.Y <= nodeTo.Y) {
				begin.X = width;
				begin.Y = 0;
				end.X = 0;
				end.Y = height;
			} else if (nodeFrom.X <= nodeTo.X && nodeFrom.Y > nodeTo.Y) {
				begin.X = 0;
				begin.Y = height;
				end.X = width;
				end.Y = 0;
			} else if (nodeFrom.X <= nodeTo.X && nodeFrom.Y <= nodeTo.Y) {
				begin.X = 0;
				begin.Y = 0;
				end.X = width;
				end.Y = height;
			}
		}
	}
}

