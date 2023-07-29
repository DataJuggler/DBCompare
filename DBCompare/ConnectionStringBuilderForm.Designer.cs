

#region using statements


#endregion

namespace DBCompare
{

    #region class ConnectionStringBuilderForm
    /// <summary>
    /// This is the designer for this form.
    /// </summary>
    partial class ConnectionStringBuilderForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton SQLServerAuthenticationRadioButton;
        private System.Windows.Forms.RadioButton WindowsAuthenticationRadioButton;
        private System.Windows.Forms.TextBox DatabasePasswordTextBox;
        private System.Windows.Forms.TextBox DatabaseUserNameTextBox;
        private System.Windows.Forms.TextBox DatabaseServerTextBox;
        private System.Windows.Forms.TextBox DatabaseNameTextBox;
        private System.Windows.Forms.Label DatabasePasswordLabel;
        private System.Windows.Forms.Label DatabaseUserNameLabel;
        private System.Windows.Forms.Label DatabaseServerLabel;
        private System.Windows.Forms.Label DatabaseNameLabel;
        private System.Windows.Forms.Button BuildConnectionStringButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox ConnectionStringTextBox;
        private System.Windows.Forms.Label ConnectionStringLabel;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button TestDatabaseConnectionButton;
        private System.Windows.Forms.PictureBox PassedImage;
        private System.Windows.Forms.PictureBox FailedImage;
        private System.Windows.Forms.Timer Timer;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStringBuilderForm));
            this.SQLServerAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.WindowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.DatabasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseUserNameTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseServerTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseNameTextBox = new System.Windows.Forms.TextBox();
            this.DatabasePasswordLabel = new System.Windows.Forms.Label();
            this.DatabaseUserNameLabel = new System.Windows.Forms.Label();
            this.DatabaseServerLabel = new System.Windows.Forms.Label();
            this.DatabaseNameLabel = new System.Windows.Forms.Label();
            this.BuildConnectionStringButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionStringLabel = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            this.TestDatabaseConnectionButton = new System.Windows.Forms.Button();
            this.PassedImage = new System.Windows.Forms.PictureBox();
            this.FailedImage = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.HiddenButton = new System.Windows.Forms.Button();
            this.ConnectingLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EncryptConnectionComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.PassedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FailedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SQLServerAuthenticationRadioButton
            // 
            this.SQLServerAuthenticationRadioButton.AutoSize = true;
            this.SQLServerAuthenticationRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SQLServerAuthenticationRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SQLServerAuthenticationRadioButton.Location = new System.Drawing.Point(229, 168);
            this.SQLServerAuthenticationRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SQLServerAuthenticationRadioButton.Name = "SQLServerAuthenticationRadioButton";
            this.SQLServerAuthenticationRadioButton.Size = new System.Drawing.Size(184, 22);
            this.SQLServerAuthenticationRadioButton.TabIndex = 24;
            this.SQLServerAuthenticationRadioButton.Text = "SQL Authentication";
            this.SQLServerAuthenticationRadioButton.UseVisualStyleBackColor = false;
            this.SQLServerAuthenticationRadioButton.CheckedChanged += new System.EventHandler(this.SQLServerAuthenticationRadioButton_CheckedChanged);
            // 
            // WindowsAuthenticationRadioButton
            // 
            this.WindowsAuthenticationRadioButton.AutoSize = true;
            this.WindowsAuthenticationRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.WindowsAuthenticationRadioButton.Checked = true;
            this.WindowsAuthenticationRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WindowsAuthenticationRadioButton.Location = new System.Drawing.Point(461, 168);
            this.WindowsAuthenticationRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.WindowsAuthenticationRadioButton.Name = "WindowsAuthenticationRadioButton";
            this.WindowsAuthenticationRadioButton.Size = new System.Drawing.Size(226, 22);
            this.WindowsAuthenticationRadioButton.TabIndex = 23;
            this.WindowsAuthenticationRadioButton.TabStop = true;
            this.WindowsAuthenticationRadioButton.Text = "Windows Authentication";
            this.WindowsAuthenticationRadioButton.UseVisualStyleBackColor = false;
            // 
            // DatabasePasswordTextBox
            // 
            this.DatabasePasswordTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabasePasswordTextBox.Location = new System.Drawing.Point(229, 253);
            this.DatabasePasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DatabasePasswordTextBox.Name = "DatabasePasswordTextBox";
            this.DatabasePasswordTextBox.PasswordChar = '*';
            this.DatabasePasswordTextBox.Size = new System.Drawing.Size(585, 27);
            this.DatabasePasswordTextBox.TabIndex = 21;
            this.DatabasePasswordTextBox.Visible = false;
            // 
            // DatabaseUserNameTextBox
            // 
            this.DatabaseUserNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabaseUserNameTextBox.Location = new System.Drawing.Point(229, 208);
            this.DatabaseUserNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DatabaseUserNameTextBox.Name = "DatabaseUserNameTextBox";
            this.DatabaseUserNameTextBox.Size = new System.Drawing.Size(585, 27);
            this.DatabaseUserNameTextBox.TabIndex = 20;
            this.DatabaseUserNameTextBox.Visible = false;
            // 
            // DatabaseServerTextBox
            // 
            this.DatabaseServerTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabaseServerTextBox.Location = new System.Drawing.Point(229, 18);
            this.DatabaseServerTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DatabaseServerTextBox.Name = "DatabaseServerTextBox";
            this.DatabaseServerTextBox.Size = new System.Drawing.Size(585, 27);
            this.DatabaseServerTextBox.TabIndex = 16;
            // 
            // DatabaseNameTextBox
            // 
            this.DatabaseNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabaseNameTextBox.Location = new System.Drawing.Point(229, 63);
            this.DatabaseNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DatabaseNameTextBox.Name = "DatabaseNameTextBox";
            this.DatabaseNameTextBox.Size = new System.Drawing.Size(585, 27);
            this.DatabaseNameTextBox.TabIndex = 17;
            // 
            // DatabasePasswordLabel
            // 
            this.DatabasePasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabasePasswordLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabasePasswordLabel.Location = new System.Drawing.Point(19, 257);
            this.DatabasePasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DatabasePasswordLabel.Name = "DatabasePasswordLabel";
            this.DatabasePasswordLabel.Size = new System.Drawing.Size(208, 27);
            this.DatabasePasswordLabel.TabIndex = 22;
            this.DatabasePasswordLabel.Text = "Database Password:";
            this.DatabasePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DatabasePasswordLabel.Visible = false;
            // 
            // DatabaseUserNameLabel
            // 
            this.DatabaseUserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseUserNameLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabaseUserNameLabel.Location = new System.Drawing.Point(19, 212);
            this.DatabaseUserNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DatabaseUserNameLabel.Name = "DatabaseUserNameLabel";
            this.DatabaseUserNameLabel.Size = new System.Drawing.Size(208, 27);
            this.DatabaseUserNameLabel.TabIndex = 19;
            this.DatabaseUserNameLabel.Text = "Database User Name:";
            this.DatabaseUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DatabaseUserNameLabel.Visible = false;
            // 
            // DatabaseServerLabel
            // 
            this.DatabaseServerLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseServerLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabaseServerLabel.Location = new System.Drawing.Point(19, 23);
            this.DatabaseServerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DatabaseServerLabel.Name = "DatabaseServerLabel";
            this.DatabaseServerLabel.Size = new System.Drawing.Size(208, 27);
            this.DatabaseServerLabel.TabIndex = 18;
            this.DatabaseServerLabel.Text = "Database Server:";
            this.DatabaseServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DatabaseNameLabel
            // 
            this.DatabaseNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseNameLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatabaseNameLabel.Location = new System.Drawing.Point(19, 68);
            this.DatabaseNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DatabaseNameLabel.Name = "DatabaseNameLabel";
            this.DatabaseNameLabel.Size = new System.Drawing.Size(208, 27);
            this.DatabaseNameLabel.TabIndex = 15;
            this.DatabaseNameLabel.Text = "Database Name:";
            this.DatabaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BuildConnectionStringButton
            // 
            this.BuildConnectionStringButton.BackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.BackgroundImage = global::DBCompare.Properties.Resources.DarkButton;
            this.BuildConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BuildConnectionStringButton.FlatAppearance.BorderSize = 0;
            this.BuildConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuildConnectionStringButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BuildConnectionStringButton.ForeColor = System.Drawing.Color.White;
            this.BuildConnectionStringButton.Location = new System.Drawing.Point(548, 428);
            this.BuildConnectionStringButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BuildConnectionStringButton.Name = "BuildConnectionStringButton";
            this.BuildConnectionStringButton.Size = new System.Drawing.Size(266, 42);
            this.BuildConnectionStringButton.TabIndex = 26;
            this.BuildConnectionStringButton.Text = "Build Connection String";
            this.BuildConnectionStringButton.UseVisualStyleBackColor = false;
            this.BuildConnectionStringButton.Click += new System.EventHandler(this.BuildConnectionStringButton_Click);
            this.BuildConnectionStringButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BuildConnectionStringButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = global::DBCompare.Properties.Resources.DarkButton;
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(698, 486);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(117, 42);
            this.CancelButton.TabIndex = 25;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.CancelButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CancelButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ConnectionStringTextBox
            // 
            this.ConnectionStringTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConnectionStringTextBox.Location = new System.Drawing.Point(229, 298);
            this.ConnectionStringTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ConnectionStringTextBox.Multiline = true;
            this.ConnectionStringTextBox.Name = "ConnectionStringTextBox";
            this.ConnectionStringTextBox.Size = new System.Drawing.Size(585, 111);
            this.ConnectionStringTextBox.TabIndex = 28;
            // 
            // ConnectionStringLabel
            // 
            this.ConnectionStringLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionStringLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConnectionStringLabel.Location = new System.Drawing.Point(19, 298);
            this.ConnectionStringLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionStringLabel.Name = "ConnectionStringLabel";
            this.ConnectionStringLabel.Size = new System.Drawing.Size(208, 27);
            this.ConnectionStringLabel.TabIndex = 27;
            this.ConnectionStringLabel.Text = "Connection String:";
            this.ConnectionStringLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.Color.Transparent;
            this.SelectButton.BackgroundImage = global::DBCompare.Properties.Resources.DarkButton;
            this.SelectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SelectButton.FlatAppearance.BorderSize = 0;
            this.SelectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SelectButton.ForeColor = System.Drawing.Color.White;
            this.SelectButton.Location = new System.Drawing.Point(575, 486);
            this.SelectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(117, 42);
            this.SelectButton.TabIndex = 29;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            this.SelectButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.SelectButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // TestDatabaseConnectionButton
            // 
            this.TestDatabaseConnectionButton.BackColor = System.Drawing.Color.Transparent;
            this.TestDatabaseConnectionButton.BackgroundImage = global::DBCompare.Properties.Resources.DarkButton;
            this.TestDatabaseConnectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TestDatabaseConnectionButton.FlatAppearance.BorderSize = 0;
            this.TestDatabaseConnectionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TestDatabaseConnectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TestDatabaseConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestDatabaseConnectionButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TestDatabaseConnectionButton.ForeColor = System.Drawing.Color.White;
            this.TestDatabaseConnectionButton.Location = new System.Drawing.Point(229, 428);
            this.TestDatabaseConnectionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TestDatabaseConnectionButton.Name = "TestDatabaseConnectionButton";
            this.TestDatabaseConnectionButton.Size = new System.Drawing.Size(315, 42);
            this.TestDatabaseConnectionButton.TabIndex = 30;
            this.TestDatabaseConnectionButton.Text = "Test Database Connection";
            this.TestDatabaseConnectionButton.UseVisualStyleBackColor = false;
            this.TestDatabaseConnectionButton.Click += new System.EventHandler(this.TestDatabaseConnectionButton_Click);
            this.TestDatabaseConnectionButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.TestDatabaseConnectionButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // PassedImage
            // 
            this.PassedImage.BackgroundImage = global::DBCompare.Properties.Resources.Success;
            this.PassedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PassedImage.Location = new System.Drawing.Point(142, 345);
            this.PassedImage.Name = "PassedImage";
            this.PassedImage.Size = new System.Drawing.Size(64, 64);
            this.PassedImage.TabIndex = 32;
            this.PassedImage.TabStop = false;
            this.PassedImage.Visible = false;
            // 
            // FailedImage
            // 
            this.FailedImage.BackgroundImage = global::DBCompare.Properties.Resources.Failure;
            this.FailedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FailedImage.Location = new System.Drawing.Point(142, 345);
            this.FailedImage.Name = "FailedImage";
            this.FailedImage.Size = new System.Drawing.Size(64, 64);
            this.FailedImage.TabIndex = 33;
            this.FailedImage.TabStop = false;
            this.FailedImage.Visible = false;
            // 
            // Timer
            // 
            this.Timer.Interval = 3000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // HiddenButton
            // 
            this.HiddenButton.BackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.BackgroundImage = global::DBCompare.Properties.Resources.DarkButton;
            this.HiddenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HiddenButton.FlatAppearance.BorderSize = 0;
            this.HiddenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HiddenButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HiddenButton.ForeColor = System.Drawing.Color.White;
            this.HiddenButton.Location = new System.Drawing.Point(-328, 426);
            this.HiddenButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.HiddenButton.Name = "HiddenButton";
            this.HiddenButton.Size = new System.Drawing.Size(117, 42);
            this.HiddenButton.TabIndex = 34;
            this.HiddenButton.Text = "Hidden";
            this.HiddenButton.UseVisualStyleBackColor = false;
            // 
            // ConnectingLabel
            // 
            this.ConnectingLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConnectingLabel.Location = new System.Drawing.Point(148, 491);
            this.ConnectingLabel.Name = "ConnectingLabel";
            this.ConnectingLabel.Size = new System.Drawing.Size(396, 37);
            this.ConnectingLabel.TabIndex = 35;
            this.ConnectingLabel.Text = "Attempting to connect to database...";
            this.ConnectingLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(420, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 54);
            this.label1.TabIndex = 37;
            this.label1.Text = "Microsoft.Data.SqlClient 5.0 has encryption turned on by default. If your database is not encrypted, leave this as False.";
            // 
            // EncryptConnectionComboBox
            // 
            this.EncryptConnectionComboBox.BackColor = System.Drawing.Color.Transparent;
            this.EncryptConnectionComboBox.ComboBoxLeftMargin = 1;
            this.EncryptConnectionComboBox.ComboBoxText = "";
            this.EncryptConnectionComboBox.ComoboBoxFont = null;
            this.EncryptConnectionComboBox.Editable = true;
            this.EncryptConnectionComboBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EncryptConnectionComboBox.HideLabel = false;
            this.EncryptConnectionComboBox.LabelBottomMargin = 0;
            this.EncryptConnectionComboBox.LabelColor = System.Drawing.Color.Black;
            this.EncryptConnectionComboBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EncryptConnectionComboBox.LabelText = "Encrypt:";
            this.EncryptConnectionComboBox.LabelTopMargin = 0;
            this.EncryptConnectionComboBox.LabelWidth = 80;
            this.EncryptConnectionComboBox.List = null;
            this.EncryptConnectionComboBox.Location = new System.Drawing.Point(148, 114);
            this.EncryptConnectionComboBox.Name = "EncryptConnectionComboBox";
            this.EncryptConnectionComboBox.SelectedIndex = -1;
            this.EncryptConnectionComboBox.SelectedIndexListener = null;
            this.EncryptConnectionComboBox.Size = new System.Drawing.Size(260, 28);
            this.EncryptConnectionComboBox.Sorted = true;
            this.EncryptConnectionComboBox.Source = null;
            this.EncryptConnectionComboBox.TabIndex = 38;
            this.EncryptConnectionComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Wood;
            // 
            // ConnectionStringBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(845, 544);
            this.Controls.Add(this.EncryptConnectionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectingLabel);
            this.Controls.Add(this.HiddenButton);
            this.Controls.Add(this.TestDatabaseConnectionButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.ConnectionStringTextBox);
            this.Controls.Add(this.ConnectionStringLabel);
            this.Controls.Add(this.BuildConnectionStringButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SQLServerAuthenticationRadioButton);
            this.Controls.Add(this.WindowsAuthenticationRadioButton);
            this.Controls.Add(this.DatabasePasswordTextBox);
            this.Controls.Add(this.DatabaseUserNameTextBox);
            this.Controls.Add(this.DatabaseServerTextBox);
            this.Controls.Add(this.DatabaseNameTextBox);
            this.Controls.Add(this.DatabasePasswordLabel);
            this.Controls.Add(this.DatabaseUserNameLabel);
            this.Controls.Add(this.DatabaseServerLabel);
            this.Controls.Add(this.DatabaseNameLabel);
            this.Controls.Add(this.FailedImage);
            this.Controls.Add(this.PassedImage);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ConnectionStringBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection String Builder";
            ((System.ComponentModel.ISupportInitialize)(this.PassedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FailedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private System.Windows.Forms.Button HiddenButton;
        private System.Windows.Forms.Label ConnectingLabel;
        private System.Windows.Forms.Label label1;
        private DataJuggler.Win.Controls.LabelComboBoxControl EncryptConnectionComboBox;
    }
    #endregion

}
