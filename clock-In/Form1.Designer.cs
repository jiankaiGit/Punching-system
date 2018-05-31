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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.clockBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.addNew = new System.Windows.Forms.Button();
            this.employeeState = new System.Windows.Forms.Label();
            this.dataInfo = new System.Windows.Forms.ListBox();
            this.nameInputCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.Location = new System.Drawing.Point(22, 68);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 35);
            this.nameInput.TabIndex = 1;
            this.nameInput.Text = "輸入性名";
            // 
            // clockBtn
            // 
            this.clockBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.clockBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clockBtn.Location = new System.Drawing.Point(128, 173);
            this.clockBtn.Name = "clockBtn";
            this.clockBtn.Size = new System.Drawing.Size(192, 83);
            this.clockBtn.TabIndex = 3;
            this.clockBtn.Text = "打卡";
            this.clockBtn.UseVisualStyleBackColor = true;
            this.clockBtn.Click += new System.EventHandler(this.clockBtn_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.title.Location = new System.Drawing.Point(12, 10);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(122, 55);
            this.title.TabIndex = 4;
            this.title.Text = "興盛";
            // 
            // addNew
            // 
            this.addNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNew.Location = new System.Drawing.Point(128, 68);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(192, 68);
            this.addNew.TabIndex = 7;
            this.addNew.Text = "加入新員工";
            this.addNew.UseVisualStyleBackColor = true;
            this.addNew.Click += new System.EventHandler(this.addNew_Click);
            // 
            // employeeState
            // 
            this.employeeState.AutoSize = true;
            this.employeeState.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeState.Location = new System.Drawing.Point(140, 10);
            this.employeeState.Name = "employeeState";
            this.employeeState.Size = new System.Drawing.Size(61, 29);
            this.employeeState.TabIndex = 8;
            this.employeeState.Text = "狀態";
            // 
            // dataInfo
            // 
            this.dataInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInfo.FormattingEnabled = true;
            this.dataInfo.ItemHeight = 24;
            this.dataInfo.Location = new System.Drawing.Point(326, 10);
            this.dataInfo.Name = "dataInfo";
            this.dataInfo.Size = new System.Drawing.Size(591, 268);
            this.dataInfo.TabIndex = 10;
            // 
            // nameInputCB
            // 
            this.nameInputCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInputCB.FormattingEnabled = true;
            this.nameInputCB.Location = new System.Drawing.Point(22, 173);
            this.nameInputCB.Name = "nameInputCB";
            this.nameInputCB.Size = new System.Drawing.Size(100, 37);
            this.nameInputCB.TabIndex = 11;
            this.nameInputCB.Text = "Name";
            this.nameInputCB.SelectedIndexChanged += new System.EventHandler(this.nameInputCB_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 304);
            this.Controls.Add(this.nameInputCB);
            this.Controls.Add(this.dataInfo);
            this.Controls.Add(this.employeeState);
            this.Controls.Add(this.addNew);
            this.Controls.Add(this.title);
            this.Controls.Add(this.clockBtn);
            this.Controls.Add(this.nameInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "興盛打卡系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Button clockBtn;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button addNew;
        private System.Windows.Forms.Label employeeState;
        private System.Windows.Forms.ListBox dataInfo;
        private System.Windows.Forms.ComboBox nameInputCB;
    }
}

