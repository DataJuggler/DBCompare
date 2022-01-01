

#region using statements


#endregion

namespace DBCompare
{

    #region class MainForm
    /// <summary>
    /// This is the designer for the MainForm (formatted by Regionizer - http://regionizer.codeplex.com)
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel SourceTopPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #endregion
            
            #region InitializeComponent()
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.SourceTopPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.YouTubePanel = new System.Windows.Forms.Panel();
            this.GenerateScriptsButton = new System.Windows.Forms.Button();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountLeftMargin = new System.Windows.Forms.Panel();
            this.YouTubeButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Separator6 = new System.Windows.Forms.Panel();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.HiddenButton = new System.Windows.Forms.Button();
            this.BuildSourceConnectionStringButton = new System.Windows.Forms.Button();
            this.BuildTargetConnectionStringButton = new System.Windows.Forms.Button();
            this.SwapButton = new System.Windows.Forms.Button();
            this.CompareDatabasesButton = new System.Windows.Forms.Button();
            this.CreateXmlFileButton = new System.Windows.Forms.Button();
            this.LeftMarginPanel3 = new System.Windows.Forms.Panel();
            this.CompareDatabaseTopPanel = new System.Windows.Forms.Panel();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.RemoteComparePanel = new System.Windows.Forms.Panel();
            this.CreateXmlFileCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.RemoteCompareCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.IgnoreDataSyncPanel = new System.Windows.Forms.Panel();
            this.IgnoreFirewallRulesCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.IgnoreDataSyncCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.TopCheckBoxPanel = new System.Windows.Forms.Panel();
            this.IgnoreIndexesCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.StoreConnectionStringsCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.IgnoreDiagramProceduresCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.RightFillerPanel = new System.Windows.Forms.Panel();
            this.Seperator4 = new System.Windows.Forms.Panel();
            this.CompareRightColumn = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SeparatorPanel = new System.Windows.Forms.Panel();
            this.ButtonTopPanel = new System.Windows.Forms.Panel();
            this.ButtonBottomPanel = new System.Windows.Forms.Panel();
            this.VerticalSeparator2 = new System.Windows.Forms.Panel();
            this.TopSectionPanel = new System.Windows.Forms.Panel();
            this.TargetConnectionStringControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.VerticalSeparator1 = new System.Windows.Forms.Panel();
            this.TargetConnectionPanel = new System.Windows.Forms.Panel();
            this.SourceConnectionStringControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.VerticalSeparator3 = new System.Windows.Forms.Panel();
            this.InnerBorder = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.ComparisonReportLabel = new System.Windows.Forms.Label();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.YouTubePanel.SuspendLayout();
            this.CompareDatabaseTopPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.RemoteComparePanel.SuspendLayout();
            this.IgnoreDataSyncPanel.SuspendLayout();
            this.TopCheckBoxPanel.SuspendLayout();
            this.CompareRightColumn.SuspendLayout();
            this.TopSectionPanel.SuspendLayout();
            this.TargetConnectionPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 681);
            this.LeftMarginPanel.TabIndex = 24;
            // 
            // SourceTopPanel
            // 
            this.SourceTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.SourceTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SourceTopPanel.Location = new System.Drawing.Point(16, 0);
            this.SourceTopPanel.Name = "SourceTopPanel";
            this.SourceTopPanel.Size = new System.Drawing.Size(1108, 16);
            this.SourceTopPanel.TabIndex = 48;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(1108, 16);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 653);
            this.RightMarginPanel.TabIndex = 55;
            // 
            // YouTubePanel
            // 
            this.YouTubePanel.BackColor = System.Drawing.Color.Transparent;
            this.YouTubePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YouTubePanel.Controls.Add(this.GenerateScriptsButton);
            this.YouTubePanel.Controls.Add(this.CountLabel);
            this.YouTubePanel.Controls.Add(this.CountLeftMargin);
            this.YouTubePanel.Controls.Add(this.YouTubeButton);
            this.YouTubePanel.Controls.Add(this.panel6);
            this.YouTubePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YouTubePanel.Location = new System.Drawing.Point(16, 601);
            this.YouTubePanel.Name = "YouTubePanel";
            this.YouTubePanel.Size = new System.Drawing.Size(1092, 68);
            this.YouTubePanel.TabIndex = 85;
            // 
            // GenerateScriptsButton
            // 
            this.GenerateScriptsButton.BackColor = System.Drawing.Color.Transparent;
            this.GenerateScriptsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GenerateScriptsButton.BackgroundImage")));
            this.GenerateScriptsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GenerateScriptsButton.FlatAppearance.BorderSize = 0;
            this.GenerateScriptsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GenerateScriptsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GenerateScriptsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateScriptsButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GenerateScriptsButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.GenerateScriptsButton.Location = new System.Drawing.Point(444, 19);
            this.GenerateScriptsButton.MaximumSize = new System.Drawing.Size(220, 34);
            this.GenerateScriptsButton.MinimumSize = new System.Drawing.Size(220, 34);
            this.GenerateScriptsButton.Name = "GenerateScriptsButton";
            this.GenerateScriptsButton.Size = new System.Drawing.Size(220, 34);
            this.GenerateScriptsButton.TabIndex = 100;
            this.GenerateScriptsButton.Text = "Generate Scripts";
            this.MainToolTip.SetToolTip(this.GenerateScriptsButton, "Perform the database comparison");
            this.GenerateScriptsButton.UseVisualStyleBackColor = false;
            this.GenerateScriptsButton.Visible = false;
            this.GenerateScriptsButton.Click += new System.EventHandler(this.GenerateScriptsButton_Click);
            // 
            // CountLabel
            // 
            this.CountLabel.BackColor = System.Drawing.Color.Transparent;
            this.CountLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CountLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CountLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CountLabel.Location = new System.Drawing.Point(16, 4);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(140, 64);
            this.CountLabel.TabIndex = 88;
            this.CountLabel.Text = "Count: 0";
            this.CountLabel.Visible = false;
            // 
            // CountLeftMargin
            // 
            this.CountLeftMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.CountLeftMargin.Location = new System.Drawing.Point(0, 4);
            this.CountLeftMargin.Name = "CountLeftMargin";
            this.CountLeftMargin.Size = new System.Drawing.Size(16, 64);
            this.CountLeftMargin.TabIndex = 87;
            // 
            // YouTubeButton
            // 
            this.YouTubeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("YouTubeButton.BackgroundImage")));
            this.YouTubeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YouTubeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.YouTubeButton.FlatAppearance.BorderSize = 0;
            this.YouTubeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.YouTubeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.YouTubeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YouTubeButton.Location = new System.Drawing.Point(964, 4);
            this.YouTubeButton.Name = "YouTubeButton";
            this.YouTubeButton.Size = new System.Drawing.Size(128, 64);
            this.YouTubeButton.TabIndex = 84;
            this.YouTubeButton.UseVisualStyleBackColor = true;
            this.YouTubeButton.Click += new System.EventHandler(this.YouTubeButton_Click);
            this.YouTubeButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.YouTubeButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1092, 4);
            this.panel6.TabIndex = 78;
            // 
            // Separator6
            // 
            this.Separator6.BackColor = System.Drawing.Color.Transparent;
            this.Separator6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Separator6.Location = new System.Drawing.Point(16, 589);
            this.Separator6.Name = "Separator6";
            this.Separator6.Size = new System.Drawing.Size(1092, 12);
            this.Separator6.TabIndex = 87;
            // 
            // HiddenButton
            // 
            this.HiddenButton.BackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HiddenButton.FlatAppearance.BorderSize = 0;
            this.HiddenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HiddenButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HiddenButton.ForeColor = System.Drawing.Color.White;
            this.HiddenButton.Location = new System.Drawing.Point(-300, 300);
            this.HiddenButton.MaximumSize = new System.Drawing.Size(220, 36);
            this.HiddenButton.MinimumSize = new System.Drawing.Size(220, 36);
            this.HiddenButton.Name = "HiddenButton";
            this.HiddenButton.Size = new System.Drawing.Size(220, 36);
            this.HiddenButton.TabIndex = 96;
            this.HiddenButton.Text = "Create Xml File";
            this.MainToolTip.SetToolTip(this.HiddenButton, "Perform the database comparison");
            this.HiddenButton.UseVisualStyleBackColor = false;
            this.HiddenButton.Visible = false;
            // 
            // BuildSourceConnectionStringButton
            // 
            this.BuildSourceConnectionStringButton.BackColor = System.Drawing.Color.Transparent;
            this.BuildSourceConnectionStringButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuildSourceConnectionStringButton.BackgroundImage")));
            this.BuildSourceConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BuildSourceConnectionStringButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BuildSourceConnectionStringButton.FlatAppearance.BorderSize = 0;
            this.BuildSourceConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BuildSourceConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BuildSourceConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BuildSourceConnectionStringButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BuildSourceConnectionStringButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BuildSourceConnectionStringButton.Location = new System.Drawing.Point(1052, 0);
            this.BuildSourceConnectionStringButton.Margin = new System.Windows.Forms.Padding(0);
            this.BuildSourceConnectionStringButton.MaximumSize = new System.Drawing.Size(40, 0);
            this.BuildSourceConnectionStringButton.Name = "BuildSourceConnectionStringButton";
            this.BuildSourceConnectionStringButton.Size = new System.Drawing.Size(40, 32);
            this.BuildSourceConnectionStringButton.TabIndex = 57;
            this.BuildSourceConnectionStringButton.Text = "...";
            this.MainToolTip.SetToolTip(this.BuildSourceConnectionStringButton, "Set the source connection string");
            this.BuildSourceConnectionStringButton.UseVisualStyleBackColor = false;
            this.BuildSourceConnectionStringButton.Click += new System.EventHandler(this.BuildSourceConnectionStringButton_Click);
            this.BuildSourceConnectionStringButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BuildSourceConnectionStringButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // BuildTargetConnectionStringButton
            // 
            this.BuildTargetConnectionStringButton.BackColor = System.Drawing.Color.Transparent;
            this.BuildTargetConnectionStringButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuildTargetConnectionStringButton.BackgroundImage")));
            this.BuildTargetConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BuildTargetConnectionStringButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BuildTargetConnectionStringButton.FlatAppearance.BorderSize = 0;
            this.BuildTargetConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BuildTargetConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BuildTargetConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BuildTargetConnectionStringButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BuildTargetConnectionStringButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BuildTargetConnectionStringButton.Location = new System.Drawing.Point(1052, 0);
            this.BuildTargetConnectionStringButton.Margin = new System.Windows.Forms.Padding(0);
            this.BuildTargetConnectionStringButton.MaximumSize = new System.Drawing.Size(40, 0);
            this.BuildTargetConnectionStringButton.Name = "BuildTargetConnectionStringButton";
            this.BuildTargetConnectionStringButton.Size = new System.Drawing.Size(40, 32);
            this.BuildTargetConnectionStringButton.TabIndex = 59;
            this.BuildTargetConnectionStringButton.Text = "...";
            this.MainToolTip.SetToolTip(this.BuildTargetConnectionStringButton, "Set the target connection string");
            this.BuildTargetConnectionStringButton.UseVisualStyleBackColor = false;
            this.BuildTargetConnectionStringButton.Click += new System.EventHandler(this.BuildTargetConnectionStringButton_Click);
            this.BuildTargetConnectionStringButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BuildTargetConnectionStringButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // SwapButton
            // 
            this.SwapButton.BackColor = System.Drawing.Color.Transparent;
            this.SwapButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SwapButton.BackgroundImage")));
            this.SwapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SwapButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SwapButton.FlatAppearance.BorderSize = 0;
            this.SwapButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SwapButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SwapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwapButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SwapButton.Location = new System.Drawing.Point(796, 4);
            this.SwapButton.Margin = new System.Windows.Forms.Padding(0);
            this.SwapButton.MaximumSize = new System.Drawing.Size(64, 64);
            this.SwapButton.MinimumSize = new System.Drawing.Size(64, 64);
            this.SwapButton.Name = "SwapButton";
            this.SwapButton.Size = new System.Drawing.Size(64, 64);
            this.SwapButton.TabIndex = 81;
            this.MainToolTip.SetToolTip(this.SwapButton, "Swap the source and target connection strings");
            this.SwapButton.UseVisualStyleBackColor = false;
            this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
            this.SwapButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.SwapButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // CompareDatabasesButton
            // 
            this.CompareDatabasesButton.BackColor = System.Drawing.Color.Transparent;
            this.CompareDatabasesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CompareDatabasesButton.BackgroundImage")));
            this.CompareDatabasesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CompareDatabasesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompareDatabasesButton.FlatAppearance.BorderSize = 0;
            this.CompareDatabasesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CompareDatabasesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CompareDatabasesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompareDatabasesButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CompareDatabasesButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CompareDatabasesButton.Location = new System.Drawing.Point(0, 9);
            this.CompareDatabasesButton.MaximumSize = new System.Drawing.Size(220, 34);
            this.CompareDatabasesButton.MinimumSize = new System.Drawing.Size(220, 34);
            this.CompareDatabasesButton.Name = "CompareDatabasesButton";
            this.CompareDatabasesButton.Size = new System.Drawing.Size(220, 34);
            this.CompareDatabasesButton.TabIndex = 96;
            this.CompareDatabasesButton.Text = "Compare Databases";
            this.MainToolTip.SetToolTip(this.CompareDatabasesButton, "Perform the database comparison");
            this.CompareDatabasesButton.UseVisualStyleBackColor = false;
            this.CompareDatabasesButton.Click += new System.EventHandler(this.CompareDatabasesButton_Click);
            this.CompareDatabasesButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CompareDatabasesButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // CreateXmlFileButton
            // 
            this.CreateXmlFileButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateXmlFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreateXmlFileButton.BackgroundImage")));
            this.CreateXmlFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateXmlFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateXmlFileButton.FlatAppearance.BorderSize = 0;
            this.CreateXmlFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CreateXmlFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CreateXmlFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateXmlFileButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CreateXmlFileButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CreateXmlFileButton.Location = new System.Drawing.Point(0, 55);
            this.CreateXmlFileButton.MaximumSize = new System.Drawing.Size(220, 34);
            this.CreateXmlFileButton.MinimumSize = new System.Drawing.Size(220, 34);
            this.CreateXmlFileButton.Name = "CreateXmlFileButton";
            this.CreateXmlFileButton.Size = new System.Drawing.Size(220, 34);
            this.CreateXmlFileButton.TabIndex = 99;
            this.CreateXmlFileButton.Text = "Create Xml File";
            this.MainToolTip.SetToolTip(this.CreateXmlFileButton, "Perform the database comparison");
            this.CreateXmlFileButton.UseVisualStyleBackColor = false;
            this.CreateXmlFileButton.Visible = false;
            this.CreateXmlFileButton.Click += new System.EventHandler(this.CreateXmlFileButton_Click);
            this.CreateXmlFileButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CreateXmlFileButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // LeftMarginPanel3
            // 
            this.LeftMarginPanel3.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel3.Location = new System.Drawing.Point(16, 16);
            this.LeftMarginPanel3.Name = "LeftMarginPanel3";
            this.LeftMarginPanel3.Size = new System.Drawing.Size(16, 573);
            this.LeftMarginPanel3.TabIndex = 103;
            // 
            // CompareDatabaseTopPanel
            // 
            this.CompareDatabaseTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.CompareDatabaseTopPanel.Controls.Add(this.OptionsPanel);
            this.CompareDatabaseTopPanel.Controls.Add(this.VerticalSeparator2);
            this.CompareDatabaseTopPanel.Controls.Add(this.TopSectionPanel);
            this.CompareDatabaseTopPanel.Controls.Add(this.VerticalSeparator1);
            this.CompareDatabaseTopPanel.Controls.Add(this.TargetConnectionPanel);
            this.CompareDatabaseTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompareDatabaseTopPanel.Location = new System.Drawing.Point(0, 0);
            this.CompareDatabaseTopPanel.Name = "CompareDatabaseTopPanel";
            this.CompareDatabaseTopPanel.Size = new System.Drawing.Size(1092, 184);
            this.CompareDatabaseTopPanel.TabIndex = 99;
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.OptionsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionsPanel.Controls.Add(this.RemoteComparePanel);
            this.OptionsPanel.Controls.Add(this.IgnoreDataSyncPanel);
            this.OptionsPanel.Controls.Add(this.TopCheckBoxPanel);
            this.OptionsPanel.Controls.Add(this.SwapButton);
            this.OptionsPanel.Controls.Add(this.RightFillerPanel);
            this.OptionsPanel.Controls.Add(this.Seperator4);
            this.OptionsPanel.Controls.Add(this.CompareRightColumn);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsPanel.Location = new System.Drawing.Point(0, 88);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(1092, 96);
            this.OptionsPanel.TabIndex = 69;
            // 
            // RemoteComparePanel
            // 
            this.RemoteComparePanel.Controls.Add(this.CreateXmlFileCheckBox);
            this.RemoteComparePanel.Controls.Add(this.RemoteCompareCheckBox);
            this.RemoteComparePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoteComparePanel.Location = new System.Drawing.Point(0, 66);
            this.RemoteComparePanel.MaximumSize = new System.Drawing.Size(780, 64);
            this.RemoteComparePanel.Name = "RemoteComparePanel";
            this.RemoteComparePanel.Size = new System.Drawing.Size(780, 32);
            this.RemoteComparePanel.TabIndex = 90;
            // 
            // CreateXmlFileCheckBox
            // 
            this.CreateXmlFileCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CreateXmlFileCheckBox.CheckBoxHorizontalOffSet = 0;
            this.CreateXmlFileCheckBox.CheckBoxVerticalOffSet = 2;
            this.CreateXmlFileCheckBox.CheckChangedListener = null;
            this.CreateXmlFileCheckBox.Checked = false;
            this.CreateXmlFileCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.CreateXmlFileCheckBox.Editable = true;
            this.CreateXmlFileCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateXmlFileCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.CreateXmlFileCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CreateXmlFileCheckBox.LabelText = "Create Xml File:";
            this.CreateXmlFileCheckBox.LabelWidth = 220;
            this.CreateXmlFileCheckBox.Location = new System.Drawing.Point(300, 0);
            this.CreateXmlFileCheckBox.MaximumSize = new System.Drawing.Size(232, 30);
            this.CreateXmlFileCheckBox.MinimumSize = new System.Drawing.Size(232, 30);
            this.CreateXmlFileCheckBox.Name = "CreateXmlFileCheckBox";
            this.CreateXmlFileCheckBox.Size = new System.Drawing.Size(232, 30);
            this.CreateXmlFileCheckBox.TabIndex = 98;
            this.CreateXmlFileCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // RemoteCompareCheckBox
            // 
            this.RemoteCompareCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RemoteCompareCheckBox.CheckBoxHorizontalOffSet = 0;
            this.RemoteCompareCheckBox.CheckBoxVerticalOffSet = 2;
            this.RemoteCompareCheckBox.CheckChangedListener = null;
            this.RemoteCompareCheckBox.Checked = false;
            this.RemoteCompareCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.RemoteCompareCheckBox.Editable = true;
            this.RemoteCompareCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemoteCompareCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.RemoteCompareCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RemoteCompareCheckBox.LabelText = "Remote Compare:";
            this.RemoteCompareCheckBox.LabelWidth = 280;
            this.RemoteCompareCheckBox.Location = new System.Drawing.Point(0, 0);
            this.RemoteCompareCheckBox.MaximumSize = new System.Drawing.Size(300, 32);
            this.RemoteCompareCheckBox.MinimumSize = new System.Drawing.Size(300, 32);
            this.RemoteCompareCheckBox.Name = "RemoteCompareCheckBox";
            this.RemoteCompareCheckBox.Size = new System.Drawing.Size(300, 32);
            this.RemoteCompareCheckBox.TabIndex = 97;
            this.RemoteCompareCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // IgnoreDataSyncPanel
            // 
            this.IgnoreDataSyncPanel.Controls.Add(this.IgnoreFirewallRulesCheckBox);
            this.IgnoreDataSyncPanel.Controls.Add(this.IgnoreDataSyncCheckBox);
            this.IgnoreDataSyncPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.IgnoreDataSyncPanel.Location = new System.Drawing.Point(0, 34);
            this.IgnoreDataSyncPanel.MaximumSize = new System.Drawing.Size(780, 64);
            this.IgnoreDataSyncPanel.Name = "IgnoreDataSyncPanel";
            this.IgnoreDataSyncPanel.Size = new System.Drawing.Size(780, 32);
            this.IgnoreDataSyncPanel.TabIndex = 89;
            // 
            // IgnoreFirewallRulesCheckBox
            // 
            this.IgnoreFirewallRulesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.IgnoreFirewallRulesCheckBox.CheckBoxHorizontalOffSet = 0;
            this.IgnoreFirewallRulesCheckBox.CheckBoxVerticalOffSet = 2;
            this.IgnoreFirewallRulesCheckBox.CheckChangedListener = null;
            this.IgnoreFirewallRulesCheckBox.Checked = true;
            this.IgnoreFirewallRulesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IgnoreFirewallRulesCheckBox.Editable = true;
            this.IgnoreFirewallRulesCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IgnoreFirewallRulesCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.IgnoreFirewallRulesCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IgnoreFirewallRulesCheckBox.LabelText = "Ignore Firewall Rules:";
            this.IgnoreFirewallRulesCheckBox.LabelWidth = 220;
            this.IgnoreFirewallRulesCheckBox.Location = new System.Drawing.Point(300, 0);
            this.IgnoreFirewallRulesCheckBox.MaximumSize = new System.Drawing.Size(232, 32);
            this.IgnoreFirewallRulesCheckBox.MinimumSize = new System.Drawing.Size(232, 32);
            this.IgnoreFirewallRulesCheckBox.Name = "IgnoreFirewallRulesCheckBox";
            this.IgnoreFirewallRulesCheckBox.Size = new System.Drawing.Size(232, 32);
            this.IgnoreFirewallRulesCheckBox.TabIndex = 98;
            this.IgnoreFirewallRulesCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // IgnoreDataSyncCheckBox
            // 
            this.IgnoreDataSyncCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.IgnoreDataSyncCheckBox.CheckBoxHorizontalOffSet = 0;
            this.IgnoreDataSyncCheckBox.CheckBoxVerticalOffSet = 2;
            this.IgnoreDataSyncCheckBox.CheckChangedListener = null;
            this.IgnoreDataSyncCheckBox.Checked = true;
            this.IgnoreDataSyncCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IgnoreDataSyncCheckBox.Editable = true;
            this.IgnoreDataSyncCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IgnoreDataSyncCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.IgnoreDataSyncCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IgnoreDataSyncCheckBox.LabelText = "Ignore SQL DataSync:";
            this.IgnoreDataSyncCheckBox.LabelWidth = 280;
            this.IgnoreDataSyncCheckBox.Location = new System.Drawing.Point(0, 0);
            this.IgnoreDataSyncCheckBox.MaximumSize = new System.Drawing.Size(300, 32);
            this.IgnoreDataSyncCheckBox.MinimumSize = new System.Drawing.Size(300, 32);
            this.IgnoreDataSyncCheckBox.Name = "IgnoreDataSyncCheckBox";
            this.IgnoreDataSyncCheckBox.Size = new System.Drawing.Size(300, 32);
            this.IgnoreDataSyncCheckBox.TabIndex = 97;
            this.IgnoreDataSyncCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // TopCheckBoxPanel
            // 
            this.TopCheckBoxPanel.Controls.Add(this.IgnoreIndexesCheckBox);
            this.TopCheckBoxPanel.Controls.Add(this.StoreConnectionStringsCheckBox);
            this.TopCheckBoxPanel.Controls.Add(this.IgnoreDiagramProceduresCheckBox);
            this.TopCheckBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopCheckBoxPanel.Location = new System.Drawing.Point(0, 4);
            this.TopCheckBoxPanel.MaximumSize = new System.Drawing.Size(780, 30);
            this.TopCheckBoxPanel.Name = "TopCheckBoxPanel";
            this.TopCheckBoxPanel.Size = new System.Drawing.Size(780, 30);
            this.TopCheckBoxPanel.TabIndex = 87;
            // 
            // IgnoreIndexesCheckBox
            // 
            this.IgnoreIndexesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.IgnoreIndexesCheckBox.CheckBoxHorizontalOffSet = 0;
            this.IgnoreIndexesCheckBox.CheckBoxVerticalOffSet = 2;
            this.IgnoreIndexesCheckBox.CheckChangedListener = null;
            this.IgnoreIndexesCheckBox.Checked = false;
            this.IgnoreIndexesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IgnoreIndexesCheckBox.Editable = true;
            this.IgnoreIndexesCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IgnoreIndexesCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.IgnoreIndexesCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IgnoreIndexesCheckBox.LabelText = "Ignore Indexes";
            this.IgnoreIndexesCheckBox.LabelWidth = 220;
            this.IgnoreIndexesCheckBox.Location = new System.Drawing.Point(532, 0);
            this.IgnoreIndexesCheckBox.MaximumSize = new System.Drawing.Size(232, 32);
            this.IgnoreIndexesCheckBox.MinimumSize = new System.Drawing.Size(232, 32);
            this.IgnoreIndexesCheckBox.Name = "IgnoreIndexesCheckBox";
            this.IgnoreIndexesCheckBox.Size = new System.Drawing.Size(232, 32);
            this.IgnoreIndexesCheckBox.TabIndex = 98;
            this.IgnoreIndexesCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // StoreConnectionStringsCheckBox
            // 
            this.StoreConnectionStringsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.StoreConnectionStringsCheckBox.CheckBoxHorizontalOffSet = 0;
            this.StoreConnectionStringsCheckBox.CheckBoxVerticalOffSet = 2;
            this.StoreConnectionStringsCheckBox.CheckChangedListener = null;
            this.StoreConnectionStringsCheckBox.Checked = true;
            this.StoreConnectionStringsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.StoreConnectionStringsCheckBox.Editable = true;
            this.StoreConnectionStringsCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StoreConnectionStringsCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.StoreConnectionStringsCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StoreConnectionStringsCheckBox.LabelText = "Store Conn Strings:";
            this.StoreConnectionStringsCheckBox.LabelWidth = 220;
            this.StoreConnectionStringsCheckBox.Location = new System.Drawing.Point(300, 0);
            this.StoreConnectionStringsCheckBox.MaximumSize = new System.Drawing.Size(232, 32);
            this.StoreConnectionStringsCheckBox.MinimumSize = new System.Drawing.Size(232, 32);
            this.StoreConnectionStringsCheckBox.Name = "StoreConnectionStringsCheckBox";
            this.StoreConnectionStringsCheckBox.Size = new System.Drawing.Size(232, 32);
            this.StoreConnectionStringsCheckBox.TabIndex = 97;
            this.StoreConnectionStringsCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // IgnoreDiagramProceduresCheckBox
            // 
            this.IgnoreDiagramProceduresCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.IgnoreDiagramProceduresCheckBox.CheckBoxHorizontalOffSet = 0;
            this.IgnoreDiagramProceduresCheckBox.CheckBoxVerticalOffSet = 2;
            this.IgnoreDiagramProceduresCheckBox.CheckChangedListener = null;
            this.IgnoreDiagramProceduresCheckBox.Checked = true;
            this.IgnoreDiagramProceduresCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IgnoreDiagramProceduresCheckBox.Editable = true;
            this.IgnoreDiagramProceduresCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IgnoreDiagramProceduresCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.IgnoreDiagramProceduresCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IgnoreDiagramProceduresCheckBox.LabelText = "Ignore Diagram Procedures:";
            this.IgnoreDiagramProceduresCheckBox.LabelWidth = 280;
            this.IgnoreDiagramProceduresCheckBox.Location = new System.Drawing.Point(0, 0);
            this.IgnoreDiagramProceduresCheckBox.MaximumSize = new System.Drawing.Size(300, 32);
            this.IgnoreDiagramProceduresCheckBox.MinimumSize = new System.Drawing.Size(300, 32);
            this.IgnoreDiagramProceduresCheckBox.Name = "IgnoreDiagramProceduresCheckBox";
            this.IgnoreDiagramProceduresCheckBox.Size = new System.Drawing.Size(300, 32);
            this.IgnoreDiagramProceduresCheckBox.TabIndex = 94;
            this.IgnoreDiagramProceduresCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // RightFillerPanel
            // 
            this.RightFillerPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightFillerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightFillerPanel.Location = new System.Drawing.Point(860, 4);
            this.RightFillerPanel.Name = "RightFillerPanel";
            this.RightFillerPanel.Size = new System.Drawing.Size(12, 92);
            this.RightFillerPanel.TabIndex = 80;
            // 
            // Seperator4
            // 
            this.Seperator4.BackColor = System.Drawing.Color.Transparent;
            this.Seperator4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Seperator4.Location = new System.Drawing.Point(0, 0);
            this.Seperator4.Name = "Seperator4";
            this.Seperator4.Size = new System.Drawing.Size(872, 4);
            this.Seperator4.TabIndex = 78;
            // 
            // CompareRightColumn
            // 
            this.CompareRightColumn.Controls.Add(this.CreateXmlFileButton);
            this.CompareRightColumn.Controls.Add(this.panel1);
            this.CompareRightColumn.Controls.Add(this.CompareDatabasesButton);
            this.CompareRightColumn.Controls.Add(this.SeparatorPanel);
            this.CompareRightColumn.Controls.Add(this.ButtonTopPanel);
            this.CompareRightColumn.Controls.Add(this.ButtonBottomPanel);
            this.CompareRightColumn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CompareRightColumn.Location = new System.Drawing.Point(872, 0);
            this.CompareRightColumn.Name = "CompareRightColumn";
            this.CompareRightColumn.Size = new System.Drawing.Size(220, 96);
            this.CompareRightColumn.TabIndex = 62;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 12);
            this.panel1.TabIndex = 98;
            // 
            // SeparatorPanel
            // 
            this.SeparatorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SeparatorPanel.Location = new System.Drawing.Point(0, 5);
            this.SeparatorPanel.Name = "SeparatorPanel";
            this.SeparatorPanel.Size = new System.Drawing.Size(220, 4);
            this.SeparatorPanel.TabIndex = 93;
            // 
            // ButtonTopPanel
            // 
            this.ButtonTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonTopPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonTopPanel.Name = "ButtonTopPanel";
            this.ButtonTopPanel.Size = new System.Drawing.Size(220, 5);
            this.ButtonTopPanel.TabIndex = 62;
            // 
            // ButtonBottomPanel
            // 
            this.ButtonBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonBottomPanel.Location = new System.Drawing.Point(0, 94);
            this.ButtonBottomPanel.Name = "ButtonBottomPanel";
            this.ButtonBottomPanel.Size = new System.Drawing.Size(220, 2);
            this.ButtonBottomPanel.TabIndex = 61;
            // 
            // VerticalSeparator2
            // 
            this.VerticalSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.VerticalSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.VerticalSeparator2.Location = new System.Drawing.Point(0, 76);
            this.VerticalSeparator2.Name = "VerticalSeparator2";
            this.VerticalSeparator2.Size = new System.Drawing.Size(1092, 12);
            this.VerticalSeparator2.TabIndex = 68;
            // 
            // TopSectionPanel
            // 
            this.TopSectionPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopSectionPanel.Controls.Add(this.TargetConnectionStringControl);
            this.TopSectionPanel.Controls.Add(this.BuildTargetConnectionStringButton);
            this.TopSectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopSectionPanel.Location = new System.Drawing.Point(0, 44);
            this.TopSectionPanel.Name = "TopSectionPanel";
            this.TopSectionPanel.Size = new System.Drawing.Size(1092, 32);
            this.TopSectionPanel.TabIndex = 60;
            // 
            // TargetConnectionStringControl
            // 
            this.TargetConnectionStringControl.BackColor = System.Drawing.Color.Transparent;
            this.TargetConnectionStringControl.BottomMargin = 0;
            this.TargetConnectionStringControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TargetConnectionStringControl.Editable = true;
            this.TargetConnectionStringControl.Encrypted = false;
            this.TargetConnectionStringControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetConnectionStringControl.LabelBottomMargin = 2;
            this.TargetConnectionStringControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.TargetConnectionStringControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TargetConnectionStringControl.LabelText = "Target Conn. String:";
            this.TargetConnectionStringControl.LabelTopMargin = 4;
            this.TargetConnectionStringControl.LabelWidth = 208;
            this.TargetConnectionStringControl.Location = new System.Drawing.Point(0, 0);
            this.TargetConnectionStringControl.MultiLine = false;
            this.TargetConnectionStringControl.Name = "TargetConnectionStringControl";
            this.TargetConnectionStringControl.OnTextChangedListener = null;
            this.TargetConnectionStringControl.PasswordMode = false;
            this.TargetConnectionStringControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TargetConnectionStringControl.Size = new System.Drawing.Size(1052, 32);
            this.TargetConnectionStringControl.TabIndex = 60;
            this.TargetConnectionStringControl.TextBoxBottomMargin = 0;
            this.TargetConnectionStringControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.TargetConnectionStringControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.TargetConnectionStringControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TargetConnectionStringControl.TextBoxTopMargin = 6;
            this.TargetConnectionStringControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // VerticalSeparator1
            // 
            this.VerticalSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.VerticalSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.VerticalSeparator1.Location = new System.Drawing.Point(0, 32);
            this.VerticalSeparator1.Name = "VerticalSeparator1";
            this.VerticalSeparator1.Size = new System.Drawing.Size(1092, 12);
            this.VerticalSeparator1.TabIndex = 59;
            // 
            // TargetConnectionPanel
            // 
            this.TargetConnectionPanel.BackColor = System.Drawing.Color.Transparent;
            this.TargetConnectionPanel.Controls.Add(this.SourceConnectionStringControl);
            this.TargetConnectionPanel.Controls.Add(this.BuildSourceConnectionStringButton);
            this.TargetConnectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TargetConnectionPanel.Location = new System.Drawing.Point(0, 0);
            this.TargetConnectionPanel.Name = "TargetConnectionPanel";
            this.TargetConnectionPanel.Size = new System.Drawing.Size(1092, 32);
            this.TargetConnectionPanel.TabIndex = 57;
            // 
            // SourceConnectionStringControl
            // 
            this.SourceConnectionStringControl.BackColor = System.Drawing.Color.Transparent;
            this.SourceConnectionStringControl.BottomMargin = 0;
            this.SourceConnectionStringControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.SourceConnectionStringControl.Editable = true;
            this.SourceConnectionStringControl.Encrypted = false;
            this.SourceConnectionStringControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceConnectionStringControl.LabelBottomMargin = 0;
            this.SourceConnectionStringControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.SourceConnectionStringControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SourceConnectionStringControl.LabelText = "Source Conn. String:";
            this.SourceConnectionStringControl.LabelTopMargin = 4;
            this.SourceConnectionStringControl.LabelWidth = 208;
            this.SourceConnectionStringControl.Location = new System.Drawing.Point(0, 0);
            this.SourceConnectionStringControl.MultiLine = false;
            this.SourceConnectionStringControl.Name = "SourceConnectionStringControl";
            this.SourceConnectionStringControl.OnTextChangedListener = null;
            this.SourceConnectionStringControl.PasswordMode = false;
            this.SourceConnectionStringControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SourceConnectionStringControl.Size = new System.Drawing.Size(1052, 32);
            this.SourceConnectionStringControl.TabIndex = 58;
            this.SourceConnectionStringControl.TextBoxBottomMargin = 0;
            this.SourceConnectionStringControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.SourceConnectionStringControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.SourceConnectionStringControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceConnectionStringControl.TextBoxTopMargin = 3;
            this.SourceConnectionStringControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // VerticalSeparator3
            // 
            this.VerticalSeparator3.BackColor = System.Drawing.Color.Transparent;
            this.VerticalSeparator3.Dock = System.Windows.Forms.DockStyle.Top;
            this.VerticalSeparator3.Location = new System.Drawing.Point(0, 184);
            this.VerticalSeparator3.Name = "VerticalSeparator3";
            this.VerticalSeparator3.Size = new System.Drawing.Size(1092, 12);
            this.VerticalSeparator3.TabIndex = 100;
            // 
            // InnerBorder
            // 
            this.InnerBorder.BackColor = System.Drawing.Color.Khaki;
            this.InnerBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.InnerBorder.Location = new System.Drawing.Point(0, 196);
            this.InnerBorder.Name = "InnerBorder";
            this.InnerBorder.Size = new System.Drawing.Size(16, 377);
            this.InnerBorder.TabIndex = 105;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.ResultsTextBox);
            this.MainPanel.Controls.Add(this.ComparisonReportLabel);
            this.MainPanel.Controls.Add(this.InnerBorder);
            this.MainPanel.Controls.Add(this.VerticalSeparator3);
            this.MainPanel.Controls.Add(this.CompareDatabaseTopPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(16, 16);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1092, 573);
            this.MainPanel.TabIndex = 102;
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResultsTextBox.Location = new System.Drawing.Point(16, 228);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultsTextBox.Size = new System.Drawing.Size(1076, 345);
            this.ResultsTextBox.TabIndex = 107;
            // 
            // ComparisonReportLabel
            // 
            this.ComparisonReportLabel.BackColor = System.Drawing.Color.Transparent;
            this.ComparisonReportLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComparisonReportLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ComparisonReportLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ComparisonReportLabel.Location = new System.Drawing.Point(16, 196);
            this.ComparisonReportLabel.Name = "ComparisonReportLabel";
            this.ComparisonReportLabel.Size = new System.Drawing.Size(1076, 32);
            this.ComparisonReportLabel.TabIndex = 106;
            this.ComparisonReportLabel.Text = "Comparison Report:";
            this.ComparisonReportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(16, 669);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(1108, 12);
            this.BottomMarginPanel.TabIndex = 26;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1124, 681);
            this.Controls.Add(this.LeftMarginPanel3);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.HiddenButton);
            this.Controls.Add(this.Separator6);
            this.Controls.Add(this.YouTubePanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.SourceTopPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1140, 720);
            this.MinimumSize = new System.Drawing.Size(1140, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Compare Version 6.1.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.YouTubePanel.ResumeLayout(false);
            this.CompareDatabaseTopPanel.ResumeLayout(false);
            this.OptionsPanel.ResumeLayout(false);
            this.RemoteComparePanel.ResumeLayout(false);
            this.IgnoreDataSyncPanel.ResumeLayout(false);
            this.TopCheckBoxPanel.ResumeLayout(false);
            this.CompareRightColumn.ResumeLayout(false);
            this.TopSectionPanel.ResumeLayout(false);
            this.TargetConnectionPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
            private System.Windows.Forms.Panel YouTubePanel;
            private System.Windows.Forms.Button YouTubeButton;
            private System.Windows.Forms.Panel panel6;
            private System.Windows.Forms.Panel Separator6;
            private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.Button HiddenButton;
        private System.Windows.Forms.Panel LeftMarginPanel3;
        private System.Windows.Forms.Panel CompareDatabaseTopPanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Panel TopCheckBoxPanel;
        private System.Windows.Forms.Button SwapButton;
        private System.Windows.Forms.Panel RightFillerPanel;
        private System.Windows.Forms.Panel Seperator4;
        private System.Windows.Forms.Panel CompareRightColumn;
        private System.Windows.Forms.Panel SeparatorPanel;
        private System.Windows.Forms.Panel ButtonTopPanel;
        private System.Windows.Forms.Panel ButtonBottomPanel;
        private System.Windows.Forms.Panel VerticalSeparator2;
        private System.Windows.Forms.Panel TopSectionPanel;
        private DataJuggler.Win.Controls.LabelTextBoxControl TargetConnectionStringControl;
        private System.Windows.Forms.Button BuildTargetConnectionStringButton;
        private System.Windows.Forms.Panel VerticalSeparator1;
        private System.Windows.Forms.Panel TargetConnectionPanel;
        private DataJuggler.Win.Controls.LabelTextBoxControl SourceConnectionStringControl;
        private System.Windows.Forms.Button BuildSourceConnectionStringButton;
        private System.Windows.Forms.Panel VerticalSeparator3;
        private System.Windows.Forms.Panel InnerBorder;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Label ComparisonReportLabel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreDiagramProceduresCheckBox;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Panel CountLeftMargin;
        private System.Windows.Forms.Button CreateXmlFileButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CompareDatabasesButton;
        private System.Windows.Forms.Panel BottomMarginPanel;
        private System.Windows.Forms.Panel IgnoreDataSyncPanel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreDataSyncCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreFirewallRulesCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl StoreConnectionStringsCheckBox;
        private System.Windows.Forms.Panel RemoteComparePanel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl CreateXmlFileCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl RemoteCompareCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreIndexesCheckBox;
        private System.Windows.Forms.Button GenerateScriptsButton;
    }
    #endregion

}
