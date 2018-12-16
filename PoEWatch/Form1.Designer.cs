namespace PoEWatch
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnInject = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCaptureScreen = new System.Windows.Forms.Button();
            this.ingameMaskPicture = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnIngameMask = new System.Windows.Forms.Button();
            this.lblInGame = new System.Windows.Forms.Label();
            this.btnSetup = new System.Windows.Forms.Button();
            this.processName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingameMaskPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInject
            // 
            this.btnInject.Location = new System.Drawing.Point(12, 12);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(80, 30);
            this.btnInject.TabIndex = 1;
            this.btnInject.Text = "Inject";
            this.btnInject.UseVisualStyleBackColor = true;
            this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(418, 331);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnCaptureScreen
            // 
            this.btnCaptureScreen.Location = new System.Drawing.Point(194, 12);
            this.btnCaptureScreen.Name = "btnCaptureScreen";
            this.btnCaptureScreen.Size = new System.Drawing.Size(90, 30);
            this.btnCaptureScreen.TabIndex = 4;
            this.btnCaptureScreen.Text = "Capture";
            this.btnCaptureScreen.UseVisualStyleBackColor = true;
            this.btnCaptureScreen.Click += new System.EventHandler(this.btnCaptureScreen_Click);
            // 
            // ingameMaskPicture
            // 
            this.ingameMaskPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ingameMaskPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ingameMaskPicture.Location = new System.Drawing.Point(450, 90);
            this.ingameMaskPicture.Name = "ingameMaskPicture";
            this.ingameMaskPicture.Size = new System.Drawing.Size(363, 331);
            this.ingameMaskPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ingameMaskPicture.TabIndex = 5;
            this.ingameMaskPicture.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(416, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 30);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnIngameMask
            // 
            this.btnIngameMask.Location = new System.Drawing.Point(290, 12);
            this.btnIngameMask.Name = "btnIngameMask";
            this.btnIngameMask.Size = new System.Drawing.Size(120, 30);
            this.btnIngameMask.TabIndex = 7;
            this.btnIngameMask.Text = "IngameMask";
            this.btnIngameMask.UseVisualStyleBackColor = true;
            this.btnIngameMask.Click += new System.EventHandler(this.btnIngameMask_Click);
            // 
            // lblInGame
            // 
            this.lblInGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInGame.AutoSize = true;
            this.lblInGame.Location = new System.Drawing.Point(684, 22);
            this.lblInGame.Name = "lblInGame";
            this.lblInGame.Size = new System.Drawing.Size(129, 20);
            this.lblInGame.TabIndex = 8;
            this.lblInGame.Text = "Ingame Indicator";
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(98, 12);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(90, 30);
            this.btnSetup.TabIndex = 9;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // processName
            // 
            this.processName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processName.FormattingEnabled = true;
            this.processName.Items.AddRange(new object[] {
            "PathOfExile_x64",
            "PathOfExile_x64Steam"});
            this.processName.Location = new System.Drawing.Point(98, 48);
            this.processName.Name = "processName";
            this.processName.Size = new System.Drawing.Size(186, 28);
            this.processName.TabIndex = 10;
            this.processName.SelectedValueChanged += new System.EventHandler(this.processName_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Process";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 433);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processName);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.lblInGame);
            this.Controls.Add(this.btnIngameMask);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.ingameMaskPicture);
            this.Controls.Add(this.btnCaptureScreen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnInject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PoE Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingameMaskPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCaptureScreen;
        private System.Windows.Forms.PictureBox ingameMaskPicture;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnIngameMask;
        private System.Windows.Forms.Label lblInGame;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.ComboBox processName;
        private System.Windows.Forms.Label label1;
    }
}

