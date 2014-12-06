﻿using System;
using Gtk;
using Cairo;
using System.Collections.Generic;

namespace Graphs {

	[System.ComponentModel.ToolboxItem (true)]
	public class GraphVisualization : Gtk.DrawingArea {
		private Dictionary<NodeVisualization, bool> nodes = new Dictionary<NodeVisualization, bool>();

		public object graph;

		public GraphVisualization (int width, int height) {
			Console.WriteLine ("EdgeVis: " + width + " " + height);
			SetSizeRequest (width, height);
		}

		public void AddNode(NodeVisualization node) {
			nodes[node] = false;
		}

		public void RemoveNode(NodeVisualization node) {
			nodes.Remove (node);
		}

		public void RemoveAllNodes() {
			nodes.Clear ();
		}

		public void ResetEdgesState() {
			foreach (var n in nodes.Keys) {
				n.ResetEdgesState ();
			}
		}

		public void ResetNodesState() {
			List<NodeVisualization> nds = new List<NodeVisualization> (nodes.Keys);
			foreach (var n in nds) {
				nodes [n] = false;
			}
		}

		public void SetNodeState(object node, bool visited) {
			List<NodeVisualization> nds = new List<NodeVisualization> (nodes.Keys);
			foreach (NodeVisualization n in nds) {
				if (n.Node == node) {
					Console.WriteLine ("seting node state in GraphVis");
					nodes [n] = visited;
				}
			}
		}

		public void SetEdgeState(object _from, object _to, bool visited) {
			List<NodeVisualization> nds = new List<NodeVisualization> (nodes.Keys);
			NodeVisualization f, t; 
			foreach (NodeVisualization n in nds) {
				if (n.Node == _from) {
					Console.WriteLine ("seting edge state in GraphVis");
					n.SetOutEdgeState (_to, visited);
				}
			}
		}

		protected override bool OnExposeEvent(Gdk.EventExpose ev) {
			base.OnExposeEvent(ev);

			Cairo.Context cr = Gdk.CairoHelper.Create(GdkWindow);

			foreach (NodeVisualization source in nodes.Keys) {
				foreach (NodeVisualization destination in source.successors.Keys) {
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
			if ( !_from.successors.ContainsKey(_to) || _from.successors[_to] == false)
				cx.SetSourceColor(new Color (0, 0, 0, 1));
			else
				cx.SetSourceColor(new Color (1, 0, 0, 1));
				
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

			double rad = 35*Math.PI/180; //35 angle
			double x = tipX - arrowLength * Math.Cos(theta + rad);
			double y = tipY - arrowLength * Math.Sin(theta + rad);

			double phi2 = -35*Math.PI/180;//-35 angle
			double x2 = tipX - arrowLength * Math.Cos(theta + phi2);
			double y2 = tipY - arrowLength * Math.Sin(theta + phi2);

			cx.MoveTo (tipX, tipY);
			cx.LineTo (x, y);
			cx.Stroke ();

			cx.MoveTo (tipX, tipY);
			cx.LineTo (x2, y2);
			cx.Stroke ();
		}

		public IEnumerable<object> Run(string name, object start) {
			if (start == null) {
				return (IEnumerable<object>)graph.GetType().GetMethod(name).Invoke(graph, null);
			} else {
				try {
					return (IEnumerable<object>)graph.GetType().GetMethod(name).Invoke(graph, new [] { start });

				} catch (System.Reflection.TargetParameterCountException) {
					return Run(name, null);
				}
			}
		}
	}
}
