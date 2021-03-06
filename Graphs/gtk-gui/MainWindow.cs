
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
	
	private global::Gtk.Label label1;
	
	private global::Gtk.ComboBox modelsCombobox;
	
	private global::Gtk.HBox hbox4;
	
	private global::Gtk.Button clearBtn;
	
	private global::Gtk.Button drawBtn;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Button addBtn;
	
	private global::Gtk.HSeparator hseparator1;
	
	private global::Gtk.Label label2;
	
	private global::Gtk.ComboBox algorithmCombobox;
	
	private global::Gtk.Button executeButton;
	
	private global::Gtk.HBox hbox2;
	
	private global::Gtk.Button prevStepBtn;
	
	private global::Gtk.Button nextStepBtn;
	
	private global::Gtk.Button clearAlgsBtn;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("_File"), null, null);
		this.FileAction.IsImportant = true;
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
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
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Graph");
		this.label1.Justify = ((global::Gtk.Justification)(1));
		this.vbox3.Add (this.label1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label1]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.modelsCombobox = global::Gtk.ComboBox.NewText ();
		this.modelsCombobox.Name = "modelsCombobox";
		this.vbox3.Add (this.modelsCombobox);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.modelsCombobox]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
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
		global::Gtk.Image w5 = new global::Gtk.Image ();
		w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-clear", global::Gtk.IconSize.Menu);
		this.clearBtn.Image = w5;
		this.hbox4.Add (this.clearBtn);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.clearBtn]));
		w6.Position = 0;
		// Container child hbox4.Gtk.Box+BoxChild
		this.drawBtn = new global::Gtk.Button ();
		this.drawBtn.Sensitive = false;
		this.drawBtn.CanFocus = true;
		this.drawBtn.Name = "drawBtn";
		this.drawBtn.UseUnderline = true;
		this.drawBtn.Label = global::Mono.Unix.Catalog.GetString ("Rysuj");
		global::Gtk.Image w7 = new global::Gtk.Image ();
		w7.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
		this.drawBtn.Image = w7;
		this.hbox4.Add (this.drawBtn);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.drawBtn]));
		w8.Position = 1;
		this.vbox3.Add (this.hbox4);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
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
		w10.Position = 0;
		this.vbox3.Add (this.hbox1);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
		w11.Position = 3;
		w11.Expand = false;
		w11.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hseparator1 = new global::Gtk.HSeparator ();
		this.hseparator1.Name = "hseparator1";
		this.vbox3.Add (this.hseparator1);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hseparator1]));
		w12.Position = 4;
		w12.Expand = false;
		w12.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Algorithms");
		this.vbox3.Add (this.label2);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label2]));
		w13.Position = 5;
		w13.Expand = false;
		w13.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.algorithmCombobox = global::Gtk.ComboBox.NewText ();
		this.algorithmCombobox.Sensitive = false;
		this.algorithmCombobox.Name = "algorithmCombobox";
		this.vbox3.Add (this.algorithmCombobox);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.algorithmCombobox]));
		w14.Position = 6;
		w14.Expand = false;
		w14.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.executeButton = new global::Gtk.Button ();
		this.executeButton.Sensitive = false;
		this.executeButton.CanFocus = true;
		this.executeButton.Name = "executeButton";
		this.executeButton.UseStock = true;
		this.executeButton.UseUnderline = true;
		this.executeButton.Label = "gtk-execute";
		this.vbox3.Add (this.executeButton);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.executeButton]));
		w15.Position = 7;
		w15.Expand = false;
		w15.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.prevStepBtn = new global::Gtk.Button ();
		this.prevStepBtn.Sensitive = false;
		this.prevStepBtn.CanFocus = true;
		this.prevStepBtn.Name = "prevStepBtn";
		this.prevStepBtn.UseUnderline = true;
		this.prevStepBtn.Label = global::Mono.Unix.Catalog.GetString ("_Wstecz");
		global::Gtk.Image w16 = new global::Gtk.Image ();
		this.prevStepBtn.Image = w16;
		this.hbox2.Add (this.prevStepBtn);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.prevStepBtn]));
		w17.Position = 0;
		// Container child hbox2.Gtk.Box+BoxChild
		this.nextStepBtn = new global::Gtk.Button ();
		this.nextStepBtn.Sensitive = false;
		this.nextStepBtn.CanFocus = true;
		this.nextStepBtn.Name = "nextStepBtn";
		this.nextStepBtn.UseUnderline = true;
		this.nextStepBtn.Label = global::Mono.Unix.Catalog.GetString ("_Dalej");
		global::Gtk.Image w18 = new global::Gtk.Image ();
		this.nextStepBtn.Image = w18;
		this.hbox2.Add (this.nextStepBtn);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.nextStepBtn]));
		w19.Position = 1;
		this.vbox3.Add (this.hbox2);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox2]));
		w20.Position = 8;
		w20.Expand = false;
		w20.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.clearAlgsBtn = new global::Gtk.Button ();
		this.clearAlgsBtn.Sensitive = false;
		this.clearAlgsBtn.CanFocus = true;
		this.clearAlgsBtn.Name = "clearAlgsBtn";
		this.clearAlgsBtn.UseStock = true;
		this.clearAlgsBtn.UseUnderline = true;
		this.clearAlgsBtn.Label = "gtk-clear";
		this.vbox3.Add (this.clearAlgsBtn);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.clearAlgsBtn]));
		w21.Position = 9;
		w21.Expand = false;
		w21.Fill = false;
		this.hbox3.Add (this.vbox3);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vbox3]));
		w22.Position = 0;
		w22.Expand = false;
		w22.Fill = false;
		this.mainVbox.Add (this.hbox3);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.mainVbox [this.hbox3]));
		w23.Position = 1;
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
		this.executeButton.Clicked += new global::System.EventHandler (this.OnExecuteButtonClicked);
		this.prevStepBtn.Clicked += new global::System.EventHandler (this.OnPrevStepBtnClicked);
		this.nextStepBtn.Clicked += new global::System.EventHandler (this.OnNextStepBtnClicked);
		this.clearAlgsBtn.Clicked += new global::System.EventHandler (this.OnClearAlgsBtnClicked);
	}
}
