using System;
using Gtk;
using System.Collections.Generic;
using System.Reflection;

public partial class MainWindow: Gtk.Window
{
	private string assemblyFileName;
	private List<TreeViewColumn> columns = new List<TreeViewColumn> ();
	private Type[] models;
	private ListStore nodesListStore;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnOpen (object sender, EventArgs e) {
		FileChooserDialog chooser = new FileChooserDialog(
			"Please select a dll file with models ...",
			this,
			FileChooserAction.Open,
			"Cancel", ResponseType.Cancel,
			"Open", ResponseType.Accept );

		chooser.Filter = new FileFilter();
		chooser.Filter.AddPattern("*.dll");

		if( chooser.Run() == ( int )ResponseType.Accept )
		{
			assemblyFileName = chooser.Filename;
			models = Assembly.LoadFrom (assemblyFileName).GetTypes ();
			foreach(var t in models) {
				modelsCombobox.AppendText (t.ToString ());
			}

			modelsCombobox.Active = 0;
			drawBtn.Sensitive = true;
		}
		chooser.Destroy();
	}

	protected void OnQuit (object sender, EventArgs e) {
		Application.Quit ();
	}
	protected void OnAbout (object sender, EventArgs e) {
		AboutDialog about = new AboutDialog();

		about.Name = "GraphVisualizer";
		about.Version = "1.0.0";

		about.Run();

		about.Destroy();
	}

	protected void OnDraw (object sender, EventArgs e) {
		drawBtn.Sensitive = false;
		clearBtn.Sensitive = true;
		modelsCombobox.Sensitive = false;
		nodesTreeView.Sensitive = true;
	}

	protected void OnClear (object sender, EventArgs e) {
		drawBtn.Sensitive = true;
		clearBtn.Sensitive = false;
		modelsCombobox.Sensitive = true;
		nodesTreeView.Sensitive = false;
	}

	protected void OnSelect (object sender, EventArgs e) {
		Type selectedModel = models [modelsCombobox.Active];
		foreach(var c in columns) {
			nodesTreeView.RemoveColumn(c);
		}

		columns = new List<TreeViewColumn> ();
		foreach (var p in selectedModel.GetProperties()) {
			var c = new TreeViewColumn ();
			c.Title = p.ToString ().Split(' ')[1];
			columns.Add (c);
			nodesTreeView.AppendColumn (c);
		}
		nodesListStore = new ListStore (selectedModel);
		nodesTreeView.Model = nodesListStore;

	}
}
