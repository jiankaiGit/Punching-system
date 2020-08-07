using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock_In
{

    public partial class AddNameMsg : Form
    {
        public String newName { get; set; }
        private Form1 mainForm;
        public AddNameMsg(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newName = newNameText.Text;
            if(mainForm != null)
            {
                if (newName.Equals(""))
                {
                    MessageBox.Show("請輸入姓名");
                }
                else
                {
                    if (mainForm.checkNameExist(newName))
                    {
                        MessageBox.Show("員工已加入，或名字相同!");
                    }
                    else
                    {
                        string savePath = System.Windows.Forms.Application.StartupPath;
                        mainForm.employeeList.Add(newName);
                        mainForm.WriteNewEmpolyee(savePath,newName);
                        MessageBox.Show("加入成功");
                    }
                }
            }
        }

        private void AddNameMsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
