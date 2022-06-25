using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KeyGrabAndSend;

namespace TestHarness
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void RefreshProcessList()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(RefreshProcessList));
            }
            else
            {
                lstProcesses.Items.Clear();
                lstProcesses.Items.AddRange(GetRunningProcesses());
            }
        }

        private string[] GetRunningProcesses()
        {
            Process[] procs = Process.GetProcesses();

            List<string> ProcessNames = new List<string>();

            foreach (Process proc in procs)
            {
                ProcessNames.Add(proc.ProcessName);
            }

            ProcessNames.Sort();

            return ProcessNames.ToArray();
        }

        private void cmdSendMessage_Click(object sender, EventArgs e)
        {
            if ((string)lstProcesses.SelectedItem != null)
            {
                if (KeySend.SendToWindow((string)lstProcesses.SelectedItem, txtMessage.Text))
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            else
            {
                MessageBox.Show("Select a process first!");
            }
        }

        private void cmdRefreshList_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void KeyPushHandler(int vkCode)
        {
            Console.WriteLine(String.Format("Keypress grabbed: (int){0}, (Keys){1}", vkCode, (Keys)vkCode));
            if ((string)lstProcesses.SelectedItem != null)
            {
                if ((chkSendOnlyMediaKeys.Checked == false) ||
                    ((vkCode >= (int)Keys.MediaNextTrack) && (vkCode <= (int)Keys.MediaPlayPause)))
                {
                    if (KeySend.SendToWindow((string)lstProcesses.SelectedItem, new[] { vkCode }) == false)
                    {
                        cmdDisableForward_Click(this, null);
                        RefreshProcessList();
                    }
                }
            }
        }

        private void cmdEnableForward_Click(object sender, EventArgs e)
        {
            if ((string)lstProcesses.SelectedItem != null)
            {
                KeyGrab.StartGrab();
                KeyGrab.KeyPushedEvent += KeyPushHandler;

                cmdDisableForward.Enabled = true;
                cmdEnableForward.Enabled = false;
            }
            else
            {
                MessageBox.Show("Select a process first!");
            }
        }

        private void cmdDisableForward_Click(object sender, EventArgs e)
        {
            KeyGrab.KeyPushedEvent -= KeyPushHandler;
            KeyGrab.StopGrab();

            cmdEnableForward.Enabled = true;
            cmdDisableForward.Enabled = false;
        }
    }
}
