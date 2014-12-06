using System;
using Gtk;
using Cairo;
using System.Collections.Generic;

namespace Graphs {
	[System.ComponentModel.ToolboxItem (true)]
	public class EdgeVisualization : Gtk.DrawingArea {
		public List<NodeVisualization> nodes = new List<NodeVisualization>();

		public EdgeVisualization (int width, int height) {
			Console.WriteLine ("EdgeVis: " + width + " " + height);
			SetSizeRequest (width, height);
		}
			
		protected override bool OnExposeEvent(Gdk.EventExpose ev) {
			base.OnExposeEvent(ev);

			Cairo.Context cr = Gdk.CairoHelper.Create(GdkWindow);

			foreach (NodeVisualization source in nodes) {
				foreach (NodeVisualization destination in source.successors) {
					DrawEdge(cr, source, destination);
				}
			}
			cr.Dispose();

			return true;
		}
			

		private void DrawEdge(Cairo.Context cx, NodeVisualization _from, NodeVisualization _to) {
			cx.Antialias = Antialias.Gray;
			cx.LineWidth = 3;
			cx.SetSourceColor(new Color (0, 0, 0, 1));
			cx.LineCap = LineCap.Round;
			cx.MoveTo (_from.X + _from.Width/2, _from.Y + _from.Height/2);
			cx.LineTo (_to.X + _to.Width/2, _to.Y + _to.Height/2);
			cx.Stroke ();
		}
	}
}

