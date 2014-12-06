﻿using System;
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
			int beginX = _from.X + _from.Width / 2;
			int beginY = _from.Y + _from.Height / 2;
			int endX = _to.X + _to.Width / 2;
			int endY = _to.Y + _to.Height / 2;

			cx.Antialias = Antialias.Gray;
			cx.LineWidth = 3;
			cx.SetSourceColor(new Color (0, 0, 0, 1));
			cx.LineCap = LineCap.Round;
			cx.MoveTo (beginX, beginY);
			cx.LineTo (endX, endY);
			cx.Stroke ();

			int tipX = (endX + beginX) / 2;
			int tipY = (endY + beginY) / 2;

			int arrowLength = 10; //can be adjusted
			int dx = endX - beginX;
			int dy = endY - beginY;

			double theta = Math.Atan2(dy, dx);

			double rad = 35*Math.PI/180; //35 angle, can be adjusted
			double x = tipX - arrowLength * Math.Cos(theta + rad);
			double y = tipY - arrowLength * Math.Sin(theta + rad);

			double phi2 = -35*Math.PI/180;//-35 angle, can be adjusted
			double x2 = tipX - arrowLength * Math.Cos(theta + phi2);
			double y2 = tipY - arrowLength * Math.Sin(theta + phi2);

			cx.MoveTo (tipX, tipY);
			cx.LineTo (x, y);
			cx.Stroke ();

			cx.MoveTo (tipX, tipY);
			cx.LineTo (x2, y2);
			cx.Stroke ();
		}
	}
}

