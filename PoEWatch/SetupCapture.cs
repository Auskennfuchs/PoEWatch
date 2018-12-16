using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace PoEWatch
{
    public partial class SetupCapture : Form
    {

        private Timer captureTimer;
        private ScreenCapture screenCapture = new ScreenCapture();
        private Rectangle captureArea;
        private Rectangle processArea;
        private bool isDragging = false;
        private Point mousePos;
        private Pen pen;
        private Rectangle gameCaptureArea;
        private Size maskSize;

        public Process Process { get; set; }

        public SetupCapture()
        {
            InitializeComponent();
            pen = new Pen(Color.Blue, 2);
        }

        private void SetupCapture_Shown(object sender, EventArgs e)
        {
            var scalingFactor = 1.0f/screenCapture.ScalingFactor;
            captureArea = new Rectangle(0, 0, (int)(picCapture.ClientRectangle.Width*scalingFactor), (int)(picCapture.ClientRectangle.Height* scalingFactor));
            captureTimer = new Timer(state => this.CaptureScreen(), null, 0, 100);
            gameCaptureArea = (Rectangle)Properties.Settings.Default["CaptureRect"];
            maskSize = (Size)Properties.Settings.Default["IngameMask"];
            var sx= gameCaptureArea.X.ToString();
            var sy = gameCaptureArea.Y.ToString();
            var sw = gameCaptureArea.Width.ToString();
            var sh = gameCaptureArea.Height.ToString();
            var mw = maskSize.Width.ToString();
            var mh = maskSize.Height.ToString();
        
            txtCaptureX.Text = sx;
            txtCaptureY.Text = sy;
            txtCaptureW.Text = sw;
            txtCaptureH.Text = sh;

            txtMaskW.Text = mw;
            txtMaskH.Text = mh;

            if (Process != null)
            {
                processArea = screenCapture.GetClientArea(Process.MainWindowHandle);
            }
        }

        private void SetupCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            captureTimer?.Change(-1, -1);
        }

        private void CaptureScreen()
        {
            if (Process == null)
            {
                return;
            }
            var curCapture = (Bitmap)screenCapture.CaptureWindow(Process.MainWindowHandle, captureArea);
            picCapture.Invoke(new MethodInvoker(
                delegate ()
                {
                    picCapture.Image?.Dispose();
                    picCapture.Image = curCapture;
                }
                ));
        }

        private void OnCapturePreviewMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !isDragging)
            {
                isDragging = true;
                mousePos = e.Location;
            }
        }

        private void OnCapturePreviewMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging)
            {
                isDragging = false;
            }
        }

        private void OnCapturePreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var diff = new Point(e.Location.X - mousePos.X, e.Location.Y - mousePos.Y);
                var newX = captureArea.X - diff.X / 3;
                newX = Math.Max(0, newX);
                newX = Math.Min(newX, processArea.Width - captureArea.Width);

                var newY = captureArea.Y - diff.Y / 3;
                newY = Math.Max(0, newY);
                newY = Math.Min(newY, processArea.Height - captureArea.Height);
                captureArea = new Rectangle(newX, newY, captureArea.Width, captureArea.Height);
                this.Invalidate();
            }
        }

        private void OnCapturePreviewPaint(object sender, PaintEventArgs e)
        {
            if (picCapture.Image != null)
            {
                var bmp = new Bitmap(picCapture.Image);

                using (var g = Graphics.FromImage(bmp))
                {
                    var rx = (int)((gameCaptureArea.X - captureArea.X) * screenCapture.ScalingFactor);
                    var ry = (int)((gameCaptureArea.Y - captureArea.Y) * screenCapture.ScalingFactor);
                    var rw = (int)(gameCaptureArea.Width * screenCapture.ScalingFactor);
                    var rh = (int)(gameCaptureArea.Height * screenCapture.ScalingFactor);
                    var rect = new Rectangle(rx, ry, rw, rh);
                    g.DrawRectangle(pen, rect);
                }

                picCapture.Image = bmp;
            }
            //            base.OnPaint(e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["CaptureRect"] = gameCaptureArea;
            Properties.Settings.Default["IngameMask"] = maskSize;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void OnChange_CaptureArea(object sender, EventArgs e)
        {
            var x = gameCaptureArea.X;
            var y = gameCaptureArea.Y;
            var w = gameCaptureArea.Width;
            var h = gameCaptureArea.Height;
            if (int.TryParse(txtCaptureX.Text, out x)
                && int.TryParse(txtCaptureY.Text, out y)
                && int.TryParse(txtCaptureW.Text, out w)
                && int.TryParse(txtCaptureH.Text, out h))
            {
                gameCaptureArea = new Rectangle(x, y, w, h);
            }
            this.Invalidate();
        }

        private void OnChange_Mask(object sender, EventArgs e)
        {
            var w = maskSize.Width;
            var h = maskSize.Height;
            if (int.TryParse(txtMaskW.Text, out w)
                && int.TryParse(txtMaskH.Text, out h))
            {
                maskSize = new Size(w, h);
            }
        }
    }
}
