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
            this.txtDebugLog = new System.Windows.Forms.TextBox();
            this.btnInject = new System.Windows.Forms.Button();
            this.btnFPS = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCaptureScreen = new System.Windows.Forms.Button();
            this.ingameMaskPicture = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnIngameMask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingameMaskPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDebugLog
            // 
            this.txtDebugLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugLog.Location = new System.Drawing.Point(12, 421);
            this.txtDebugLog.Multiline = true;
            this.txtDebugLog.Name = "txtDebugLog";
            this.txtDebugLog.Size = new System.Drawing.Size(1360, 180);
            this.txtDebugLog.TabIndex = 0;
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
            // btnFPS
            // 
            this.btnFPS.Location = new System.Drawing.Point(98, 12);
            this.btnFPS.Name = "btnFPS";
            this.btnFPS.Size = new System.Drawing.Size(90, 30);
            this.btnFPS.TabIndex = 2;
            this.btnFPS.Text = "FPS";
            this.btnFPS.UseVisualStyleBackColor = true;
            this.btnFPS.Click += new System.EventHandler(this.btnFPS_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(711, 325);
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
            this.ingameMaskPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ingameMaskPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ingameMaskPicture.Location = new System.Drawing.Point(729, 90);
            this.ingameMaskPicture.Name = "ingameMaskPicture";
            this.ingameMaskPicture.Size = new System.Drawing.Size(643, 325);
            this.ingameMaskPicture.TabIndex = 5;
            this.ingameMaskPicture.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1282, 12);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 613);
            this.Controls.Add(this.btnIngameMask);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.ingameMaskPicture);
            this.Controls.Add(this.btnCaptureScreen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFPS);
            this.Controls.Add(this.btnInject);
            this.Controls.Add(this.txtDebugLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingameMaskPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDebugLog;
        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.Button btnFPS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCaptureScreen;
        private System.Windows.Forms.PictureBox ingameMaskPicture;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnIngameMask;
    }
}

