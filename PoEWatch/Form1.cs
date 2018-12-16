using Capture;
using Capture.Hook;
using Capture.Hook.Common;
using Capture.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private System.Drawing.Rectangle captureArea = new Rectangle(0, 950, 100, 30);
        private Bitmap ingameMask;

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

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
                captureTimer = new Timer(state => this.CaptureScreen(), this, 0, 15);
            }
            else
            {
                captureTimer.Change(-1, -1);
                captureTimer.Dispose();
                captureTimer = null;
            }
        }

        private void CaptureScreen()
        {
            if(captureProcess==null)
            {
                return;
            }
            var targetBitmap = (Bitmap)screenCapture.CaptureWindow(captureProcess.Process.MainWindowHandle, captureArea);
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = targetBitmap;
                    }
                    ));
            }
            else
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = targetBitmap;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SetForegroundWindow(captureProcess.Process.MainWindowHandle);
            Thread.Sleep(5);
            for (var i = 0; i < 20; i++)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void btnIngameMask_Click(object sender, EventArgs e)
        {
            ingameMask?.Dispose();
            var picBoxImg = pictureBox1.Image;
            ingameMask = new Bitmap(20, picBoxImg.Height);
            var g = Graphics.FromImage(ingameMask);
            g.DrawImage(picBoxImg, 0, 0);
            ingameMaskPicture.Invoke(new MethodInvoker(
                delegate ()
                {
                    ingameMaskPicture.Image?.Dispose();
                    ingameMaskPicture.Image = ingameMask;
                }));
        }
    }
}
