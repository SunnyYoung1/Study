namespace DeskTopApp
{
    partial class SettingForm
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
            this.AutoStartCheckBox = new System.Windows.Forms.CheckBox();
            this.SettingSaveBtn = new System.Windows.Forms.Button();
            this.SeverIpTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerPortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AutoStartCheckBox
            // 
            this.AutoStartCheckBox.AutoSize = true;
            this.AutoStartCheckBox.Location = new System.Drawing.Point(12, 12);
            this.AutoStartCheckBox.Name = "AutoStartCheckBox";
            this.AutoStartCheckBox.Size = new System.Drawing.Size(108, 16);
            this.AutoStartCheckBox.TabIndex = 0;
            this.AutoStartCheckBox.Text = "系统启动时启动";
            this.AutoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingSaveBtn
            // 
            this.SettingSaveBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.SettingSaveBtn.Location = new System.Drawing.Point(12, 156);
            this.SettingSaveBtn.Name = "SettingSaveBtn";
            this.SettingSaveBtn.Size = new System.Drawing.Size(51, 23);
            this.SettingSaveBtn.TabIndex = 1;
            this.SettingSaveBtn.Text = "保存";
            this.SettingSaveBtn.UseVisualStyleBackColor = true;
            this.SettingSaveBtn.Click += new System.EventHandler(this.SettingSaveBtn_Click);
            // 
            // SeverIpTextBox
            // 
            this.SeverIpTextBox.Location = new System.Drawing.Point(83, 51);
            this.SeverIpTextBox.Name = "SeverIpTextBox";
            this.SeverIpTextBox.Size = new System.Drawing.Size(120, 21);
            this.SeverIpTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "服务器Ip";
            // 
            // ServerPortTextBox
            // 
            this.ServerPortTextBox.Location = new System.Drawing.Point(83, 108);
            this.ServerPortTextBox.Name = "ServerPortTextBox";
            this.ServerPortTextBox.Size = new System.Drawing.Size(120, 21);
            this.ServerPortTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "服务器端口";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 205);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerPortTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SeverIpTextBox);
            this.Controls.Add(this.SettingSaveBtn);
            this.Controls.Add(this.AutoStartCheckBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AutoStartCheckBox;
        private System.Windows.Forms.Button SettingSaveBtn;
        private System.Windows.Forms.TextBox SeverIpTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerPortTextBox;
        private System.Windows.Forms.Label label2;
    }
}