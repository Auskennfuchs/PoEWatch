using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace PoEWatch
{
    public partial class Form1 : Form
    {
        private Process process;
        private int processId;
        private Timer captureTimer;
        private ScreenCapture screenCapture;
        private Rectangle captureArea = (Rectangle)Properties.Settings.Default["CaptureRect"];
        private Size ingameMaskArea = (Size)Properties.Settings.Default["IngameMask"];
        private volatile Bitmap ingameMask, lifeMask, curCapture;
        private volatile bool inGame = false;
        private volatile bool capturing = false;

        private SetupCapture setupCapture = new SetupCapture();

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("msvcrt.dll")]
        private static extern unsafe int memcmp(IntPtr b1, IntPtr b2, int count);

        public Form1()
        {
            InitializeComponent();
            screenCapture = new ScreenCapture();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            processName.SelectedItem = Properties.Settings.Default["ProcessName"];
        }

        private void AttachProcess()
        {
            var allProcesses = Process.GetProcessesByName((string)processName.SelectedItem);//bf3
            foreach (var p in allProcesses)
            {
                if (p.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }
                process = p;
                processId = p.Id;
                setupCapture.Process = p;
                break;
            }
            Thread.Sleep(10);
            if (process == null)
            {
                MessageBox.Show("No running executable found.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureTimer != null)
            {
                captureTimer.Change(-1, -1);
            }
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            AttachProcess();
        }

        private void btnCaptureScreen_Click(object sender, EventArgs e)
        {
            if (captureTimer == null)
            {
                capturing = true;
                captureTimer = new Timer(state => this.CaptureScreen(), this, 0, 30);
                this.Text = this.Text + " - Capturing";
            }
            else
            {
                captureTimer.Change(-1, -1);
                captureTimer.Dispose();
                captureTimer = null;
                lifeMask = null;
                capturing = false;
                this.Text = this.Text.Replace(" - Capturing","");
            }
        }

        private void CaptureScreen()
        {
            if (process == null)
            {
                return;
            }
            curCapture = (Bitmap)screenCapture.CaptureWindow(process.MainWindowHandle, captureArea);
            CheckIngame(curCapture);
            if (lifeMask == null)
            {
                lifeMask = curCapture.Clone() as Bitmap;
                pictureBox1.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = lifeMask;
                    }
                    ));
            }
            if (inGame)
            {
                if (!CheckHealth(curCapture))
                {
                    DoLogout();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DoLogout();
        }

        private void btnIngameMask_Click(object sender, EventArgs e)
        {
            if (curCapture == null)
            {
                return;
            }
            ingameMask?.Dispose();
            ingameMask = new Bitmap(ingameMaskArea.Width, ingameMaskArea.Height);
            var g = Graphics.FromImage(ingameMask);
            g.DrawImage(curCapture, 0, 0);
            ingameMaskPicture.Invoke(new MethodInvoker(
                delegate ()
                {
                    ingameMaskPicture.Image?.Dispose();
                    ingameMaskPicture.Image = ingameMask;
                }));
            SetIngameIndicator(true);
        }

        private void CheckIngame(Bitmap curDisplay)
        {
            if (ingameMask == null || curDisplay == null)
            {
                return;
            }
            lock (curDisplay)
            {
                lock (ingameMask)
                {
                    var maskRect = new Rectangle(0, 0, ingameMask.Width, ingameMask.Height);
                    var imageSize = (float)maskRect.Width * ingameMask.Height;
                    var image1 = curDisplay.Clone(maskRect, curDisplay.PixelFormat) as Bitmap;
                    var maskDiffImg = GetDifferenceImage(image1, ingameMask, out var diffCount);
                    var diffThreshold = diffCount / imageSize <= 0.1f;
                    if (diffThreshold != inGame)
                    {
                        SetIngameIndicator(diffThreshold);
                    }
                }
            }
        }

        private bool CheckHealth(Bitmap curDisplay)
        {
            return CheckImageDiff(curDisplay, lifeMask, 0.1f);
        }

        private void DoLogout()
        {
            SetForegroundWindow(process.MainWindowHandle);
            Thread.Sleep(5);
            for (var i = 0; i < 20; i++)
            {
                try
                {
                    SendKeys.SendWait("{F4}");
                }
                catch
                {
                }
            }
            btnCaptureScreen_Click(null, null);
        }

        private bool CheckImageDiff(Bitmap curImage, Bitmap maskImage, float threshold)
        {
            if (curImage == null || maskImage == null)
            {
                return true;
            }
            lock (curImage)
            {
                lock (maskImage)
                {
                    var maskRect = new Rectangle(0, 0, maskImage.Width, maskImage.Height);
                    var imageSize = (float)maskRect.Width * maskRect.Height;
                    var image1 = curImage.Clone(maskRect, curImage.PixelFormat) as Bitmap;
                    var maskDiffImg = GetDifferenceImage(image1, maskImage, out var diffCount);
                    var diff = diffCount / imageSize;
                    return diffCount / imageSize <= threshold;
                }
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            setupCapture.ShowDialog();
        }

        private void processName_SelectedValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ProcessName"] = processName.SelectedItem;
            Properties.Settings.Default.Save();
        }

        public static unsafe int GetDifferenceImage(Bitmap image1, Bitmap image2, out int diffCount)
        {
            diffCount = 0;
            if (image1 == null | image2 == null)
            {
                return 0;
            }

            if (image1.Height != image2.Height || image1.Width != image2.Width)
            {
                return 0;
            }

            int height = image2.Height;
            int width = image2.Width;

            var data1 = image1.LockBits(new Rectangle(0, 0, width, height),
                                               ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var data2 = image2.LockBits(new Rectangle(0, 0, width, height),
                                               ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* data1Ptr = (byte*)data1.Scan0;
            byte* data2Ptr = (byte*)data2.Scan0;

            int rowPadding = data1.Stride - (image1.Width * 4);

            // iterate over height (rows)
            for (int i = 0; i < height; i++)
            {
                // iterate over width (columns)
                for (int j = 0; j < width; j++)
                {
                    int same = 0;

                    byte[] tmp = new byte[4];

                    // compare pixels and copy new values into temporary array
                    for (int x = 0; x < 4; x++)
                    {
                        tmp[x] = data2Ptr[0];
                        if (data1Ptr[0] == data2Ptr[0])
                        {
                            same++;
                        }
                        data1Ptr++; // advance image1 ptr
                        data2Ptr++; // advance image2 ptr
                    }

                    if (same != 4)
                    {
                        diffCount++;
                    }
                }

                // at the end of each column, skip extra padding
                if (rowPadding > 0)
                {
                    data1Ptr += rowPadding;
                    data2Ptr += rowPadding;
                }
            }
            image1.UnlockBits(data1);
            image2.UnlockBits(data2);
            return diffCount;
        }

        private void SetIngameIndicator(bool ingame)
        {
            lblInGame.Invoke(new MethodInvoker(
                delegate
                {
                    lblInGame.Text = ingame ? "Game" : "Loading";
                    lblInGame.ForeColor = ingame ? Color.Green : Color.DarkGray;
                }
                ));
            inGame = ingame;
        }
    }
}
