

#region using statements

using DataJuggler.Win.Controls.Objects;

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
        private PanelExtender LeftMarginPanel;
        private PanelExtender SourceTopPanel;
        private PanelExtender RightMarginPanel;
        private PanelExtender YouTubePanel;
        private System.Windows.Forms.Button YouTubeButton;
        private PanelExtender panel6;
        private PanelExtender Separator6;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.Button HiddenButton;
        private PanelExtender CompareDatabaseTopPanel;
        private PanelExtender OptionsPanel;
        private PanelExtender TopCheckBoxPanel;
        private System.Windows.Forms.Button SwapButton;
        private PanelExtender RightFillerPanel;
        private PanelExtender Seperator4;
        private PanelExtender CompareRightColumn;
        private PanelExtender SeparatorPanel;
        private PanelExtender ButtonTopPanel;
        private PanelExtender ButtonBottomPanel;
        private PanelExtender VerticalSeparator2;
        private PanelExtender TopSectionPanel;
        private DataJuggler.Win.Controls.LabelTextBoxControl TargetConnectionStringControl;
        private System.Windows.Forms.Button BuildTargetConnectionStringButton;
        private PanelExtender VerticalSeparator1;
        private PanelExtender TargetConnectionPanel;
        private DataJuggler.Win.Controls.LabelTextBoxControl SourceConnectionStringControl;
        private System.Windows.Forms.Button BuildSourceConnectionStringButton;
        private PanelExtender VerticalSeparator3;
        private PanelExtender MainPanel;
        private System.Windows.Forms.Label ComparisonReportLabel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreDiagramProceduresCheckBox;
        private System.Windows.Forms.Label CountLabel;
        private PanelExtender CountLeftMargin;
        private System.Windows.Forms.Button CreateXmlFileButton;
        private PanelExtender panel1;
        private System.Windows.Forms.Button CompareDatabasesButton;
        private PanelExtender BottomMarginPanel;
        private PanelExtender IgnoreDataSyncPanel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreDataSyncCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreFirewallRulesCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl StoreConnectionStringsCheckBox;
        private PanelExtender RemoteComparePanel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl CreateXmlFileCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl RemoteCompareCheckBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IgnoreIndexesCheckBox;
        private DataJuggler.Win.Controls.Button GenerateScriptsButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender GraphPanel;
        private System.Windows.Forms.ProgressBar Graph;
        private System.Windows.Forms.TextBox ResultsTextBox;
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            LeftMarginPanel = new PanelExtender();
            SourceTopPanel = new PanelExtender();
            RightMarginPanel = new PanelExtender();
            YouTubePanel = new PanelExtender();
            ScriptDropExtrasCheckbox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            ExtraLabel = new System.Windows.Forms.Label();
            CopiedImage = new System.Windows.Forms.PictureBox();
            GenerateScriptsButton = new DataJuggler.Win.Controls.Button();
            CountLabel = new System.Windows.Forms.Label();
            CountLeftMargin = new PanelExtender();
            YouTubeButton = new System.Windows.Forms.Button();
            panel6 = new PanelExtender();
            Separator6 = new PanelExtender();
            MainToolTip = new System.Windows.Forms.ToolTip(components);
            HiddenButton = new System.Windows.Forms.Button();
            BuildSourceConnectionStringButton = new System.Windows.Forms.Button();
            BuildTargetConnectionStringButton = new System.Windows.Forms.Button();
            SwapButton = new System.Windows.Forms.Button();
            CompareDatabasesButton = new System.Windows.Forms.Button();
            CreateXmlFileButton = new System.Windows.Forms.Button();
            CompareDatabaseTopPanel = new PanelExtender();
            OptionsPanel = new PanelExtender();
            RemoteComparePanel = new PanelExtender();
            CreateXmlFileCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            RemoteCompareCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            IgnoreDataSyncPanel = new PanelExtender();
            IgnoreFirewallRulesCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            IgnoreDataSyncCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            TopCheckBoxPanel = new PanelExtender();
            IgnoreIndexesCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            StoreConnectionStringsCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            IgnoreDiagramProceduresCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            RightFillerPanel = new PanelExtender();
            Seperator4 = new PanelExtender();
            CompareRightColumn = new PanelExtender();
            panel1 = new PanelExtender();
            SeparatorPanel = new PanelExtender();
            ButtonTopPanel = new PanelExtender();
            ButtonBottomPanel = new PanelExtender();
            VerticalSeparator2 = new PanelExtender();
            TopSectionPanel = new PanelExtender();
            TargetConnectionStringControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            VerticalSeparator1 = new PanelExtender();
            TargetConnectionPanel = new PanelExtender();
            SourceConnectionStringControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            VerticalSeparator3 = new PanelExtender();
            MainPanel = new PanelExtender();
            ResultsTextBox = new System.Windows.Forms.TextBox();
            GraphPanel = new PanelExtender();
            Graph = new System.Windows.Forms.ProgressBar();
            ComparisonReportLabel = new System.Windows.Forms.Label();
            InnerBorder = new PanelExtender();
            BottomMarginPanel = new PanelExtender();
            CopiedTimer = new System.Windows.Forms.Timer(components);
            IgnoreDifferenceStrip = new System.Windows.Forms.ContextMenuStrip(components);
            IgnoreItem = new System.Windows.Forms.ToolStripMenuItem();
            ClearItem = new System.Windows.Forms.ToolStripMenuItem();
            YouTubePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CopiedImage).BeginInit();
            CompareDatabaseTopPanel.SuspendLayout();
            OptionsPanel.SuspendLayout();
            RemoteComparePanel.SuspendLayout();
            IgnoreDataSyncPanel.SuspendLayout();
            TopCheckBoxPanel.SuspendLayout();
            CompareRightColumn.SuspendLayout();
            TopSectionPanel.SuspendLayout();
            TargetConnectionPanel.SuspendLayout();
            MainPanel.SuspendLayout();
            GraphPanel.SuspendLayout();
            IgnoreDifferenceStrip.SuspendLayout();
            SuspendLayout();
            // 
            // LeftMarginPanel
            // 
            LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            LeftMarginPanel.Name = "LeftMarginPanel";
            LeftMarginPanel.Size = new System.Drawing.Size(12, 701);
            LeftMarginPanel.TabIndex = 24;
            // 
            // SourceTopPanel
            // 
            SourceTopPanel.BackColor = System.Drawing.Color.Transparent;
            SourceTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            SourceTopPanel.Location = new System.Drawing.Point(12, 0);
            SourceTopPanel.Name = "SourceTopPanel";
            SourceTopPanel.Size = new System.Drawing.Size(1212, 16);
            SourceTopPanel.TabIndex = 48;
            // 
            // RightMarginPanel
            // 
            RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            RightMarginPanel.Location = new System.Drawing.Point(1212, 16);
            RightMarginPanel.Name = "RightMarginPanel";
            RightMarginPanel.Size = new System.Drawing.Size(12, 673);
            RightMarginPanel.TabIndex = 55;
            // 
            // YouTubePanel
            // 
            YouTubePanel.BackColor = System.Drawing.Color.Transparent;
            YouTubePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            YouTubePanel.Controls.Add(ScriptDropExtrasCheckbox);
            YouTubePanel.Controls.Add(ExtraLabel);
            YouTubePanel.Controls.Add(CopiedImage);
            YouTubePanel.Controls.Add(GenerateScriptsButton);
            YouTubePanel.Controls.Add(CountLabel);
            YouTubePanel.Controls.Add(CountLeftMargin);
            YouTubePanel.Controls.Add(YouTubeButton);
            YouTubePanel.Controls.Add(panel6);
            YouTubePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            YouTubePanel.Location = new System.Drawing.Point(12, 601);
            YouTubePanel.Name = "YouTubePanel";
            YouTubePanel.Size = new System.Drawing.Size(1200, 88);
            YouTubePanel.TabIndex = 85;
            // 
            // ScriptDropExtrasCheckbox
            // 
            ScriptDropExtrasCheckbox.BackColor = System.Drawing.Color.Transparent;
            ScriptDropExtrasCheckbox.CheckBoxHorizontalOffSet = 0;
            ScriptDropExtrasCheckbox.CheckBoxVerticalOffSet = 2;
            ScriptDropExtrasCheckbox.CheckChangedListener = null;
            ScriptDropExtrasCheckbox.Checked = false;
            ScriptDropExtrasCheckbox.Editable = true;
            ScriptDropExtrasCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ScriptDropExtrasCheckbox.LabelColor = System.Drawing.Color.LemonChiffon;
            ScriptDropExtrasCheckbox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ScriptDropExtrasCheckbox.LabelText = "Script Drop Extras:";
            ScriptDropExtrasCheckbox.LabelWidth = 220;
            ScriptDropExtrasCheckbox.Location = new System.Drawing.Point(97, 58);
            ScriptDropExtrasCheckbox.MaximumSize = new System.Drawing.Size(232, 30);
            ScriptDropExtrasCheckbox.MinimumSize = new System.Drawing.Size(232, 30);
            ScriptDropExtrasCheckbox.Name = "ScriptDropExtrasCheckbox";
            ScriptDropExtrasCheckbox.Size = new System.Drawing.Size(232, 30);
            ScriptDropExtrasCheckbox.TabIndex = 104;
            ScriptDropExtrasCheckbox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            ScriptDropExtrasCheckbox.Visible = false;
            // 
            // ExtraLabel
            // 
            ExtraLabel.AutoSize = true;
            ExtraLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            ExtraLabel.Location = new System.Drawing.Point(334, 63);
            ExtraLabel.Name = "ExtraLabel";
            ExtraLabel.Size = new System.Drawing.Size(607, 36);
            ExtraLabel.TabIndex = 105;
            ExtraLabel.Text = "If checked, extra objects found in the target db will be scripted for drop.\r\n\r\n";
            ExtraLabel.Visible = false;
            // 
            // CopiedImage
            // 
            CopiedImage.BackgroundImage = Properties.Resources.Copied;
            CopiedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            CopiedImage.Location = new System.Drawing.Point(360, 1);
            CopiedImage.Name = "CopiedImage";
            CopiedImage.Size = new System.Drawing.Size(124, 50);
            CopiedImage.TabIndex = 103;
            CopiedImage.TabStop = false;
            CopiedImage.Visible = false;
            // 
            // GenerateScriptsButton
            // 
            GenerateScriptsButton.BackColor = System.Drawing.Color.Transparent;
            GenerateScriptsButton.ButtonText = "Generate Scripts";
            GenerateScriptsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GenerateScriptsButton.ForeColor = System.Drawing.Color.LemonChiffon;
            GenerateScriptsButton.Location = new System.Drawing.Point(161, 4);
            GenerateScriptsButton.Margin = new System.Windows.Forms.Padding(4);
            GenerateScriptsButton.Name = "GenerateScriptsButton";
            GenerateScriptsButton.Size = new System.Drawing.Size(168, 44);
            GenerateScriptsButton.TabIndex = 102;
            GenerateScriptsButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            GenerateScriptsButton.Visible = false;
            GenerateScriptsButton.Click += GenerateScriptsButton_Click;
            // 
            // CountLabel
            // 
            CountLabel.BackColor = System.Drawing.Color.Transparent;
            CountLabel.Dock = System.Windows.Forms.DockStyle.Left;
            CountLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CountLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            CountLabel.Location = new System.Drawing.Point(16, 4);
            CountLabel.Name = "CountLabel";
            CountLabel.Size = new System.Drawing.Size(126, 84);
            CountLabel.TabIndex = 88;
            CountLabel.Text = "Count: 0";
            CountLabel.Visible = false;
            // 
            // CountLeftMargin
            // 
            CountLeftMargin.Dock = System.Windows.Forms.DockStyle.Left;
            CountLeftMargin.Location = new System.Drawing.Point(0, 4);
            CountLeftMargin.Name = "CountLeftMargin";
            CountLeftMargin.Size = new System.Drawing.Size(16, 84);
            CountLeftMargin.TabIndex = 87;
            // 
            // YouTubeButton
            // 
            YouTubeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("YouTubeButton.BackgroundImage");
            YouTubeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            YouTubeButton.Dock = System.Windows.Forms.DockStyle.Right;
            YouTubeButton.FlatAppearance.BorderSize = 0;
            YouTubeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            YouTubeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            YouTubeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            YouTubeButton.Location = new System.Drawing.Point(1072, 4);
            YouTubeButton.MaximumSize = new System.Drawing.Size(128, 64);
            YouTubeButton.Name = "YouTubeButton";
            YouTubeButton.Size = new System.Drawing.Size(128, 64);
            YouTubeButton.TabIndex = 84;
            YouTubeButton.UseVisualStyleBackColor = true;
            YouTubeButton.Click += YouTubeButton_Click;
            YouTubeButton.MouseEnter += Button_MouseEnter;
            YouTubeButton.MouseLeave += Button_MouseLeave;
            // 
            // panel6
            // 
            panel6.BackColor = System.Drawing.Color.Transparent;
            panel6.Dock = System.Windows.Forms.DockStyle.Top;
            panel6.Location = new System.Drawing.Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(1200, 4);
            panel6.TabIndex = 78;
            // 
            // Separator6
            // 
            Separator6.BackColor = System.Drawing.Color.Transparent;
            Separator6.Dock = System.Windows.Forms.DockStyle.Bottom;
            Separator6.Location = new System.Drawing.Point(12, 589);
            Separator6.Name = "Separator6";
            Separator6.Size = new System.Drawing.Size(1200, 12);
            Separator6.TabIndex = 87;
            // 
            // HiddenButton
            // 
            HiddenButton.BackColor = System.Drawing.Color.Transparent;
            HiddenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            HiddenButton.FlatAppearance.BorderSize = 0;
            HiddenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            HiddenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            HiddenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            HiddenButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            HiddenButton.ForeColor = System.Drawing.Color.White;
            HiddenButton.Location = new System.Drawing.Point(-300, 300);
            HiddenButton.MaximumSize = new System.Drawing.Size(220, 36);
            HiddenButton.MinimumSize = new System.Drawing.Size(220, 36);
            HiddenButton.Name = "HiddenButton";
            HiddenButton.Size = new System.Drawing.Size(220, 36);
            HiddenButton.TabIndex = 96;
            HiddenButton.Text = "Create Xml File";
            MainToolTip.SetToolTip(HiddenButton, "Perform the database comparison");
            HiddenButton.UseVisualStyleBackColor = false;
            HiddenButton.Visible = false;
            // 
            // BuildSourceConnectionStringButton
            // 
            BuildSourceConnectionStringButton.BackColor = System.Drawing.Color.Transparent;
            BuildSourceConnectionStringButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("BuildSourceConnectionStringButton.BackgroundImage");
            BuildSourceConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            BuildSourceConnectionStringButton.Dock = System.Windows.Forms.DockStyle.Right;
            BuildSourceConnectionStringButton.FlatAppearance.BorderSize = 0;
            BuildSourceConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            BuildSourceConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            BuildSourceConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            BuildSourceConnectionStringButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BuildSourceConnectionStringButton.ForeColor = System.Drawing.Color.LemonChiffon;
            BuildSourceConnectionStringButton.Location = new System.Drawing.Point(1160, 0);
            BuildSourceConnectionStringButton.Margin = new System.Windows.Forms.Padding(0);
            BuildSourceConnectionStringButton.MaximumSize = new System.Drawing.Size(40, 0);
            BuildSourceConnectionStringButton.Name = "BuildSourceConnectionStringButton";
            BuildSourceConnectionStringButton.Size = new System.Drawing.Size(40, 32);
            BuildSourceConnectionStringButton.TabIndex = 57;
            BuildSourceConnectionStringButton.Text = "...";
            MainToolTip.SetToolTip(BuildSourceConnectionStringButton, "Set the source connection string");
            BuildSourceConnectionStringButton.UseVisualStyleBackColor = false;
            BuildSourceConnectionStringButton.Click += BuildSourceConnectionStringButton_Click;
            BuildSourceConnectionStringButton.MouseEnter += Button_MouseEnter;
            BuildSourceConnectionStringButton.MouseLeave += Button_MouseLeave;
            // 
            // BuildTargetConnectionStringButton
            // 
            BuildTargetConnectionStringButton.BackColor = System.Drawing.Color.Transparent;
            BuildTargetConnectionStringButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("BuildTargetConnectionStringButton.BackgroundImage");
            BuildTargetConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            BuildTargetConnectionStringButton.Dock = System.Windows.Forms.DockStyle.Right;
            BuildTargetConnectionStringButton.FlatAppearance.BorderSize = 0;
            BuildTargetConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            BuildTargetConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            BuildTargetConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            BuildTargetConnectionStringButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BuildTargetConnectionStringButton.ForeColor = System.Drawing.Color.LemonChiffon;
            BuildTargetConnectionStringButton.Location = new System.Drawing.Point(1160, 0);
            BuildTargetConnectionStringButton.Margin = new System.Windows.Forms.Padding(0);
            BuildTargetConnectionStringButton.MaximumSize = new System.Drawing.Size(40, 0);
            BuildTargetConnectionStringButton.Name = "BuildTargetConnectionStringButton";
            BuildTargetConnectionStringButton.Size = new System.Drawing.Size(40, 32);
            BuildTargetConnectionStringButton.TabIndex = 59;
            BuildTargetConnectionStringButton.Text = "...";
            MainToolTip.SetToolTip(BuildTargetConnectionStringButton, "Set the target connection string");
            BuildTargetConnectionStringButton.UseVisualStyleBackColor = false;
            BuildTargetConnectionStringButton.Click += BuildTargetConnectionStringButton_Click;
            BuildTargetConnectionStringButton.MouseEnter += Button_MouseEnter;
            BuildTargetConnectionStringButton.MouseLeave += Button_MouseLeave;
            // 
            // SwapButton
            // 
            SwapButton.BackColor = System.Drawing.Color.Transparent;
            SwapButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("SwapButton.BackgroundImage");
            SwapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SwapButton.Dock = System.Windows.Forms.DockStyle.Right;
            SwapButton.FlatAppearance.BorderSize = 0;
            SwapButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            SwapButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            SwapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SwapButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            SwapButton.Location = new System.Drawing.Point(904, 4);
            SwapButton.Margin = new System.Windows.Forms.Padding(0);
            SwapButton.MaximumSize = new System.Drawing.Size(64, 64);
            SwapButton.MinimumSize = new System.Drawing.Size(64, 64);
            SwapButton.Name = "SwapButton";
            SwapButton.Size = new System.Drawing.Size(64, 64);
            SwapButton.TabIndex = 81;
            MainToolTip.SetToolTip(SwapButton, "Swap the source and target connection strings");
            SwapButton.UseVisualStyleBackColor = false;
            SwapButton.Click += SwapButton_Click;
            SwapButton.MouseEnter += Button_MouseEnter;
            SwapButton.MouseLeave += Button_MouseLeave;
            // 
            // CompareDatabasesButton
            // 
            CompareDatabasesButton.BackColor = System.Drawing.Color.Transparent;
            CompareDatabasesButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("CompareDatabasesButton.BackgroundImage");
            CompareDatabasesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            CompareDatabasesButton.Dock = System.Windows.Forms.DockStyle.Top;
            CompareDatabasesButton.FlatAppearance.BorderSize = 0;
            CompareDatabasesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            CompareDatabasesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            CompareDatabasesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CompareDatabasesButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CompareDatabasesButton.ForeColor = System.Drawing.Color.LemonChiffon;
            CompareDatabasesButton.Location = new System.Drawing.Point(0, 9);
            CompareDatabasesButton.MaximumSize = new System.Drawing.Size(220, 34);
            CompareDatabasesButton.MinimumSize = new System.Drawing.Size(220, 34);
            CompareDatabasesButton.Name = "CompareDatabasesButton";
            CompareDatabasesButton.Size = new System.Drawing.Size(220, 34);
            CompareDatabasesButton.TabIndex = 96;
            CompareDatabasesButton.Text = "Compare Databases";
            MainToolTip.SetToolTip(CompareDatabasesButton, "Perform the database comparison");
            CompareDatabasesButton.UseVisualStyleBackColor = false;
            CompareDatabasesButton.Click += CompareDatabasesButton_Click;
            CompareDatabasesButton.MouseEnter += Button_MouseEnter;
            CompareDatabasesButton.MouseLeave += Button_MouseLeave;
            // 
            // CreateXmlFileButton
            // 
            CreateXmlFileButton.BackColor = System.Drawing.Color.Transparent;
            CreateXmlFileButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("CreateXmlFileButton.BackgroundImage");
            CreateXmlFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            CreateXmlFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            CreateXmlFileButton.FlatAppearance.BorderSize = 0;
            CreateXmlFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            CreateXmlFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            CreateXmlFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreateXmlFileButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CreateXmlFileButton.ForeColor = System.Drawing.Color.LemonChiffon;
            CreateXmlFileButton.Location = new System.Drawing.Point(0, 55);
            CreateXmlFileButton.MaximumSize = new System.Drawing.Size(220, 34);
            CreateXmlFileButton.MinimumSize = new System.Drawing.Size(220, 34);
            CreateXmlFileButton.Name = "CreateXmlFileButton";
            CreateXmlFileButton.Size = new System.Drawing.Size(220, 34);
            CreateXmlFileButton.TabIndex = 99;
            CreateXmlFileButton.Text = "Create Xml File";
            MainToolTip.SetToolTip(CreateXmlFileButton, "Perform the database comparison");
            CreateXmlFileButton.UseVisualStyleBackColor = false;
            CreateXmlFileButton.Visible = false;
            CreateXmlFileButton.Click += CreateXmlFileButton_Click;
            CreateXmlFileButton.MouseEnter += Button_MouseEnter;
            CreateXmlFileButton.MouseLeave += Button_MouseLeave;
            // 
            // CompareDatabaseTopPanel
            // 
            CompareDatabaseTopPanel.BackColor = System.Drawing.Color.Transparent;
            CompareDatabaseTopPanel.Controls.Add(OptionsPanel);
            CompareDatabaseTopPanel.Controls.Add(VerticalSeparator2);
            CompareDatabaseTopPanel.Controls.Add(TopSectionPanel);
            CompareDatabaseTopPanel.Controls.Add(VerticalSeparator1);
            CompareDatabaseTopPanel.Controls.Add(TargetConnectionPanel);
            CompareDatabaseTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            CompareDatabaseTopPanel.Location = new System.Drawing.Point(0, 0);
            CompareDatabaseTopPanel.Name = "CompareDatabaseTopPanel";
            CompareDatabaseTopPanel.Size = new System.Drawing.Size(1200, 184);
            CompareDatabaseTopPanel.TabIndex = 99;
            // 
            // OptionsPanel
            // 
            OptionsPanel.BackColor = System.Drawing.Color.Transparent;
            OptionsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            OptionsPanel.Controls.Add(RemoteComparePanel);
            OptionsPanel.Controls.Add(IgnoreDataSyncPanel);
            OptionsPanel.Controls.Add(TopCheckBoxPanel);
            OptionsPanel.Controls.Add(SwapButton);
            OptionsPanel.Controls.Add(RightFillerPanel);
            OptionsPanel.Controls.Add(Seperator4);
            OptionsPanel.Controls.Add(CompareRightColumn);
            OptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            OptionsPanel.Location = new System.Drawing.Point(0, 88);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new System.Drawing.Size(1200, 96);
            OptionsPanel.TabIndex = 69;
            // 
            // RemoteComparePanel
            // 
            RemoteComparePanel.Controls.Add(CreateXmlFileCheckBox);
            RemoteComparePanel.Controls.Add(RemoteCompareCheckBox);
            RemoteComparePanel.Dock = System.Windows.Forms.DockStyle.Top;
            RemoteComparePanel.Location = new System.Drawing.Point(0, 66);
            RemoteComparePanel.MaximumSize = new System.Drawing.Size(780, 64);
            RemoteComparePanel.Name = "RemoteComparePanel";
            RemoteComparePanel.Size = new System.Drawing.Size(780, 32);
            RemoteComparePanel.TabIndex = 90;
            // 
            // CreateXmlFileCheckBox
            // 
            CreateXmlFileCheckBox.BackColor = System.Drawing.Color.Transparent;
            CreateXmlFileCheckBox.CheckBoxHorizontalOffSet = 0;
            CreateXmlFileCheckBox.CheckBoxVerticalOffSet = 2;
            CreateXmlFileCheckBox.CheckChangedListener = null;
            CreateXmlFileCheckBox.Checked = false;
            CreateXmlFileCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            CreateXmlFileCheckBox.Editable = true;
            CreateXmlFileCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CreateXmlFileCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            CreateXmlFileCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CreateXmlFileCheckBox.LabelText = "Create Xml File:";
            CreateXmlFileCheckBox.LabelWidth = 220;
            CreateXmlFileCheckBox.Location = new System.Drawing.Point(300, 0);
            CreateXmlFileCheckBox.MaximumSize = new System.Drawing.Size(232, 30);
            CreateXmlFileCheckBox.MinimumSize = new System.Drawing.Size(232, 30);
            CreateXmlFileCheckBox.Name = "CreateXmlFileCheckBox";
            CreateXmlFileCheckBox.Size = new System.Drawing.Size(232, 30);
            CreateXmlFileCheckBox.TabIndex = 98;
            CreateXmlFileCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // RemoteCompareCheckBox
            // 
            RemoteCompareCheckBox.BackColor = System.Drawing.Color.Transparent;
            RemoteCompareCheckBox.CheckBoxHorizontalOffSet = 0;
            RemoteCompareCheckBox.CheckBoxVerticalOffSet = 2;
            RemoteCompareCheckBox.CheckChangedListener = null;
            RemoteCompareCheckBox.Checked = false;
            RemoteCompareCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            RemoteCompareCheckBox.Editable = true;
            RemoteCompareCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RemoteCompareCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            RemoteCompareCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            RemoteCompareCheckBox.LabelText = "Remote Compare:";
            RemoteCompareCheckBox.LabelWidth = 280;
            RemoteCompareCheckBox.Location = new System.Drawing.Point(0, 0);
            RemoteCompareCheckBox.MaximumSize = new System.Drawing.Size(300, 32);
            RemoteCompareCheckBox.MinimumSize = new System.Drawing.Size(300, 32);
            RemoteCompareCheckBox.Name = "RemoteCompareCheckBox";
            RemoteCompareCheckBox.Size = new System.Drawing.Size(300, 32);
            RemoteCompareCheckBox.TabIndex = 97;
            RemoteCompareCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // IgnoreDataSyncPanel
            // 
            IgnoreDataSyncPanel.Controls.Add(IgnoreFirewallRulesCheckBox);
            IgnoreDataSyncPanel.Controls.Add(IgnoreDataSyncCheckBox);
            IgnoreDataSyncPanel.Dock = System.Windows.Forms.DockStyle.Top;
            IgnoreDataSyncPanel.Location = new System.Drawing.Point(0, 34);
            IgnoreDataSyncPanel.MaximumSize = new System.Drawing.Size(780, 64);
            IgnoreDataSyncPanel.Name = "IgnoreDataSyncPanel";
            IgnoreDataSyncPanel.Size = new System.Drawing.Size(780, 32);
            IgnoreDataSyncPanel.TabIndex = 89;
            // 
            // IgnoreFirewallRulesCheckBox
            // 
            IgnoreFirewallRulesCheckBox.BackColor = System.Drawing.Color.Transparent;
            IgnoreFirewallRulesCheckBox.CheckBoxHorizontalOffSet = 0;
            IgnoreFirewallRulesCheckBox.CheckBoxVerticalOffSet = 2;
            IgnoreFirewallRulesCheckBox.CheckChangedListener = null;
            IgnoreFirewallRulesCheckBox.Checked = true;
            IgnoreFirewallRulesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            IgnoreFirewallRulesCheckBox.Editable = true;
            IgnoreFirewallRulesCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IgnoreFirewallRulesCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            IgnoreFirewallRulesCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            IgnoreFirewallRulesCheckBox.LabelText = "Ignore Firewall Rules:";
            IgnoreFirewallRulesCheckBox.LabelWidth = 220;
            IgnoreFirewallRulesCheckBox.Location = new System.Drawing.Point(300, 0);
            IgnoreFirewallRulesCheckBox.MaximumSize = new System.Drawing.Size(232, 32);
            IgnoreFirewallRulesCheckBox.MinimumSize = new System.Drawing.Size(232, 32);
            IgnoreFirewallRulesCheckBox.Name = "IgnoreFirewallRulesCheckBox";
            IgnoreFirewallRulesCheckBox.Size = new System.Drawing.Size(232, 32);
            IgnoreFirewallRulesCheckBox.TabIndex = 98;
            IgnoreFirewallRulesCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // IgnoreDataSyncCheckBox
            // 
            IgnoreDataSyncCheckBox.BackColor = System.Drawing.Color.Transparent;
            IgnoreDataSyncCheckBox.CheckBoxHorizontalOffSet = 0;
            IgnoreDataSyncCheckBox.CheckBoxVerticalOffSet = 2;
            IgnoreDataSyncCheckBox.CheckChangedListener = null;
            IgnoreDataSyncCheckBox.Checked = true;
            IgnoreDataSyncCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            IgnoreDataSyncCheckBox.Editable = true;
            IgnoreDataSyncCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IgnoreDataSyncCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            IgnoreDataSyncCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            IgnoreDataSyncCheckBox.LabelText = "Ignore SQL DataSync:";
            IgnoreDataSyncCheckBox.LabelWidth = 280;
            IgnoreDataSyncCheckBox.Location = new System.Drawing.Point(0, 0);
            IgnoreDataSyncCheckBox.MaximumSize = new System.Drawing.Size(300, 32);
            IgnoreDataSyncCheckBox.MinimumSize = new System.Drawing.Size(300, 32);
            IgnoreDataSyncCheckBox.Name = "IgnoreDataSyncCheckBox";
            IgnoreDataSyncCheckBox.Size = new System.Drawing.Size(300, 32);
            IgnoreDataSyncCheckBox.TabIndex = 97;
            IgnoreDataSyncCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // TopCheckBoxPanel
            // 
            TopCheckBoxPanel.Controls.Add(IgnoreIndexesCheckBox);
            TopCheckBoxPanel.Controls.Add(StoreConnectionStringsCheckBox);
            TopCheckBoxPanel.Controls.Add(IgnoreDiagramProceduresCheckBox);
            TopCheckBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            TopCheckBoxPanel.Location = new System.Drawing.Point(0, 4);
            TopCheckBoxPanel.MaximumSize = new System.Drawing.Size(780, 30);
            TopCheckBoxPanel.Name = "TopCheckBoxPanel";
            TopCheckBoxPanel.Size = new System.Drawing.Size(780, 30);
            TopCheckBoxPanel.TabIndex = 87;
            // 
            // IgnoreIndexesCheckBox
            // 
            IgnoreIndexesCheckBox.BackColor = System.Drawing.Color.Transparent;
            IgnoreIndexesCheckBox.CheckBoxHorizontalOffSet = 0;
            IgnoreIndexesCheckBox.CheckBoxVerticalOffSet = 2;
            IgnoreIndexesCheckBox.CheckChangedListener = null;
            IgnoreIndexesCheckBox.Checked = false;
            IgnoreIndexesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            IgnoreIndexesCheckBox.Editable = true;
            IgnoreIndexesCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IgnoreIndexesCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            IgnoreIndexesCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            IgnoreIndexesCheckBox.LabelText = "Ignore Indexes";
            IgnoreIndexesCheckBox.LabelWidth = 220;
            IgnoreIndexesCheckBox.Location = new System.Drawing.Point(532, 0);
            IgnoreIndexesCheckBox.MaximumSize = new System.Drawing.Size(232, 32);
            IgnoreIndexesCheckBox.MinimumSize = new System.Drawing.Size(232, 32);
            IgnoreIndexesCheckBox.Name = "IgnoreIndexesCheckBox";
            IgnoreIndexesCheckBox.Size = new System.Drawing.Size(232, 32);
            IgnoreIndexesCheckBox.TabIndex = 98;
            IgnoreIndexesCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // StoreConnectionStringsCheckBox
            // 
            StoreConnectionStringsCheckBox.BackColor = System.Drawing.Color.Transparent;
            StoreConnectionStringsCheckBox.CheckBoxHorizontalOffSet = 0;
            StoreConnectionStringsCheckBox.CheckBoxVerticalOffSet = 2;
            StoreConnectionStringsCheckBox.CheckChangedListener = null;
            StoreConnectionStringsCheckBox.Checked = true;
            StoreConnectionStringsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            StoreConnectionStringsCheckBox.Editable = true;
            StoreConnectionStringsCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StoreConnectionStringsCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            StoreConnectionStringsCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            StoreConnectionStringsCheckBox.LabelText = "Store Conn Strings:";
            StoreConnectionStringsCheckBox.LabelWidth = 220;
            StoreConnectionStringsCheckBox.Location = new System.Drawing.Point(300, 0);
            StoreConnectionStringsCheckBox.MaximumSize = new System.Drawing.Size(232, 32);
            StoreConnectionStringsCheckBox.MinimumSize = new System.Drawing.Size(232, 32);
            StoreConnectionStringsCheckBox.Name = "StoreConnectionStringsCheckBox";
            StoreConnectionStringsCheckBox.Size = new System.Drawing.Size(232, 32);
            StoreConnectionStringsCheckBox.TabIndex = 97;
            StoreConnectionStringsCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // IgnoreDiagramProceduresCheckBox
            // 
            IgnoreDiagramProceduresCheckBox.BackColor = System.Drawing.Color.Transparent;
            IgnoreDiagramProceduresCheckBox.CheckBoxHorizontalOffSet = 0;
            IgnoreDiagramProceduresCheckBox.CheckBoxVerticalOffSet = 2;
            IgnoreDiagramProceduresCheckBox.CheckChangedListener = null;
            IgnoreDiagramProceduresCheckBox.Checked = true;
            IgnoreDiagramProceduresCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            IgnoreDiagramProceduresCheckBox.Editable = true;
            IgnoreDiagramProceduresCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IgnoreDiagramProceduresCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            IgnoreDiagramProceduresCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            IgnoreDiagramProceduresCheckBox.LabelText = "Ignore Diagram Procedures:";
            IgnoreDiagramProceduresCheckBox.LabelWidth = 280;
            IgnoreDiagramProceduresCheckBox.Location = new System.Drawing.Point(0, 0);
            IgnoreDiagramProceduresCheckBox.MaximumSize = new System.Drawing.Size(300, 32);
            IgnoreDiagramProceduresCheckBox.MinimumSize = new System.Drawing.Size(300, 32);
            IgnoreDiagramProceduresCheckBox.Name = "IgnoreDiagramProceduresCheckBox";
            IgnoreDiagramProceduresCheckBox.Size = new System.Drawing.Size(300, 32);
            IgnoreDiagramProceduresCheckBox.TabIndex = 94;
            IgnoreDiagramProceduresCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // RightFillerPanel
            // 
            RightFillerPanel.BackColor = System.Drawing.Color.Transparent;
            RightFillerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            RightFillerPanel.Location = new System.Drawing.Point(968, 4);
            RightFillerPanel.Name = "RightFillerPanel";
            RightFillerPanel.Size = new System.Drawing.Size(12, 92);
            RightFillerPanel.TabIndex = 80;
            // 
            // Seperator4
            // 
            Seperator4.BackColor = System.Drawing.Color.Transparent;
            Seperator4.Dock = System.Windows.Forms.DockStyle.Top;
            Seperator4.Location = new System.Drawing.Point(0, 0);
            Seperator4.Name = "Seperator4";
            Seperator4.Size = new System.Drawing.Size(980, 4);
            Seperator4.TabIndex = 78;
            // 
            // CompareRightColumn
            // 
            CompareRightColumn.Controls.Add(CreateXmlFileButton);
            CompareRightColumn.Controls.Add(panel1);
            CompareRightColumn.Controls.Add(CompareDatabasesButton);
            CompareRightColumn.Controls.Add(SeparatorPanel);
            CompareRightColumn.Controls.Add(ButtonTopPanel);
            CompareRightColumn.Controls.Add(ButtonBottomPanel);
            CompareRightColumn.Dock = System.Windows.Forms.DockStyle.Right;
            CompareRightColumn.Location = new System.Drawing.Point(980, 0);
            CompareRightColumn.Name = "CompareRightColumn";
            CompareRightColumn.Size = new System.Drawing.Size(220, 96);
            CompareRightColumn.TabIndex = 62;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 43);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(220, 12);
            panel1.TabIndex = 98;
            // 
            // SeparatorPanel
            // 
            SeparatorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            SeparatorPanel.Location = new System.Drawing.Point(0, 5);
            SeparatorPanel.Name = "SeparatorPanel";
            SeparatorPanel.Size = new System.Drawing.Size(220, 4);
            SeparatorPanel.TabIndex = 93;
            // 
            // ButtonTopPanel
            // 
            ButtonTopPanel.BackColor = System.Drawing.Color.Transparent;
            ButtonTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            ButtonTopPanel.Location = new System.Drawing.Point(0, 0);
            ButtonTopPanel.Name = "ButtonTopPanel";
            ButtonTopPanel.Size = new System.Drawing.Size(220, 5);
            ButtonTopPanel.TabIndex = 62;
            // 
            // ButtonBottomPanel
            // 
            ButtonBottomPanel.BackColor = System.Drawing.Color.Transparent;
            ButtonBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            ButtonBottomPanel.Location = new System.Drawing.Point(0, 94);
            ButtonBottomPanel.Name = "ButtonBottomPanel";
            ButtonBottomPanel.Size = new System.Drawing.Size(220, 2);
            ButtonBottomPanel.TabIndex = 61;
            // 
            // VerticalSeparator2
            // 
            VerticalSeparator2.BackColor = System.Drawing.Color.Transparent;
            VerticalSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            VerticalSeparator2.Location = new System.Drawing.Point(0, 76);
            VerticalSeparator2.Name = "VerticalSeparator2";
            VerticalSeparator2.Size = new System.Drawing.Size(1200, 12);
            VerticalSeparator2.TabIndex = 68;
            // 
            // TopSectionPanel
            // 
            TopSectionPanel.BackColor = System.Drawing.Color.Transparent;
            TopSectionPanel.Controls.Add(TargetConnectionStringControl);
            TopSectionPanel.Controls.Add(BuildTargetConnectionStringButton);
            TopSectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            TopSectionPanel.Location = new System.Drawing.Point(0, 44);
            TopSectionPanel.Name = "TopSectionPanel";
            TopSectionPanel.Size = new System.Drawing.Size(1200, 32);
            TopSectionPanel.TabIndex = 60;
            // 
            // TargetConnectionStringControl
            // 
            TargetConnectionStringControl.BackColor = System.Drawing.Color.Transparent;
            TargetConnectionStringControl.BottomMargin = 0;
            TargetConnectionStringControl.Dock = System.Windows.Forms.DockStyle.Top;
            TargetConnectionStringControl.Editable = true;
            TargetConnectionStringControl.Encrypted = false;
            TargetConnectionStringControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TargetConnectionStringControl.Inititialized = true;
            TargetConnectionStringControl.LabelBottomMargin = 2;
            TargetConnectionStringControl.LabelColor = System.Drawing.Color.LemonChiffon;
            TargetConnectionStringControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TargetConnectionStringControl.LabelText = "Target Conn. String:";
            TargetConnectionStringControl.LabelTopMargin = 4;
            TargetConnectionStringControl.LabelWidth = 208;
            TargetConnectionStringControl.Location = new System.Drawing.Point(0, 0);
            TargetConnectionStringControl.MultiLine = false;
            TargetConnectionStringControl.Name = "TargetConnectionStringControl";
            TargetConnectionStringControl.OnTextChangedListener = null;
            TargetConnectionStringControl.PasswordMode = false;
            TargetConnectionStringControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            TargetConnectionStringControl.Size = new System.Drawing.Size(1160, 32);
            TargetConnectionStringControl.TabIndex = 60;
            TargetConnectionStringControl.TextBoxBottomMargin = 0;
            TargetConnectionStringControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            TargetConnectionStringControl.TextBoxEditableColor = System.Drawing.Color.White;
            TargetConnectionStringControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TargetConnectionStringControl.TextBoxTopMargin = 6;
            TargetConnectionStringControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // VerticalSeparator1
            // 
            VerticalSeparator1.BackColor = System.Drawing.Color.Transparent;
            VerticalSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            VerticalSeparator1.Location = new System.Drawing.Point(0, 32);
            VerticalSeparator1.Name = "VerticalSeparator1";
            VerticalSeparator1.Size = new System.Drawing.Size(1200, 12);
            VerticalSeparator1.TabIndex = 59;
            // 
            // TargetConnectionPanel
            // 
            TargetConnectionPanel.BackColor = System.Drawing.Color.Transparent;
            TargetConnectionPanel.Controls.Add(SourceConnectionStringControl);
            TargetConnectionPanel.Controls.Add(BuildSourceConnectionStringButton);
            TargetConnectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            TargetConnectionPanel.Location = new System.Drawing.Point(0, 0);
            TargetConnectionPanel.Name = "TargetConnectionPanel";
            TargetConnectionPanel.Size = new System.Drawing.Size(1200, 32);
            TargetConnectionPanel.TabIndex = 57;
            // 
            // SourceConnectionStringControl
            // 
            SourceConnectionStringControl.BackColor = System.Drawing.Color.Transparent;
            SourceConnectionStringControl.BottomMargin = 0;
            SourceConnectionStringControl.Dock = System.Windows.Forms.DockStyle.Top;
            SourceConnectionStringControl.Editable = true;
            SourceConnectionStringControl.Encrypted = false;
            SourceConnectionStringControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SourceConnectionStringControl.Inititialized = true;
            SourceConnectionStringControl.LabelBottomMargin = 0;
            SourceConnectionStringControl.LabelColor = System.Drawing.Color.LemonChiffon;
            SourceConnectionStringControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            SourceConnectionStringControl.LabelText = "Source Conn. String:";
            SourceConnectionStringControl.LabelTopMargin = 4;
            SourceConnectionStringControl.LabelWidth = 208;
            SourceConnectionStringControl.Location = new System.Drawing.Point(0, 0);
            SourceConnectionStringControl.MultiLine = false;
            SourceConnectionStringControl.Name = "SourceConnectionStringControl";
            SourceConnectionStringControl.OnTextChangedListener = null;
            SourceConnectionStringControl.PasswordMode = false;
            SourceConnectionStringControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            SourceConnectionStringControl.Size = new System.Drawing.Size(1160, 32);
            SourceConnectionStringControl.TabIndex = 58;
            SourceConnectionStringControl.TextBoxBottomMargin = 0;
            SourceConnectionStringControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            SourceConnectionStringControl.TextBoxEditableColor = System.Drawing.Color.White;
            SourceConnectionStringControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SourceConnectionStringControl.TextBoxTopMargin = 3;
            SourceConnectionStringControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // VerticalSeparator3
            // 
            VerticalSeparator3.BackColor = System.Drawing.Color.Transparent;
            VerticalSeparator3.Dock = System.Windows.Forms.DockStyle.Top;
            VerticalSeparator3.Location = new System.Drawing.Point(0, 184);
            VerticalSeparator3.Name = "VerticalSeparator3";
            VerticalSeparator3.Size = new System.Drawing.Size(1200, 12);
            VerticalSeparator3.TabIndex = 100;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = System.Drawing.Color.Transparent;
            MainPanel.Controls.Add(ResultsTextBox);
            MainPanel.Controls.Add(GraphPanel);
            MainPanel.Controls.Add(ComparisonReportLabel);
            MainPanel.Controls.Add(InnerBorder);
            MainPanel.Controls.Add(VerticalSeparator3);
            MainPanel.Controls.Add(CompareDatabaseTopPanel);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(12, 16);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new System.Drawing.Size(1200, 573);
            MainPanel.TabIndex = 102;
            // 
            // ResultsTextBox
            // 
            ResultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            ResultsTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ResultsTextBox.Location = new System.Drawing.Point(8, 228);
            ResultsTextBox.Multiline = true;
            ResultsTextBox.Name = "ResultsTextBox";
            ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ResultsTextBox.Size = new System.Drawing.Size(1192, 309);
            ResultsTextBox.TabIndex = 111;
            ResultsTextBox.MouseClick += ResultsTextBox_MouseClick;
            // 
            // GraphPanel
            // 
            GraphPanel.Controls.Add(Graph);
            GraphPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            GraphPanel.Location = new System.Drawing.Point(8, 537);
            GraphPanel.Name = "GraphPanel";
            GraphPanel.Size = new System.Drawing.Size(1192, 36);
            GraphPanel.TabIndex = 110;
            // 
            // Graph
            // 
            Graph.Dock = System.Windows.Forms.DockStyle.Bottom;
            Graph.Location = new System.Drawing.Point(0, 13);
            Graph.Name = "Graph";
            Graph.Size = new System.Drawing.Size(1192, 23);
            Graph.TabIndex = 109;
            Graph.Visible = false;
            // 
            // ComparisonReportLabel
            // 
            ComparisonReportLabel.BackColor = System.Drawing.Color.Transparent;
            ComparisonReportLabel.Dock = System.Windows.Forms.DockStyle.Top;
            ComparisonReportLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ComparisonReportLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            ComparisonReportLabel.Location = new System.Drawing.Point(8, 196);
            ComparisonReportLabel.Name = "ComparisonReportLabel";
            ComparisonReportLabel.Size = new System.Drawing.Size(1192, 32);
            ComparisonReportLabel.TabIndex = 106;
            ComparisonReportLabel.Text = "Comparison Report:";
            ComparisonReportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InnerBorder
            // 
            InnerBorder.BackColor = System.Drawing.Color.Transparent;
            InnerBorder.Dock = System.Windows.Forms.DockStyle.Left;
            InnerBorder.Location = new System.Drawing.Point(0, 196);
            InnerBorder.Name = "InnerBorder";
            InnerBorder.Size = new System.Drawing.Size(8, 377);
            InnerBorder.TabIndex = 105;
            // 
            // BottomMarginPanel
            // 
            BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            BottomMarginPanel.Location = new System.Drawing.Point(12, 689);
            BottomMarginPanel.Name = "BottomMarginPanel";
            BottomMarginPanel.Size = new System.Drawing.Size(1212, 12);
            BottomMarginPanel.TabIndex = 26;
            // 
            // CopiedTimer
            // 
            CopiedTimer.Interval = 3000;
            CopiedTimer.Tick += CopiedTimer_Tick;
            // 
            // IgnoreDifferenceStrip
            // 
            IgnoreDifferenceStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { IgnoreItem, ClearItem });
            IgnoreDifferenceStrip.Name = "IgnoreDifferenceStrip";
            IgnoreDifferenceStrip.Size = new System.Drawing.Size(160, 48);
            // 
            // IgnoreItem
            // 
            IgnoreItem.Name = "IgnoreItem";
            IgnoreItem.Size = new System.Drawing.Size(159, 22);
            IgnoreItem.Text = "Ignore";
            // 
            // ClearItem
            // 
            ClearItem.Name = "ClearItem";
            ClearItem.Size = new System.Drawing.Size(159, 22);
            ClearItem.Text = "Clear Ignore List";
            // 
            // MainForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Black;
            BackgroundImage = Properties.Resources.Deep_Black;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1224, 701);
            Controls.Add(MainPanel);
            Controls.Add(HiddenButton);
            Controls.Add(Separator6);
            Controls.Add(YouTubePanel);
            Controls.Add(RightMarginPanel);
            Controls.Add(SourceTopPanel);
            Controls.Add(BottomMarginPanel);
            Controls.Add(LeftMarginPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(1240, 740);
            MinimumSize = new System.Drawing.Size(1240, 740);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DB Compare Version 7.0.0";
            Load += MainForm_Load;
            YouTubePanel.ResumeLayout(false);
            YouTubePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CopiedImage).EndInit();
            CompareDatabaseTopPanel.ResumeLayout(false);
            OptionsPanel.ResumeLayout(false);
            RemoteComparePanel.ResumeLayout(false);
            IgnoreDataSyncPanel.ResumeLayout(false);
            TopCheckBoxPanel.ResumeLayout(false);
            CompareRightColumn.ResumeLayout(false);
            TopSectionPanel.ResumeLayout(false);
            TargetConnectionPanel.ResumeLayout(false);
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            GraphPanel.ResumeLayout(false);
            IgnoreDifferenceStrip.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        #endregion

        private System.Windows.Forms.PictureBox CopiedImage;
        private System.Windows.Forms.Timer CopiedTimer;
        private System.Windows.Forms.Label ExtraLabel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ScriptDropExtrasCheckbox;
        private PanelExtender InnerBorder;
        private System.Windows.Forms.ContextMenuStrip IgnoreDifferenceStrip;
        private System.Windows.Forms.ToolStripMenuItem IgnoreItem;
        private System.Windows.Forms.ToolStripMenuItem ClearItem;
    }
    #endregion

}
