namespace DBCompare
{
    partial class ConnectionStringBuilderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.SuspendLayout();
            // 
            // SQLServerAuthenticationRadioButton
            // 
            this.SQLServerAuthenticationRadioButton.AutoSize = true;
            this.SQLServerAuthenticationRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SQLServerAuthenticationRadioButton.Font = new System.Drawing.Font("Verdana", 12F);
            this.SQLServerAuthenticationRadioButton.Location = new System.Drawing.Point(196, 94);
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
            this.WindowsAuthenticationRadioButton.Font = new System.Drawing.Font("Verdana", 12F);
            this.WindowsAuthenticationRadioButton.Location = new System.Drawing.Point(395, 94);
            this.WindowsAuthenticationRadioButton.Name = "WindowsAuthenticationRadioButton";
            this.WindowsAuthenticationRadioButton.Size = new System.Drawing.Size(226, 22);
            this.WindowsAuthenticationRadioButton.TabIndex = 23;
            this.WindowsAuthenticationRadioButton.TabStop = true;
            this.WindowsAuthenticationRadioButton.Text = "Windows Authentication";
            this.WindowsAuthenticationRadioButton.UseVisualStyleBackColor = false;
            // 
            // DatabasePasswordTextBox
            // 
            this.DatabasePasswordTextBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabasePasswordTextBox.Location = new System.Drawing.Point(196, 167);
            this.DatabasePasswordTextBox.Name = "DatabasePasswordTextBox";
            this.DatabasePasswordTextBox.PasswordChar = '*';
            this.DatabasePasswordTextBox.Size = new System.Drawing.Size(502, 27);
            this.DatabasePasswordTextBox.TabIndex = 21;
            this.DatabasePasswordTextBox.Visible = false;
            // 
            // DatabaseUserNameTextBox
            // 
            this.DatabaseUserNameTextBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabaseUserNameTextBox.Location = new System.Drawing.Point(196, 128);
            this.DatabaseUserNameTextBox.Name = "DatabaseUserNameTextBox";
            this.DatabaseUserNameTextBox.Size = new System.Drawing.Size(502, 27);
            this.DatabaseUserNameTextBox.TabIndex = 20;
            this.DatabaseUserNameTextBox.Visible = false;
            // 
            // DatabaseServerTextBox
            // 
            this.DatabaseServerTextBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabaseServerTextBox.Location = new System.Drawing.Point(196, 16);
            this.DatabaseServerTextBox.Name = "DatabaseServerTextBox";
            this.DatabaseServerTextBox.Size = new System.Drawing.Size(502, 27);
            this.DatabaseServerTextBox.TabIndex = 16;
            // 
            // DatabaseNameTextBox
            // 
            this.DatabaseNameTextBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabaseNameTextBox.Location = new System.Drawing.Point(196, 55);
            this.DatabaseNameTextBox.Name = "DatabaseNameTextBox";
            this.DatabaseNameTextBox.Size = new System.Drawing.Size(502, 27);
            this.DatabaseNameTextBox.TabIndex = 17;
            // 
            // DatabasePasswordLabel
            // 
            this.DatabasePasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabasePasswordLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabasePasswordLabel.Location = new System.Drawing.Point(16, 171);
            this.DatabasePasswordLabel.Name = "DatabasePasswordLabel";
            this.DatabasePasswordLabel.Size = new System.Drawing.Size(178, 23);
            this.DatabasePasswordLabel.TabIndex = 22;
            this.DatabasePasswordLabel.Text = "Database Password:";
            this.DatabasePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DatabasePasswordLabel.Visible = false;
            // 
            // DatabaseUserNameLabel
            // 
            this.DatabaseUserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseUserNameLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabaseUserNameLabel.Location = new System.Drawing.Point(16, 132);
            this.DatabaseUserNameLabel.Name = "DatabaseUserNameLabel";
            this.DatabaseUserNameLabel.Size = new System.Drawing.Size(178, 23);
            this.DatabaseUserNameLabel.TabIndex = 19;
            this.DatabaseUserNameLabel.Text = "Database User Name:";
            this.DatabaseUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DatabaseUserNameLabel.Visible = false;
            // 
            // DatabaseServerLabel
            // 
            this.DatabaseServerLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseServerLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabaseServerLabel.Location = new System.Drawing.Point(16, 20);
            this.DatabaseServerLabel.Name = "DatabaseServerLabel";
            this.DatabaseServerLabel.Size = new System.Drawing.Size(178, 23);
            this.DatabaseServerLabel.TabIndex = 18;
            this.DatabaseServerLabel.Text = "Database Server:";
            this.DatabaseServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DatabaseNameLabel
            // 
            this.DatabaseNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseNameLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.DatabaseNameLabel.Location = new System.Drawing.Point(16, 59);
            this.DatabaseNameLabel.Name = "DatabaseNameLabel";
            this.DatabaseNameLabel.Size = new System.Drawing.Size(178, 23);
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
            this.BuildConnectionStringButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.BuildConnectionStringButton.ForeColor = System.Drawing.Color.White;
            this.BuildConnectionStringButton.Location = new System.Drawing.Point(470, 319);
            this.BuildConnectionStringButton.Name = "BuildConnectionStringButton";
            this.BuildConnectionStringButton.Size = new System.Drawing.Size(228, 36);
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
            this.CancelButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(598, 369);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 36);
            this.CancelButton.TabIndex = 25;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.CancelButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CancelButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ConnectionStringTextBox
            // 
            this.ConnectionStringTextBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.ConnectionStringTextBox.Location = new System.Drawing.Point(196, 206);
            this.ConnectionStringTextBox.Multiline = true;
            this.ConnectionStringTextBox.Name = "ConnectionStringTextBox";
            this.ConnectionStringTextBox.Size = new System.Drawing.Size(502, 97);
            this.ConnectionStringTextBox.TabIndex = 28;
            // 
            // ConnectionStringLabel
            // 
            this.ConnectionStringLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionStringLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.ConnectionStringLabel.Location = new System.Drawing.Point(16, 206);
            this.ConnectionStringLabel.Name = "ConnectionStringLabel";
            this.ConnectionStringLabel.Size = new System.Drawing.Size(178, 23);
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
            this.SelectButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.SelectButton.ForeColor = System.Drawing.Color.White;
            this.SelectButton.Location = new System.Drawing.Point(493, 369);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(100, 36);
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
            this.TestDatabaseConnectionButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestDatabaseConnectionButton.ForeColor = System.Drawing.Color.White;
            this.TestDatabaseConnectionButton.Location = new System.Drawing.Point(186, 319);
            this.TestDatabaseConnectionButton.Name = "TestDatabaseConnectionButton";
            this.TestDatabaseConnectionButton.Size = new System.Drawing.Size(280, 36);
            this.TestDatabaseConnectionButton.TabIndex = 30;
            this.TestDatabaseConnectionButton.Text = "Test Database Connection";
            this.TestDatabaseConnectionButton.UseVisualStyleBackColor = false;
            this.TestDatabaseConnectionButton.Click += new System.EventHandler(this.TestDatabaseConnectionButton_Click);
            this.TestDatabaseConnectionButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.TestDatabaseConnectionButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ConnectionStringBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 421);
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
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectionStringBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection String Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
    }
}