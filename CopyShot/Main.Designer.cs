namespace CopyShot
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.SecondLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShorcutComboBox = new System.Windows.Forms.ComboBox();
            this.ReadButton = new ePOSOne.btnProduct.Button_WOC();
            this.CopyButton = new ePOSOne.btnProduct.Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(25)))));
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTextBox.Location = new System.Drawing.Point(62, 63);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(415, 420);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.ErrorImage")));
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(501, 175);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(73, 57);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(496, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select first language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(496, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select second language";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.LanguageComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LanguageComboBox.ForeColor = System.Drawing.Color.White;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "Afrikaans",
            "Arabic",
            "Chinese",
            "Danish",
            "English",
            "Finnish",
            "French",
            "German",
            "Greek",
            "Hindi",
            "ltalian",
            "Japanese",
            "Korean",
            "Norwegian",
            "Polish",
            "Portuguese",
            "Russian",
            "Spanish",
            "Swedish",
            "Turkish"});
            this.LanguageComboBox.Location = new System.Drawing.Point(740, 288);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(163, 35);
            this.LanguageComboBox.TabIndex = 6;
            this.LanguageComboBox.Text = "English";
            // 
            // SecondLanguageComboBox
            // 
            this.SecondLanguageComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.SecondLanguageComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SecondLanguageComboBox.ForeColor = System.Drawing.Color.White;
            this.SecondLanguageComboBox.FormattingEnabled = true;
            this.SecondLanguageComboBox.Items.AddRange(new object[] {
            "Afrikaans",
            "Arabic",
            "Chinese",
            "Danish",
            "English",
            "Finnish",
            "French",
            "German",
            "Greek",
            "Hindi",
            "ltalian",
            "Japanese",
            "Korean",
            "Norwegian",
            "Polish",
            "Portuguese",
            "Russian",
            "Spanish",
            "Swedish",
            "Turkish"});
            this.SecondLanguageComboBox.Location = new System.Drawing.Point(740, 340);
            this.SecondLanguageComboBox.Name = "SecondLanguageComboBox";
            this.SecondLanguageComboBox.Size = new System.Drawing.Size(163, 35);
            this.SecondLanguageComboBox.TabIndex = 7;
            this.SecondLanguageComboBox.Text = "English";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(496, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "Shorcut key";
            // 
            // ShorcutComboBox
            // 
            this.ShorcutComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.ShorcutComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShorcutComboBox.ForeColor = System.Drawing.Color.White;
            this.ShorcutComboBox.FormattingEnabled = true;
            this.ShorcutComboBox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "Tab",
            "Caps lock",
            "Shift",
            "Ctrl",
            "Alt",
            "Spacebar",
            "Delete",
            "Prt Scrn",
            "Scroll Lock",
            "Pause",
            "Insert",
            "Home",
            "Page up",
            "Page down",
            "End"});
            this.ShorcutComboBox.Location = new System.Drawing.Point(740, 395);
            this.ShorcutComboBox.Name = "ShorcutComboBox";
            this.ShorcutComboBox.Size = new System.Drawing.Size(163, 35);
            this.ShorcutComboBox.TabIndex = 9;
            this.ShorcutComboBox.Text = "F1";
            // 
            // ReadButton
            // 
            this.ReadButton.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ReadButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.ReadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.ReadButton.Location = new System.Drawing.Point(598, 164);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.OnHoverBorderColor = System.Drawing.Color.RoyalBlue;
            this.ReadButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.ReadButton.OnHoverTextColor = System.Drawing.Color.RoyalBlue;
            this.ReadButton.Size = new System.Drawing.Size(285, 73);
            this.ReadButton.TabIndex = 2;
            this.ReadButton.Text = "Read again";
            this.ReadButton.TextColor = System.Drawing.Color.White;
            this.ReadButton.UseVisualStyleBackColor = false;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.BorderColor = System.Drawing.Color.RoyalBlue;
            this.CopyButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.CopyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.CopyButton.Location = new System.Drawing.Point(598, 63);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.OnHoverBorderColor = System.Drawing.Color.RoyalBlue;
            this.CopyButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.CopyButton.OnHoverTextColor = System.Drawing.Color.RoyalBlue;
            this.CopyButton.Size = new System.Drawing.Size(285, 73);
            this.CopyButton.TabIndex = 1;
            this.CopyButton.Text = "Copy text to clipboard";
            this.CopyButton.TextColor = System.Drawing.Color.White;
            this.CopyButton.UseVisualStyleBackColor = false;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.ShorcutComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SecondLanguageComboBox);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.ReadButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.richTextBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(17)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copyshot";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ePOSOne.btnProduct.Button_WOC CopyButton;
        private ePOSOne.btnProduct.Button_WOC ReadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.ComboBox SecondLanguageComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ShorcutComboBox;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

