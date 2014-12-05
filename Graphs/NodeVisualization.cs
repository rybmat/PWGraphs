﻿using System;
using Gtk;
using Cairo;
using GraphProject;

namespace Graphs {

	public class NodeVisualization : Gtk.DrawingArea {
		private string caption = "";
		private Gtk.Menu popup = null;

		private int width = 0;
		private int height;

		public object graph;
		public MovablePanel mvpanel;

		public int X{ get; set; }
		public int Y{ get; set; }

		private object node;
		public object Node { get { return node; } }

		private Type nodeType;
		public Type NodeType { get { return nodeType; } }

		public NodeVisualization(Type _nodeType, object _node) {
			node = _node;
			nodeType = _nodeType;

			popup = new Gtk.Menu();

			Gtk.MenuItem rm = new MenuItem("Remove");
			rm.Activated += new EventHandler(OnRemove);
			popup.Add(rm);

			Gtk.MenuItem connect = new MenuItem("Connect To");
			connect.Activated += new EventHandler(OnConnect);
			popup.Add(connect);

			Gtk.MenuItem disconnect = new MenuItem("Remove Connection To");
			disconnect.Activated += new EventHandler(OnDisconnect);
			popup.Add(disconnect);

			caption = _node.ToString();
			Name = _node.ToString();

			width = caption.Length * 8 + 10;
			height = 40;
			SetSizeRequest(width, height);
		}

		public override string ToString () {
			return node.ToString();
		}

		public void ShowMenu() {
			popup.Popup();
			popup.ShowAll();
		}

		public void ShowDetails() {
			NodeDialog addDialog = new NodeDialog (nodeType.GenericTypeArguments[0], node.GetType().GetProperty("Data").GetValue(node), false);
			addDialog.Run ();
			addDialog.Destroy ();
			QueueDraw();
		}

		public void Redraw() {
			Console.WriteLine("Redrawing");
			QueueDraw();
		}

		public void AddSuccessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("AddSuccessor").Invoke (node, args);
		}

		public void RemoveSuccesor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("RemoveSuccesor").Invoke (node, args);
		}

		public void AddPredecessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("AddPredecessor").Invoke (node, args);
		}

		public void RemovePredecessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("RemovePredecessor").Invoke (node, args);
		}

		protected void OnRemove(object sender, EventArgs args) {
			object[] margs = {Node};

			graph.GetType().GetMethod("RemoveNode").Invoke(graph, margs);
			Console.WriteLine ("NodeVisualization.RemoveNode");
			Console.WriteLine (graph.ToString ());
			Destroy ();
			QueueDraw();
		}

		protected void OnConnect(object sender, EventArgs args) {
			mvpanel.StartConnection (this);
		}

		protected void OnDisconnect(object sender, EventArgs args) {
			mvpanel.StertRemoveConnection (this);
		}

		protected override bool OnExposeEvent (Gdk.EventExpose args) {
			using (Context g = Gdk.CairoHelper.Create (args.Window)) {
				DrawCurvedRectangle (g);
				g.SetSourceColor(new Color (0.1, 0.6, 1, 1));
				g.FillPreserve ();
				g.SetSourceColor(new Color (0.2, 0.8, 1, 1));
				g.LineWidth = 5;
				g.Stroke ();

				SetupFont (g);
				FontExtents fe = g.FontExtents;
				TextExtents te = g.TextExtents(caption);
				double x = width/2 + te.XBearing - te.Width / 2;
				double y = height/2 + fe.Descent + fe.Height / 2;

				g.MoveTo(x, y);
				g.SetSourceColor(new Color(0, 0, 0));
				g.ShowText(caption);
			}
			return true;
		}

		private void DrawCurvedRectangle (Cairo.Context gr) {	
			double x = 0, y = 0;
			gr.Save ();
			gr.MoveTo (x, y + height / 2);
			gr.CurveTo (x, y, x, y, x + width / 2, y);
			gr.CurveTo (x + width, y, x + width, y, x + width, y + height / 2);
			gr.CurveTo (x + width, y + height, x + width, y + height, x + width / 2, y + height);
			gr.CurveTo (x, y + height, x, y + height, x, y + height / 2);
			gr.Restore ();
		}

		private void SetupFont (Cairo.Context g) {
			g.SetSourceColor(new Color(0, 0, 0));
			g.SelectFontFace("Georgia", FontSlant.Normal, FontWeight.Bold);
			g.SetFontSize(10);

			double ux = 1, uy = 1;
			g.DeviceToUserDistance(ref ux, ref uy);
			double px = Math.Max(ux, uy);
			g.LineWidth = 4 * px;
		}
	}
}


