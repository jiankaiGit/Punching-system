namespace clock_In
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.allRecordCB = new System.Windows.Forms.CheckBox();
            this.yearCombox = new System.Windows.Forms.ComboBox();
            this.monthComBox = new System.Windows.Forms.ComboBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // allRecordCB
            // 
            this.allRecordCB.AutoSize = true;
            this.allRecordCB.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.allRecordCB.Location = new System.Drawing.Point(12, 12);
            this.allRecordCB.Name = "allRecordCB";
            this.allRecordCB.Size = new System.Drawing.Size(193, 31);
            this.allRecordCB.TabIndex = 0;
            this.allRecordCB.Text = "匯出全部紀錄";
            this.allRecordCB.UseVisualStyleBackColor = true;
            this.allRecordCB.CheckedChanged += new System.EventHandler(this.allRecordCB_CheckedChanged);
            // 
            // yearCombox
            // 
            this.yearCombox.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yearCombox.FormattingEnabled = true;
            this.yearCombox.Location = new System.Drawing.Point(61, 103);
            this.yearCombox.Name = "yearCombox";
            this.yearCombox.Size = new System.Drawing.Size(98, 29);
            this.yearCombox.TabIndex = 1;
            this.yearCombox.SelectedIndexChanged += new System.EventHandler(this.yearCombox_SelectedIndexChanged);
            // 
            // monthComBox
            // 
            this.monthComBox.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthComBox.FormattingEnabled = true;
            this.monthComBox.Location = new System.Drawing.Point(190, 103);
            this.monthComBox.Name = "monthComBox";
            this.monthComBox.Size = new System.Drawing.Size(98, 29);
            this.monthComBox.TabIndex = 2;
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exportBtn.Location = new System.Drawing.Point(125, 158);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(94, 42);
            this.exportBtn.TabIndex = 3;
            this.exportBtn.Text = "匯出";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(61, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "年";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(186, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "月份";
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 264);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.monthComBox);
            this.Controls.Add(this.yearCombox);
            this.Controls.Add(this.allRecordCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "匯出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportForm_FormClosing);
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox allRecordCB;
        private System.Windows.Forms.ComboBox yearCombox;
        private System.Windows.Forms.ComboBox monthComBox;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}