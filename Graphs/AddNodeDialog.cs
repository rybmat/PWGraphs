using System;
using Gtk;
using System.Collections.Generic;
using System.Reflection;
using Graphs;
using System.Linq;

namespace Graphs {
	public partial class AddNodeDialog : Gtk.Dialog {

		object model;

		public AddNodeDialog (Type type, object _model) {
			model = _model;
			foreach (var p in type.GetProperties()) {
				HBox hb = new HBox ();
				Label l = new Label (p.Name);
				l.Name = p.Name + "_label";
				Entry e = new Entry ();
				e.Name = p.Name;
				hb.Add (l);
				hb.Add (e);
				this.VBox.Add (hb);
			}

			Build ();
			Modal = true;
			ShowAll ();
		}


		protected void OnButtonOkClicked (object sender, EventArgs e) {
			foreach (var widget in this.VBox.AllChildren) {
				if (widget.GetType() == typeof(HBox)) {
					foreach(var w in ((HBox)widget).AllChildren) {
						if (w.GetType () == typeof(Entry)) {
							model.GetType ().GetRuntimeProperty (((Entry)w).Name).SetValue (model, ((Entry)w).Text);
						}
					}
				}
			}

		}
	}
}

