namespace WCFChatClient
{
    partial class WaitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm));
            this.pnlError = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.pnlConnecting = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlError.SuspendLayout();
            this.pnlConnecting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlError
            // 
            this.pnlError.BackColor = System.Drawing.Color.Transparent;
            this.pnlError.Controls.Add(this.lblErrorMessage);
            this.pnlError.Controls.Add(this.btnOK);
            this.pnlError.Location = new System.Drawing.Point(30, 22);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(204, 87);
            this.pnlError.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(115, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 21);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Location = new System.Drawing.Point(28, 18);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(89, 12);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "服务器连接失败";
            // 
            // pnlConnecting
            // 
            this.pnlConnecting.BackColor = System.Drawing.Color.Transparent;
            this.pnlConnecting.Controls.Add(this.progressBar1);
            this.pnlConnecting.Controls.Add(this.label1);
            this.pnlConnecting.Location = new System.Drawing.Point(29, 14);
            this.pnlConnecting.Name = "pnlConnecting";
            this.pnlConnecting.Size = new System.Drawing.Size(204, 94);
            this.pnlConnecting.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(186, 18);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "正在连接,请稍后....";
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(259, 120);
            this.Controls.Add(this.pnlConnecting);
            this.Controls.Add(this.pnlError);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitForm";
            this.Text = "WaitForm";
            this.pnlError.ResumeLayout(false);
            this.pnlError.PerformLayout();
            this.pnlConnecting.ResumeLayout(false);
            this.pnlConnecting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Panel pnlConnecting;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}