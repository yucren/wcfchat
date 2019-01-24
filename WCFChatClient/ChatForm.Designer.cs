namespace WCFChatClient
{
    partial class ChatForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.聊天室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InterChatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutInterChatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtChatDetails = new System.Windows.Forms.RichTextBox();
            this.txtChatContent = new System.Windows.Forms.RichTextBox();
            this.btnChat = new System.Windows.Forms.Button();
            this.lbOnlineUsers = new System.Windows.Forms.ListBox();
            this.btnWhisper = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.聊天室ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 聊天室ToolStripMenuItem
            // 
            this.聊天室ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InterChatMenuItem,
            this.OutInterChatMenuItem});
            this.聊天室ToolStripMenuItem.Name = "聊天室ToolStripMenuItem";
            this.聊天室ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.聊天室ToolStripMenuItem.Text = "聊天室";
            // 
            // InterChatMenuItem
            // 
            this.InterChatMenuItem.Name = "InterChatMenuItem";
            this.InterChatMenuItem.Size = new System.Drawing.Size(152, 22);
            this.InterChatMenuItem.Text = "登录聊天室";
            this.InterChatMenuItem.Click += new System.EventHandler(this.InterChatMenuItem_Click);
            // 
            // OutInterChatMenuItem
            // 
            this.OutInterChatMenuItem.Name = "OutInterChatMenuItem";
            this.OutInterChatMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OutInterChatMenuItem.Text = "退出聊天室";
            this.OutInterChatMenuItem.Click += new System.EventHandler(this.OutInterChatMenuItem_Click);
            // 
            // txtChatDetails
            // 
            this.txtChatDetails.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChatDetails.ForeColor = System.Drawing.Color.Black;
            this.txtChatDetails.Location = new System.Drawing.Point(156, 48);
            this.txtChatDetails.Name = "txtChatDetails";
            this.txtChatDetails.Size = new System.Drawing.Size(522, 251);
            this.txtChatDetails.TabIndex = 1;
            this.txtChatDetails.Text = "";
            // 
            // txtChatContent
            // 
            this.txtChatContent.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChatContent.Location = new System.Drawing.Point(156, 309);
            this.txtChatContent.Name = "txtChatContent";
            this.txtChatContent.Size = new System.Drawing.Size(522, 96);
            this.txtChatContent.TabIndex = 2;
            this.txtChatContent.Text = "";
            this.txtChatContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChatContent_KeyPress);
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(380, 421);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(129, 23);
            this.btnChat.TabIndex = 3;
            this.btnChat.Text = "发送群聊信息(Enter)";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // lbOnlineUsers
            // 
            this.lbOnlineUsers.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOnlineUsers.ForeColor = System.Drawing.Color.Red;
            this.lbOnlineUsers.FormattingEnabled = true;
            this.lbOnlineUsers.Location = new System.Drawing.Point(3, 48);
            this.lbOnlineUsers.Name = "lbOnlineUsers";
            this.lbOnlineUsers.Size = new System.Drawing.Size(150, 355);
            this.lbOnlineUsers.TabIndex = 5;
            this.lbOnlineUsers.SelectedIndexChanged += new System.EventHandler(this.lbOnlineUsers_SelectedIndexChanged);
            // 
            // btnWhisper
            // 
            this.btnWhisper.Enabled = false;
            this.btnWhisper.Location = new System.Drawing.Point(532, 421);
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.Size = new System.Drawing.Size(120, 23);
            this.btnWhisper.TabIndex = 4;
            this.btnWhisper.Text = "发送私聊信息";
            this.btnWhisper.UseVisualStyleBackColor = true;
            this.btnWhisper.Click += new System.EventHandler(this.btnWhisper_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "当前在线用户：";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOnlineUsers);
            this.Controls.Add(this.btnWhisper);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.txtChatContent);
            this.Controls.Add(this.txtChatDetails);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(689, 480);
            this.Name = "ChatForm";
            this.Text = "Brian_WCFChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 聊天室ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InterChatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OutInterChatMenuItem;
        private System.Windows.Forms.RichTextBox txtChatDetails;
        private System.Windows.Forms.RichTextBox txtChatContent;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.ListBox lbOnlineUsers;
        private System.Windows.Forms.Button btnWhisper;
        private System.Windows.Forms.Label label1;
    }
}

