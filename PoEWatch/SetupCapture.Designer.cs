namespace PoEWatch
{
    partial class SetupCapture
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
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtCaptureX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaptureY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaptureW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCaptureH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaskH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaskW = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCapture.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.picCapture.Location = new System.Drawing.Point(12, 108);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(709, 385);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            this.picCapture.Paint += new System.Windows.Forms.PaintEventHandler(this.OnCapturePreviewPaint);
            this.picCapture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnCapturePreviewMouseDown);
            this.picCapture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnCapturePreviewMouseMove);
            this.picCapture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnCapturePreviewMouseUp);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(641, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 40);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtCaptureX
            // 
            this.txtCaptureX.Location = new System.Drawing.Point(51, 22);
            this.txtCaptureX.Name = "txtCaptureX";
            this.txtCaptureX.Size = new System.Drawing.Size(79, 26);
            this.txtCaptureX.TabIndex = 2;
            this.txtCaptureX.TextChanged += new System.EventHandler(this.OnChange_CaptureArea);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCaptureY
            // 
            this.txtCaptureY.Location = new System.Drawing.Point(51, 54);
            this.txtCaptureY.Name = "txtCaptureY";
            this.txtCaptureY.Size = new System.Drawing.Size(79, 26);
            this.txtCaptureY.TabIndex = 4;
            this.txtCaptureY.TextChanged += new System.EventHandler(this.OnChange_CaptureArea);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "W";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCaptureW
            // 
            this.txtCaptureW.Location = new System.Drawing.Point(171, 22);
            this.txtCaptureW.Name = "txtCaptureW";
            this.txtCaptureW.Size = new System.Drawing.Size(79, 26);
            this.txtCaptureW.TabIndex = 6;
            this.txtCaptureW.TextChanged += new System.EventHandler(this.OnChange_CaptureArea);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "H";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCaptureH
            // 
            this.txtCaptureH.Location = new System.Drawing.Point(171, 54);
            this.txtCaptureH.Name = "txtCaptureH";
            this.txtCaptureH.Size = new System.Drawing.Size(79, 26);
            this.txtCaptureH.TabIndex = 8;
            this.txtCaptureH.TextChanged += new System.EventHandler(this.OnChange_CaptureArea);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Mask H";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMaskH
            // 
            this.txtMaskH.Location = new System.Drawing.Point(366, 54);
            this.txtMaskH.Name = "txtMaskH";
            this.txtMaskH.Size = new System.Drawing.Size(79, 26);
            this.txtMaskH.TabIndex = 12;
            this.txtMaskH.TextChanged += new System.EventHandler(this.OnChange_Mask);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mask W";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMaskW
            // 
            this.txtMaskW.Location = new System.Drawing.Point(366, 22);
            this.txtMaskW.Name = "txtMaskW";
            this.txtMaskW.Size = new System.Drawing.Size(79, 26);
            this.txtMaskW.TabIndex = 10;
            // 
            // SetupCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 515);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaskH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaskW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCaptureH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCaptureW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCaptureY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCaptureX);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.picCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetupCapture";
            this.Text = "SetupCapture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupCapture_FormClosing);
            this.Shown += new System.EventHandler(this.SetupCapture_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtCaptureX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCaptureY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCaptureW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCaptureH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaskH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaskW;
    }
}