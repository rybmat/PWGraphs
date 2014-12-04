
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action FileAction;
	
	private global::Gtk.Action EditAction;
	
	private global::Gtk.Action openAction;
	
	private global::Gtk.Action quitAction;
	
	private global::Gtk.Action HelpAction;
	
	private global::Gtk.Action dialogInfoAction;
	
	private global::Gtk.VBox mainVbox;
	
	private global::Gtk.MenuBar menubar1;
	
	private global::Gtk.HBox hbox3;
	
	private global::Gtk.VBox vbox3;
	
	private global::Gtk.ComboBox modelsCombobox;
	
	private global::Gtk.HBox hbox4;
	
	private global::Gtk.Button clearBtn;
	
	private global::Gtk.Button drawBtn;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Button removeBtn;
	
	private global::Gtk.Button addBtn;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("_File"), null, null);
		this.FileAction.IsImportant = true;
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, "nacute");
		this.EditAction = new global::Gtk.Action ("EditAction", global::Mono.Unix.Catalog.GetString ("Edit"), null, null);
		this.EditAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit");
		w1.Add (this.EditAction, null);
		this.openAction = new global::Gtk.Action ("openAction", global::Mono.Unix.Catalog.GetString ("_Open"), null, "gtk-open");
		this.openAction.IsImportant = true;
		this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Open");
		w1.Add (this.openAction, null);
		this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("Quit"), null, "gtk-quit");
		this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Quit");
		w1.Add (this.quitAction, null);
		this.HelpAction = new global::Gtk.Action ("HelpAction", global::Mono.Unix.Catalog.GetString ("Help"), null, null);
		this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Help");
		w1.Add (this.HelpAction, null);
		this.dialogInfoAction = new global::Gtk.Action ("dialogInfoAction", global::Mono.Unix.Catalog.GetString ("about"), null, "gtk-dialog-info");
		this.dialogInfoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("about");
		w1.Add (this.dialogInfoAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.mainVbox = new global::Gtk.VBox ();
		this.mainVbox.Name = "mainVbox";
		this.mainVbox.Spacing = 6;
		// Container child mainVbox.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='openAction' action='openAction'/><menuitem name='quitAction' action='quitAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='dialogInfoAction' action='dialogInfoAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.mainVbox.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.mainVbox [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child mainVbox.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox ();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.modelsCombobox = global::Gtk.ComboBox.NewText ();
		this.modelsCombobox.Name = "modelsCombobox";
		this.vbox3.Add (this.modelsCombobox);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.modelsCombobox]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox ();
		this.hbox4.Name = "hbox4";
		this.hbox4.Homogeneous = true;
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.clearBtn = new global::Gtk.Button ();
		this.clearBtn.Sensitive = false;
		this.clearBtn.CanFocus = true;
		this.clearBtn.Name = "clearBtn";
		this.clearBtn.UseUnderline = true;
		this.clearBtn.Label = global::Mono.Unix.Catalog.GetString ("Wy_czyść");
		global::Gtk.Image w4 = new global::Gtk.Image ();
		w4.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-clear", global::Gtk.IconSize.Menu);
		this.clearBtn.Image = w4;
		this.hbox4.Add (this.clearBtn);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.clearBtn]));
		w5.Position = 0;
		// Container child hbox4.Gtk.Box+BoxChild
		this.drawBtn = new global::Gtk.Button ();
		this.drawBtn.Sensitive = false;
		this.drawBtn.CanFocus = true;
		this.drawBtn.Name = "drawBtn";
		this.drawBtn.UseUnderline = true;
		this.drawBtn.Label = global::Mono.Unix.Catalog.GetString ("Rysuj");
		global::Gtk.Image w6 = new global::Gtk.Image ();
		w6.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
		this.drawBtn.Image = w6;
		this.hbox4.Add (this.drawBtn);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.drawBtn]));
		w7.Position = 1;
		this.vbox3.Add (this.hbox4);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.removeBtn = new global::Gtk.Button ();
		this.removeBtn.Sensitive = false;
		this.removeBtn.CanFocus = true;
		this.removeBtn.Name = "removeBtn";
		this.removeBtn.UseStock = true;
		this.removeBtn.UseUnderline = true;
		this.removeBtn.Label = "gtk-remove";
		this.hbox1.Add (this.removeBtn);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.removeBtn]));
		w9.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.addBtn = new global::Gtk.Button ();
		this.addBtn.Sensitive = false;
		this.addBtn.CanFocus = true;
		this.addBtn.Name = "addBtn";
		this.addBtn.UseStock = true;
		this.addBtn.UseUnderline = true;
		this.addBtn.Label = "gtk-add";
		this.hbox1.Add (this.addBtn);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.addBtn]));
		w10.Position = 1;
		this.vbox3.Add (this.hbox1);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
		w11.Position = 2;
		w11.Expand = false;
		w11.Fill = false;
		this.hbox3.Add (this.vbox3);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vbox3]));
		w12.Position = 0;
		w12.Expand = false;
		w12.Fill = false;
		this.mainVbox.Add (this.hbox3);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.mainVbox [this.hbox3]));
		w13.Position = 1;
		this.Add (this.mainVbox);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1035;
		this.DefaultHeight = 560;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.openAction.Activated += new global::System.EventHandler (this.OnOpen);
		this.quitAction.Activated += new global::System.EventHandler (this.OnQuit);
		this.dialogInfoAction.Activated += new global::System.EventHandler (this.OnAbout);
		this.modelsCombobox.Changed += new global::System.EventHandler (this.OnSelect);
		this.clearBtn.Clicked += new global::System.EventHandler (this.OnClear);
		this.drawBtn.Clicked += new global::System.EventHandler (this.OnDraw);
		this.addBtn.Clicked += new global::System.EventHandler (this.OnAddBtnClicked);
	}
}
