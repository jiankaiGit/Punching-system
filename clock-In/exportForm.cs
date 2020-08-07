using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock_In
{
    public partial class ExportForm : Form
    {
        private bool isAllRecord = false;
        private Form1 mainForm;
        private ListBox recordList;
        private String employeeName;
        public ExportForm(Form1 form1)
        {
            InitializeComponent();

            mainForm = form1;
            allRecordCB.Checked = true;
            recordCheckHandler(true);
        }

        public void SetRecord(ListBox list)
        {
            recordList = list;
        }

        public void SetName(String name)
        {
            employeeName = name;
            this.Text = name;
            allRecordCB.Text = "匯出 [" + name + "] 的全部記錄";
        }

        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
        }

        private void allRecordCB_CheckedChanged(object sender, EventArgs e)
        {
            recordCheckHandler(allRecordCB.Checked);
        }



        private void yearCombox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void recordCheckHandler(bool check)
        {
            if (check)
            {
                yearCombox.Enabled = false;
                monthComBox.Enabled = false;
            }
            else
            {
                yearCombox.Enabled = true;
                monthComBox.Enabled = true;
            }
        }

        private void InitYearAndMonthCombox()
        {
            //init year
            for(int i= 2020; i < 2120; i++)
            {
                yearCombox.Items.Add(i.ToString());
            }

            yearCombox.DropDownHeight = 300;
            //init month
            for(int j = 1; j < 13; j++)
            {
                monthComBox.Items.Add(j.ToString());
            }
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            InitYearAndMonthCombox();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            String exportFileSavePath = "";
            SaveFileDialog savefileDialog = new SaveFileDialog();
            String tempRecordList = "";
            if (allRecordCB.Checked)
            {
                for (int index = 0; index < recordList.Items.Count; index++)
                {
                    tempRecordList += recordList.Items[index]+"\n";
                }
                exportFileSavePath = employeeName + "-的所有紀錄.txt";
            }
            else
            {
                exportFileSavePath = employeeName + "-" + yearCombox.SelectedText + "/" + monthComBox.SelectedText+"的紀錄.txt";
            }
            savefileDialog.Title = exportFileSavePath;
            savefileDialog.FileName = exportFileSavePath;
            savefileDialog.Filter = "*.txt|";
            savefileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (savefileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                FileStream fs = new FileStream(savefileDialog.FileName, FileMode.OpenOrCreate);
                fs.Close();
                StreamWriter sw = new StreamWriter(savefileDialog.FileName, false);
                sw.Write(tempRecordList);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }
    }
}
