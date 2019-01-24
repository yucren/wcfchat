using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ServiceModel;
using WCFChatClient.ServiceReference1;

namespace WCFChatClient
{
    public partial class ChatForm : Form, IMyMessageCallback
    {
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        //当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;
        private int lastSelectedIndex = -1;

        private ServiceReference1.MyMessageClient proxy;
        private string userName;

        private WaitForm wfDlg = new WaitForm();
        private delegate void HandleDelegate(string[] list);
        private delegate void HandleErrorDelegate();

        public ChatForm()
        {
            InitializeComponent();
            ShowInterChatMenuItem(true);
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        private void InterChatMenuItem_Click(object sender, EventArgs e)
        {
            lbOnlineUsers.Items.Clear();
            LoginForm loginDlg = new LoginForm();
            if (loginDlg.ShowDialog() == DialogResult.OK)
            {
                userName = loginDlg.txtUserName.Text;
                loginDlg.Close();
            }

            txtChatContent.Focus();
            Application.DoEvents();
            InstanceContext site = new InstanceContext(this);//为实现服务实例的对象进行初始化
            proxy = new ServiceReference1.MyMessageClient(site);
            
            IAsyncResult iar = proxy.BeginJoin(userName, new AsyncCallback(OnEndJoin), null);
            wfDlg.ShowDialog();
        }

        private void OnEndJoin(IAsyncResult iar)
        {
            try
            {
                string[] list = proxy.EndJoin(iar);
                HandleEndJoin(list);

            }
            catch (Exception e)
            {
                HandleEndJoinError();
            }

        }
        /// <summary>
        /// 错误提示
        /// </summary>
        private void HandleEndJoinError()
        {
            if (wfDlg.InvokeRequired)
                wfDlg.Invoke(new HandleErrorDelegate(HandleEndJoinError));
            else
            {
                wfDlg.ShowError("无法连接聊天室!");
                ExitChatSession();
            }
        }
        /// <summary>
        /// 登录结束后的处理
        /// </summary>
        /// <param name="list"></param>
        private void HandleEndJoin(string[] list)
        {
            if (wfDlg.InvokeRequired)
                wfDlg.Invoke(new HandleDelegate(HandleEndJoin), new object[] { list });
            else
            {
                wfDlg.Visible = false;
                ShowInterChatMenuItem(false);
                foreach (string name in list)
                {
                    lbOnlineUsers.Items.Add(name);
                }
                AppendText(" 用户: " + userName + "--------登录---------" + DateTime.Now.ToString()+ Environment.NewLine);
            }
        }
        /// <summary>
        /// 退出聊天室
        /// </summary>
        private void OutInterChatMenuItem_Click(object sender, EventArgs e)
        {
            ExitChatSession();
            Application.Exit();
        }
        /// <summary>
        /// 群聊
        /// </summary>
        private void btnChat_Click(object sender, EventArgs e)
        {
            SayAndClear("", txtChatContent.Text, false);
            txtChatContent.Focus();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        private void SayAndClear(string to, string msg, bool pvt)
        {
            if (msg != "")
            {
                try
                {
                    CommunicationState cs = proxy.State;
                    //pvt 公聊还是私聊
                    if (!pvt)
                    {
                        proxy.Say(msg);
                    }
                    else
                    {
                        proxy.Whisper(to, msg);
                    }

                    txtChatContent.Text = "";
                }
                catch
                {
                    AbortProxyAndUpdateUI();
                    AppendText("失去连接： " + DateTime.Now.ToString() + Environment.NewLine);
                    ExitChatSession();
                }
            }
        }
        private void txtChatContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnChat.PerformClick();
            }
        }
        /// <summary>
        /// 只有选择一个用户时，私聊按钮才可用
        /// </summary>
        private void lbOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustWhisperButton();
        }
        /// <summary>
        /// 私聊
        /// </summary>       
        private void btnWhisper_Click(object sender, EventArgs e)
        {
            if (txtChatDetails.Text == "")
            {
                return;
            }
            object to = lbOnlineUsers.SelectedItem;
            if (to != null)
            {
                string receiverName = (string)to;
                AppendText("私下对" + receiverName + "说: " + txtChatContent.Text);//+ Environment.NewLine
                SayAndClear(receiverName, txtChatContent.Text, true);
                txtChatContent.Focus();
            }
        }
        /// <summary>
        /// 连接聊天室
        /// </summary>
        private void ShowInterChatMenuItem(bool show)
        {
            InterChatMenuItem.Enabled = show;
            OutInterChatMenuItem.Enabled = this.btnChat.Enabled = !show;
        }
        private void AppendText(string text)
        {
            txtChatDetails.Text += text;
            SendMessage(txtChatDetails.Handle, WM_VSCROLL, SB_BOTTOM, new IntPtr(0));
        }
        /// <summary>
        /// 退出应用程序时,释放使用资源
        /// </summary>
        private void ExitChatSession()
        {
            try
            {
                proxy.Leave();
            }
            catch { }
            finally
            {
                AbortProxyAndUpdateUI();
            }
        }
        /// <summary>
        /// 释放使用资源
        /// </summary>
        private void AbortProxyAndUpdateUI()
        {
            if (proxy != null)
            {
                proxy.Abort();
                proxy.Close();
                proxy = null;
            }
            ShowInterChatMenuItem(true);
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        public void Receive(string senderName, string message)
        {
            AppendText(senderName + "说: " + message + Environment.NewLine);
        }
        /// <summary>
        /// 接收私聊消息
        /// </summary>
        public void ReceiveWhisper(string senderName, string message)
        {
            AppendText(senderName + " 私下说: " + message + Environment.NewLine);
        }
        /// <summary>
        /// 新用户登录
        /// </summary>
        public void UserEnter(string name)
        {
            AppendText("用户 " + name + " --------登录---------" + DateTime.Now.ToString() + Environment.NewLine);
            lbOnlineUsers.Items.Add(name);
        }
        /// <summary>
        /// 用户离开
        /// </summary>
        public void UserLeave(string name)
        {
            AppendText("用户 " + name + " --------离开---------" + DateTime.Now.ToString() + Environment.NewLine);
            lbOnlineUsers.Items.Remove(name);
            AdjustWhisperButton();
        }
        /// <summary>
        /// 控制私聊按钮的可用性,只有选择了用户时按钮才可用
        /// </summary>
        private void AdjustWhisperButton()
        {
            if (lbOnlineUsers.SelectedIndex == lastSelectedIndex)
            {
                lbOnlineUsers.SelectedIndex = -1;
                lastSelectedIndex = -1;
                btnWhisper.Enabled = false;
            }
            else
            {
                btnWhisper.Enabled = true;
                lastSelectedIndex = lbOnlineUsers.SelectedIndex;
            }

            txtChatContent.Focus();
        }
        /// <summary>
        /// 窗体关闭时，释放使用资源
        /// </summary>
        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AbortProxyAndUpdateUI();
            Application.Exit();
        }

        public void OnCallback(string message)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOnCallback(string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndOnCallback(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceive(string senderName, string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceive(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceiveWhisper(string senderName, string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceiveWhisper(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserEnter(string name, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserEnter(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserLeave(string name, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserLeave(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}
