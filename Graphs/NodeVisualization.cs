using System;
using System.Collections.Generic;
using Gtk;
using Cairo;
using GraphProject;

namespace Graphs {

	public class NodeVisualization : Gtk.DrawingArea {
		private string caption = "";
		private Gtk.Menu popup = null;

		public int Width{ get; private set; }
		public int Height{ get; private set; }
			
		public MovablePanel mvpanel;

		public int X{ get; set; }
		public int Y{ get; set; }

		public object Node { get; private set; }

		private int visitCount;
		public bool Visited { get; private set; }

		public Dictionary<NodeVisualization, bool> successors = new Dictionary<NodeVisualization, bool>();
		public Dictionary<NodeVisualization, bool> predecessors = new Dictionary<NodeVisualization, bool> ();

		public NodeVisualization(object _node) {
			Node = _node;
			Visited = false;
			visitCount = 0;

			popup = new Gtk.Menu();

			Gtk.MenuItem connect = new MenuItem("Connect To");
			connect.Activated += new EventHandler(OnConnect);
			popup.Add(connect);

			Gtk.MenuItem disconnect = new MenuItem("Remove Connection To");
			disconnect.Activated += new EventHandler(OnDisconnect);
			popup.Add(disconnect);

			popup.Add (new Gtk.MenuItem ());

			Gtk.MenuItem rm = new MenuItem("Remove");
			rm.Activated += new EventHandler(OnRemove);
			popup.Add(rm);

			caption = _node.ToString();
			Name = _node.ToString();

			Width = caption.Length * 8 + 50;
			Height = 40;
			SetSizeRequest(Width, Height);
		}

		public override string ToString () {
			return Node.ToString();
		}

		public void ShowMenu() {
			popup.Popup();
			popup.ShowAll();
		}

		public void ShowDetails() {
			NodeDialog addDialog = new NodeDialog (Node.GetType().GetProperty("Data").GetValue(Node), false);
			addDialog.Run ();
			addDialog.Destroy ();
			Redraw();
		}

		public void Redraw() {
			QueueDraw();
		}

		public void AddPredecessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			Node.GetType ().GetMethod ("AddPredecessor").Invoke (Node, args);
			nv.successors [this] = false;
			predecessors[nv] = false;
		}

		public void RemovePredecessor(NodeVisualization nv) {
			object[] args = { nv.Node };
			Node.GetType ().GetMethod ("RemovePredecessor").Invoke (Node, args);
			nv.successors.Remove (this);
			predecessors.Remove (nv);
		}

		public void Visit(int order) {
			Visited = true;
			visitCount++;
			addLabel (order.ToString ());
		}

		private void addLabel(string label) {
			caption = label + ": " + caption;
		}
			
		public void Unvisit() {
			visitCount--;
			if(visitCount <= 0)
				Visited = false;

			removeLastLabel ();
		}

		private void removeLastLabel() {
			int ind = caption.IndexOf (' ');
			caption = caption.Substring (ind + 1);
		}

		public void ClearVisited() {
			Visited = false;
			visitCount = 0;
			caption = Name;
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

		public bool SetOutEdgeState(object succ, bool visited) {
			List<NodeVisualization> succs = new List<NodeVisualization>(successors.Keys);
			foreach (var n in succs) {
				if (n.Node == succ) {
					successors[n] = visited;
					n.predecessors [this] = visited;
					return true;
				}
			}
			return false;
		}

		protected void OnRemove(object sender, EventArgs args) {
			foreach (var p in predecessors.Keys) {
				p.successors.Remove (this);
			}
			foreach (var s in successors.Keys) {
				s.predecessors.Remove (this);
			}
			mvpanel.Graph.RemoveNode (this);

			Destroy ();
			mvpanel.RefreshChildren ();
			Dispose ();
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
				g.SetSourceColor(new Color (0.8, 0.8, 0.8, 1));
				g.FillPreserve ();
				if (Visited)
					g.SetSourceColor(new Color (0, 0.8, 0, 1));
				else
					g.SetSourceColor(new Color (0, 0.65, 1, 1));
				g.LineWidth = 5;
				g.Stroke ();

				SetupFont (g);
				FontExtents fe = g.FontExtents;
				TextExtents te = g.TextExtents(caption);
				double x = Width/2 + te.XBearing - te.Width / 2;
				double y = Height/2 + fe.Descent + fe.Height / 2;

				g.MoveTo(x, y);
				g.SetSourceColor(new Color(0, 0, 0));
				g.ShowText(caption);
			}
			return true;
		}

		private void DrawCurvedRectangle (Cairo.Context gr) {	
			double x = 0, y = 0;
			gr.Save ();
			gr.MoveTo (x, y + Height / 2);
			gr.CurveTo (x, y, x, y, x + Width / 2, y);
			gr.CurveTo (x + Width, y, x + Width, y, x + Width, y + Height / 2);
			gr.CurveTo (x + Width, y + Height, x + Width, y + Height, x + Width / 2, y + Height);
			gr.CurveTo (x, y + Height, x, y + Height, x, y + Height / 2);
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
