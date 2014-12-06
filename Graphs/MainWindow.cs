using System;
using Gtk;
using System.Collections.Generic;
using System.Reflection;
using Graphs;
using GraphProject;
using models;

public partial class MainWindow: Gtk.Window {
	private string assemblyFileName;
	private Type[] models;
	Type selectedModel;
	private MovablePanel mvpanel1 = new MovablePanel(_rightClick: "ShowMenu", _doubleClick: "ShowDetails");

	public MainWindow () : base (Gtk.WindowType.Toplevel) {
		Build ();
		hbox3.Add (mvpanel1);
		algorithmCombobox.InsertText (0, "BFS");
		algorithmCombobox.InsertText (1, "DFS");
		algorithmCombobox.InsertText (2, "Eulerian Directed Path");
		algorithmCombobox.InsertText (3, "Topological Sort");
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
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

		if( chooser.Run() == ( int )ResponseType.Accept ) {
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
		about.ProgramName = "GraphVisualizer";
		about.Version = "1.0.0";
		about.Run();
		about.Destroy();
	}

	protected void OnDraw (object sender, EventArgs e) {
		Type[] typeArgs = { selectedModel };
		Type graphType = typeof(Graph<>);
		Type constructedGraphType = graphType.MakeGenericType(typeArgs);
		mvpanel1.graph = Activator.CreateInstance (constructedGraphType);
		
		drawBtn.Sensitive = false;
		clearBtn.Sensitive = true;
		modelsCombobox.Sensitive = false;
		addBtn.Sensitive = true;
		executeButton.Sensitive = true;
		algorithmCombobox.Sensitive = true;
	}

	protected void OnClear (object sender, EventArgs e) {
		mvpanel1.RemoveAllChildren ();

		drawBtn.Sensitive = true;
		clearBtn.Sensitive = false;
		modelsCombobox.Sensitive = true;
		addBtn.Sensitive = false;
		executeButton.Sensitive = false;
		algorithmCombobox.Sensitive = false;
	}

	protected void OnSelect (object sender, EventArgs e) {
		selectedModel = models [modelsCombobox.Active];
	}

	protected void OnAddBtnClicked (object sender, EventArgs e) {
		object model = Activator.CreateInstance (selectedModel);
		NodeDialog addDialog = new NodeDialog (selectedModel, model);
		if (addDialog.Run () == (int)ResponseType.Ok && !string.IsNullOrEmpty(model.ToString())) {
			//adding node to drawing area
			Type[] typeArgs = { selectedModel };
			Type nodeType = typeof(Node<>);
			Type constructedNodeType = nodeType.MakeGenericType(typeArgs);
			object node = Activator.CreateInstance (constructedNodeType, model);

			NodeVisualization mvo = new NodeVisualization (constructedNodeType, node);
			mvpanel1.AddNode (mvo, 10, 10);
		}
		addDialog.Destroy ();
	}

	protected void OnExecuteButtonClicked (object sender, EventArgs e) {
		mvpanel1.RunAlgorithm (algorithmCombobox.ActiveText);
	}
}
