namespace clock_In
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.clockBtn = new System.Windows.Forms.Button();
            this.dataInfo = new System.Windows.Forms.ListBox();
            this.nameInputCB = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wantExportBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clockBtn
            // 
            this.clockBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.clockBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockBtn.Location = new System.Drawing.Point(138, 27);
            this.clockBtn.Name = "clockBtn";
            this.clockBtn.Size = new System.Drawing.Size(102, 37);
            this.clockBtn.TabIndex = 3;
            this.clockBtn.Text = "打卡";
            this.clockBtn.UseVisualStyleBackColor = true;
            this.clockBtn.Click += new System.EventHandler(this.clockBtn_Click);
            // 
            // dataInfo
            // 
            this.dataInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInfo.FormattingEnabled = true;
            this.dataInfo.ItemHeight = 24;
            this.dataInfo.Location = new System.Drawing.Point(12, 70);
            this.dataInfo.Name = "dataInfo";
            this.dataInfo.Size = new System.Drawing.Size(554, 244);
            this.dataInfo.TabIndex = 10;
            // 
            // nameInputCB
            // 
            this.nameInputCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInputCB.FormattingEnabled = true;
            this.nameInputCB.Location = new System.Drawing.Point(12, 27);
            this.nameInputCB.Name = "nameInputCB";
            this.nameInputCB.Size = new System.Drawing.Size(120, 37);
            this.nameInputCB.TabIndex = 11;
            this.nameInputCB.Text = "選擇員工";
            this.nameInputCB.SelectedIndexChanged += new System.EventHandler(this.nameInputCB_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newNameToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(578, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newNameToolStripMenuItem
            // 
            this.newNameToolStripMenuItem.Name = "newNameToolStripMenuItem";
            this.newNameToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.newNameToolStripMenuItem.Text = "新增員工";
            this.newNameToolStripMenuItem.Click += new System.EventHandler(this.newNameToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.AboutToolStripMenuItem.Text = "關於";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // wantExportBtn
            // 
            this.wantExportBtn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.wantExportBtn.Location = new System.Drawing.Point(443, 27);
            this.wantExportBtn.Name = "wantExportBtn";
            this.wantExportBtn.Size = new System.Drawing.Size(123, 36);
            this.wantExportBtn.TabIndex = 13;
            this.wantExportBtn.Text = "匯出紀錄";
            this.wantExportBtn.UseVisualStyleBackColor = true;
            this.wantExportBtn.Visible = false;
            this.wantExportBtn.Click += new System.EventHandler(this.wantExportBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 372);
            this.Controls.Add(this.wantExportBtn);
            this.Controls.Add(this.nameInputCB);
            this.Controls.Add(this.dataInfo);
            this.Controls.Add(this.clockBtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "興盛打卡系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button clockBtn;
        private System.Windows.Forms.ListBox dataInfo;
        private System.Windows.Forms.ComboBox nameInputCB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.Button wantExportBtn;
    }
}

