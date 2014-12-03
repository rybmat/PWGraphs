using System;
using Gtk;
using Cairo;

namespace Graphs {

	public class MVObject : Gtk.DrawingArea {
		string parentName = "";
		string caption = "";
		Gtk.Menu popup = null;
		int width = 0;
		int height;

		public MVObject(string pName, string cap) {
			popup = new Gtk.Menu();
			Gtk.MenuItem rm = new MenuItem("Remove");
			rm.Activated += new EventHandler(OnRemove);
			popup.Add(rm);			

			parentName = pName;
			caption = cap;
			width = caption.Length * 6 + 10;
			height = 40;

			Name = parentName + "MVObject";

			SetSizeRequest(width, height);
		}

		public void ShowMenu() {
			popup.Popup();
			popup.ShowAll();
		}

		public void ShowDetails() {
			//Todo: show dialog with details
			QueueDraw();
		}

		public string Caption {
			get {
				return caption;
			}
		}

		public void Redraw() {
			Console.WriteLine("Redrawing");
			QueueDraw();
		}

		protected void OnRemove(object sender, EventArgs args) {
			Console.WriteLine("Remove clicked");
			//Todo: remove entry from graph, detach from MVPanel and destroy self;
			QueueDraw();
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


