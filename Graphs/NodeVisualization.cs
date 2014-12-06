using System;
using System.Collections.Generic;
using Gtk;
using Cairo;
using GraphProject;

namespace Graphs {

	public class NodeVisualization : Gtk.DrawingArea {
		private string caption = "";
		private Gtk.Menu popup = null;
		private string orderNum = "";

		private int width = 0;
		private int height;

		public int Width{ get { return width; } }
		public int Height{ get { return height; } }

		public object graph;
		public MovablePanel mvpanel;

		public int X{ get; set; }
		public int Y{ get; set; }

		private object node;
		public object Node { get { return node; } }

		public Dictionary<NodeVisualization, bool> successors = new Dictionary<NodeVisualization, bool>();
		public Dictionary<NodeVisualization, bool> predecessors = new Dictionary<NodeVisualization, bool> ();

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
			Redraw();
		}

		public void Redraw() {
			Console.WriteLine("Redrawing");
			QueueDraw();
		}

		public void AddSuccessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("AddSuccessor").Invoke (node, args);
			successors[nv] = false;
			nv.predecessors[this] = false;
		}

		public void RemoveSuccesor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("RemoveSuccesor").Invoke (node, args);
			successors.Remove (nv);
			nv.predecessors.Remove (this);
		}

		public void AddPredecessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("AddPredecessor").Invoke (node, args);
			nv.successors [this] = false;
			predecessors[nv] = false;
		}

		public void RemovePredecessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			node.GetType ().GetMethod ("RemovePredecessor").Invoke (node, args);
			nv.successors.Remove (this);
			predecessors.Remove (nv);
		}

		public void ResetEdgesState() {
			List<NodeVisualization> succs = new List<NodeVisualization>(successors.Keys);
			foreach (var node in succs) {
				successors[node] = false;
				node.predecessors [this] = false;
			}
			List<NodeVisualization> preds = new List<NodeVisualization>(predecessors.Keys);
			foreach (var node in preds) {
				predecessors[node] = false;
				node.successors [this] = false;
			}
		}

		public void SetOutEdgeState(NodeVisualization succ, bool visited) {
			if (successors.ContainsKey(succ)) {
				successors [succ] = visited;
				succ.predecessors [this] = visited;
			}
		}

		public void SetInEdgeState(NodeVisualization pred, bool visited) {
			if (predecessors.ContainsKey (pred)) {
				predecessors [pred] = visited;
				pred.successors [this] = visited;
			}
		}

		public void SetOutEdgeState(object succ, bool visited) {
			List<NodeVisualization> succs = new List<NodeVisualization>(successors.Keys);
			foreach (var n in succs) {
				if (n.Node == succ) {
					Console.WriteLine ("seting out edge state in NodeVis");
					successors[n] = visited;
					n.predecessors [this] = visited;
				}
			}
		}

		public void SetInEdgeState(object pred, bool visited) {
			List<NodeVisualization> preds = new List<NodeVisualization>(predecessors.Keys);
			foreach (var n in preds) {
				if (n.Node == pred) {
					Console.WriteLine ("seting in edge state in NodeVis");
					predecessors[n] = visited;
					n.successors [this] = visited;
				}
			}
		}

		public void SetOrderNum(int num) {
			orderNum = num.ToString ();
			caption = orderNum + ": " + caption;
		}

		public void ClearOrderNum() {
			orderNum = "";
			caption = Name;
		}

		protected void OnRemove(object sender, EventArgs args) {
			object[] margs = {Node};
			graph.GetType().GetMethod("RemoveNode").Invoke(graph, margs);
			foreach (var p in predecessors.Keys) {
				p.successors.Remove (this);
			}
			foreach (var s in successors.Keys) {
				s.successors.Remove (this);
			}
			mvpanel.Graph.RemoveNode (this);

			Console.WriteLine ("NodeVisualization.RemoveNode");
			Console.WriteLine (graph.ToString ());
			Destroy ();
			mvpanel.RefreshChildren ();
			mvpanel.Dispose ();
		}

		protected void OnConnect(object sender, EventArgs args) {
			mvpanel.StartConnection (this);
		}

		protected void OnDisconnect(object sender, EventArgs args) {
			mvpanel.StartRemoveConnection (this);
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
