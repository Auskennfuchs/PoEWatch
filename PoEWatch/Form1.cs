using Capture;
using Capture.Hook;
using Capture.Hook.Common;
using Capture.Interface;
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
        private CaptureProcess captureProcess;
        private int processId;
        private Timer captureTimer;
        private ScreenCapture screenCapture;
        private System.Drawing.Rectangle captureArea = new Rectangle(0, 960, 100, 20);
        private Bitmap ingameMask, lifeMask, curCapture;
        private volatile bool inGame = false;
        private volatile bool capturing = false;

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

        }

        private void AttachProcess()
        {
            var allProcesses = Process.GetProcessesByName("PathOfExile_x64");//bf3
            foreach (var p in allProcesses)
            {
                if (p.MainWindowHandle == IntPtr.Zero || HookManager.IsHooked(p.Id))
                {
                    continue;
                }
                var direct3DVersion = Direct3DVersion.Direct3D11;
                var cc = new CaptureConfig()
                {
                    Direct3DVersion = direct3DVersion,
                    ShowOverlay = true
                };
                process = p;
                processId = p.Id;

                var captureInterface = new CaptureInterface();
                captureInterface.RemoteMessage += new MessageReceivedEvent(CaptureInterface_RemoteMessage);
                captureProcess = new CaptureProcess(process, cc, captureInterface);
                break;
            }
            Thread.Sleep(10);
            if (captureProcess == null)
            {
                MessageBox.Show("No running executable found.");
            }
        }

        /// <summary>
        /// Display messages from the target process
        /// </summary>
        /// <param name="message"></param>
        void CaptureInterface_RemoteMessage(MessageReceivedEventArgs message)
        {
            txtDebugLog.Invoke(new MethodInvoker(delegate ()
            {
                txtDebugLog.Text = String.Format("{0}\r\n{1}", message, txtDebugLog.Text);
            })
            );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureProcess != null)
            {
                HookManager.RemoveHookedProcess(captureProcess.Process.Id);
                captureProcess.CaptureInterface.Disconnect();
                captureProcess = null;
            }
            if (captureTimer != null)
            {
                captureTimer.Change(-1, -1);
            }
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            AttachProcess();
        }

        private void btnFPS_Click(object sender, EventArgs e)
        {
            captureProcess.CaptureInterface.DrawOverlayInGame(new Overlay
            {
                Elements = new List<Capture.Hook.Common.IOverlayElement>
                {
                    new Capture.Hook.Common.FramesPerSecond(new System.Drawing.Font("Arial", 18, FontStyle.Bold)) {
                            Location = new Point(25, 125),
                            Color = Color.Red,
                            AntiAliased = true,
                            Text = "{0:N0} fps"
                        },
                },
                Hidden = false
            });
        }

        private void btnCaptureScreen_Click(object sender, EventArgs e)
        {
            if (captureTimer == null)
            {
                capturing = true;
                captureTimer = new Timer(state => this.CaptureScreen(), this, 0, 15);
            }
            else
            {
                captureTimer.Change(-1, -1);
                captureTimer.Dispose();
                captureTimer = null;
                lifeMask = null;
                capturing = false;
            }
        }

        private void CaptureScreen()
        {
            if (captureProcess == null)
            {
                return;
            }
            curCapture = (Bitmap)screenCapture.CaptureWindow(captureProcess.Process.MainWindowHandle, captureArea);
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
            ingameMask = new Bitmap(20, curCapture.Height);
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
                    var imageSize = (float)maskRect.Width * maskRect.Height;
                    var image1 = curDisplay.Clone(maskRect, curDisplay.PixelFormat) as Bitmap;
                    var maskDiffImg = GetDifferenceImage(image1, ingameMask, Color.Magenta, out var diffCount);
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
            if (lifeMask == null || curDisplay == null)
            {
                return true;
            }
            lock (curDisplay)
            {
                lock (lifeMask)
                {
                    var maskRect = new Rectangle(0, 0, lifeMask.Width, lifeMask.Height);
                    var imageSize = (float)maskRect.Width * maskRect.Height;
                    var image1 = curDisplay.Clone(maskRect, curDisplay.PixelFormat) as Bitmap;
                    var maskDiffImg = GetDifferenceImage(image1, lifeMask, Color.Magenta, out var diffCount);
                    return diffCount / imageSize <= 0.1f;
                }
            }
        }

        private void DoLogout()
        {
            SetForegroundWindow(captureProcess.Process.MainWindowHandle);
            Thread.Sleep(5);
            for (var i = 0; i < 20; i++)
            {
                SendKeys.Send("{F4}");
            }
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
                    var maskDiffImg = GetDifferenceImage(image1, maskImage, Color.Magenta, out var diffCount);
                    return diffCount / imageSize <= 0.1f;
                }
            }
        }

        public static unsafe Bitmap GetDifferenceImage(Bitmap image1, Bitmap image2, Color matchColor, out int diffCount)
        {
            diffCount = 0;
            if (image1 == null | image2 == null)
                return null;

            if (image1.Height != image2.Height || image1.Width != image2.Width)
                return null;

            var diffImage = image2.Clone() as Bitmap;
            lock (diffImage)
            {

                int height = image2.Height;
                int width = image2.Width;

                var data1 = image1.LockBits(new Rectangle(0, 0, width, height),
                                                   ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                var data2 = image2.LockBits(new Rectangle(0, 0, width, height),
                                                   ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                var diffData = diffImage.LockBits(new Rectangle(0, 0, width, height),
                                                       ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                byte* data1Ptr = (byte*)data1.Scan0;
                byte* data2Ptr = (byte*)data2.Scan0;
                byte* diffPtr = (byte*)diffData.Scan0;

                byte[] swapColor = new byte[4];
                swapColor[0] = matchColor.B;
                swapColor[1] = matchColor.G;
                swapColor[2] = matchColor.R;
                swapColor[3] = matchColor.A;

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

                        // swap color or add new values
                        for (int x = 0; x < 4; x++)
                        {
                            diffPtr[0] = (same == 4) ? tmp[x] : swapColor[x];
                            diffPtr++; // advance diff image ptr
                        }
                    }

                    // at the end of each column, skip extra padding
                    if (rowPadding > 0)
                    {
                        data1Ptr += rowPadding;
                        data2Ptr += rowPadding;
                        diffPtr += rowPadding;
                    }
                }

                image1.UnlockBits(data1);
                image2.UnlockBits(data2);
                diffImage.UnlockBits(diffData);
            }
            return diffImage;
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
