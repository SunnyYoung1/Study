namespace WatchScreen_Server
{
    partial class WatchScreenForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchScreenForm));
            this.pbScreen = new System.Windows.Forms.PictureBox();
            this.btnHandleService = new System.Windows.Forms.Button();
            this.lbClientIps = new System.Windows.Forms.ListView();
            this.MenuIpSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiWatchInTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWatchHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.Lit_Msg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLocalIp = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            this.MenuIpSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbScreen
            // 
            this.pbScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScreen.Image = ((System.Drawing.Image)(resources.GetObject("pbScreen.Image")));
            this.pbScreen.Location = new System.Drawing.Point(156, 63);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(931, 610);
            this.pbScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbScreen.TabIndex = 0;
            this.pbScreen.TabStop = false;
            // 
            // btnHandleService
            // 
            this.btnHandleService.Location = new System.Drawing.Point(11, 12);
            this.btnHandleService.Name = "btnHandleService";
            this.btnHandleService.Size = new System.Drawing.Size(87, 23);
            this.btnHandleService.TabIndex = 1;
            this.btnHandleService.Text = "启动服务...";
            this.btnHandleService.UseVisualStyleBackColor = true;
            this.btnHandleService.Click += new System.EventHandler(this.btnHandleService_Click);
            // 
            // lbClientIps
            // 
            this.lbClientIps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbClientIps.ContextMenuStrip = this.MenuIpSelect;
            this.lbClientIps.Location = new System.Drawing.Point(12, 63);
            this.lbClientIps.Name = "lbClientIps";
            this.lbClientIps.Size = new System.Drawing.Size(141, 610);
            this.lbClientIps.TabIndex = 3;
            this.lbClientIps.UseCompatibleStateImageBehavior = false;
            this.lbClientIps.View = System.Windows.Forms.View.List;
            this.lbClientIps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbClientIps_MouseDoubleClick);
            this.lbClientIps.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbClientIps_MouseMove);
            // 
            // MenuIpSelect
            // 
            this.MenuIpSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWatchInTime,
            this.tsmiWatchHistory});
            this.MenuIpSelect.Name = "MenuIpSelect";
            this.MenuIpSelect.Size = new System.Drawing.Size(119, 48);
            // 
            // tsmiWatchInTime
            // 
            this.tsmiWatchInTime.Name = "tsmiWatchInTime";
            this.tsmiWatchInTime.Size = new System.Drawing.Size(118, 22);
            this.tsmiWatchInTime.Text = "即时监控";
            this.tsmiWatchInTime.Click += new System.EventHandler(this.tsmiWatchInTime_Click);
            // 
            // tsmiWatchHistory
            // 
            this.tsmiWatchHistory.Name = "tsmiWatchHistory";
            this.tsmiWatchHistory.Size = new System.Drawing.Size(118, 22);
            this.tsmiWatchHistory.Text = "历史记录";
            this.tsmiWatchHistory.Click += new System.EventHandler(this.tsmiWatchHistory_Click);
            // 
            // Lit_Msg
            // 
            this.Lit_Msg.AutoSize = true;
            this.Lit_Msg.Location = new System.Drawing.Point(163, 369);
            this.Lit_Msg.Name = "Lit_Msg";
            this.Lit_Msg.Size = new System.Drawing.Size(0, 12);
            this.Lit_Msg.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 5;
            // 
            // lbLocalIp
            // 
            this.lbLocalIp.AutoSize = true;
            this.lbLocalIp.Location = new System.Drawing.Point(107, 17);
            this.lbLocalIp.Name = "lbLocalIp";
            this.lbLocalIp.Size = new System.Drawing.Size(101, 12);
            this.lbLocalIp.TabIndex = 6;
            this.lbLocalIp.Text = "192.168.1.1:8888";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(214, 17);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(65, 12);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "未启动服务";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "客户端列表:";
            // 
            // WatchScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1096, 683);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbLocalIp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lit_Msg);
            this.Controls.Add(this.lbClientIps);
            this.Controls.Add(this.btnHandleService);
            this.Controls.Add(this.pbScreen);
            this.Name = "WatchScreenForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户端监控平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WatchScreenForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            this.MenuIpSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScreen;
        private System.Windows.Forms.Button btnHandleService;
        private System.Windows.Forms.ListView lbClientIps;
        private System.Windows.Forms.Label Lit_Msg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLocalIp;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip MenuIpSelect;
        private System.Windows.Forms.ToolStripMenuItem tsmiWatchInTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiWatchHistory;
    }
}

