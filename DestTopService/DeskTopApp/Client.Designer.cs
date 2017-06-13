namespace DeskTopApp
{
    partial class Client
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.StartBtn = new System.Windows.Forms.Button();
            this.SettingBtn = new System.Windows.Forms.Button();
            this.ConnectedInfoLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowFormMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(23, 42);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(157, 61);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "启动";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // SettingBtn
            // 
            this.SettingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingBtn.Location = new System.Drawing.Point(150, 3);
            this.SettingBtn.Name = "SettingBtn";
            this.SettingBtn.Size = new System.Drawing.Size(42, 23);
            this.SettingBtn.TabIndex = 1;
            this.SettingBtn.Text = "设置";
            this.SettingBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SettingBtn.UseVisualStyleBackColor = true;
            this.SettingBtn.Click += new System.EventHandler(this.SettingBtn_Click);
            // 
            // ConnectedInfoLabel
            // 
            this.ConnectedInfoLabel.AutoSize = true;
            this.ConnectedInfoLabel.Location = new System.Drawing.Point(21, 113);
            this.ConnectedInfoLabel.Name = "ConnectedInfoLabel";
            this.ConnectedInfoLabel.Size = new System.Drawing.Size(53, 12);
            this.ConnectedInfoLabel.TabIndex = 2;
            this.ConnectedInfoLabel.Text = "连接失败";
            this.ConnectedInfoLabel.Visible = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "DestTopClient";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowFormMenuItem,
            this.StartMenuItem,
            this.SettingMenuItem,
            this.CloseMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // StartMenuItem
            // 
            this.StartMenuItem.Name = "StartMenuItem";
            this.StartMenuItem.Size = new System.Drawing.Size(152, 22);
            this.StartMenuItem.Text = "启动";
            this.StartMenuItem.Click += new System.EventHandler(this.StartMenuItem_Click);
            // 
            // SettingMenuItem
            // 
            this.SettingMenuItem.Name = "SettingMenuItem";
            this.SettingMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SettingMenuItem.Text = "系统设置";
            this.SettingMenuItem.Click += new System.EventHandler(this.SettingMenuItem_Click);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CloseMenuItem.Text = "退出";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // ShowFormMenuItem
            // 
            this.ShowFormMenuItem.Name = "ShowFormMenuItem";
            this.ShowFormMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ShowFormMenuItem.Text = "显示窗体";
            this.ShowFormMenuItem.Click += new System.EventHandler(this.ShowFormMenuItem_Click);
            // 
            // Client
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(204, 134);
            this.Controls.Add(this.ConnectedInfoLabel);
            this.Controls.Add(this.SettingBtn);
            this.Controls.Add(this.StartBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "Client";
            this.Text = "远程桌面协助";
            this.Load += new System.EventHandler(this.Client_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button SettingBtn;
        private System.Windows.Forms.Label ConnectedInfoLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowFormMenuItem;
    }
}

