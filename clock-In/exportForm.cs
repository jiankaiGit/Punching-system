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
        private int recordCount = 0;
        TimeSpan ts;
        DateTime dtWorkTimes;
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
            String exportFileName = "";
            recordCount = 0;
            String tempRecordList = "";
            int curHour = 0;
            int curMin = 0;
            if (allRecordCB.Checked)
            {
                for (int index = 0; index < recordList.Items.Count; index++)
                {
                    //get record 日期:2020/8/5 ,時間:上班: 10:31:09,下班: 15:36:08 時數: 05:04
                    String content = recordList.Items[index].ToString();

                    //get work hours
                    if (content.Contains("時數:"))
                    {
                        String workTimes = content.Substring(content.IndexOf("時數:") + 3);
                        curHour += Convert.ToDateTime(workTimes).Hour;
                        curMin += Convert.ToDateTime(workTimes).Minute;
                    }


                    tempRecordList += recordList.Items[index]+"\n";
                    recordCount += 1;


                }

                if(tempRecordList.Length <= 5)
                {
                    MessageBox.Show("無打卡紀錄");
                }
                else
                {
                    String totalTime = convertMinToHours(curHour, curMin);
                    tempRecordList += "\n\n總共時數=" + totalTime;

                    exportFileName = employeeName + "-的所有打卡紀錄.txt";
                    MessageBox.Show("共有" + recordCount + "筆紀錄");
                    saveRecordList(exportFileName, tempRecordList);
                }
            }
            else
            {
                if(!yearCombox.Text.Equals("") && !monthComBox.Text.Equals(""))
                {
                    exportFileName = employeeName + "-" + yearCombox.Text + "年" + monthComBox.Text + "月的打卡紀錄.txt";
                    for (int index = 0; index < recordList.Items.Count; index++)
                    {
                        //get record 日期:2020/8/5 ,時間:上班: 10:31:09,下班: 15:36:08 時數: 05:04
                        String content = recordList.Items[index].ToString();
                        // get date 2020/8/5
                        String date = content.Substring(content.IndexOf("日期:")+3, content.IndexOf(",") - 3);
                        //get year
                        String year = date.Split('-')[0];
                        //get month
                        String month = date.Split('-')[1];




                        if (year.Equals(yearCombox.Text) && month.Equals(monthComBox.Text))
                        {
                            tempRecordList += recordList.Items[index] + "\n";
                            recordCount += 1;

                            if (content.Contains("時數:"))
                            {
                                //get work hours
                                String workTimes = content.Substring(content.IndexOf("時數:") + 3);
                                curHour += Convert.ToDateTime(workTimes).Hour;
                                curMin += Convert.ToDateTime(workTimes).Minute;
                            }
                        }
                    }

                    if (tempRecordList.Length <= 5)
                    {
                        MessageBox.Show("無"+yearCombox.Text+"年"+monthComBox.Text+"月打卡紀錄");
                    }
                    else
                    {
                        MessageBox.Show("共有" + recordCount + "筆紀錄");
                        String totalTime = convertMinToHours(curHour, curMin);
                        tempRecordList += "\n\n總共時數=" + totalTime;
                        saveRecordList(exportFileName, tempRecordList);
                    }
                }
                else
                {
                    MessageBox.Show("請選擇日期");
                }
            }

        }

        private void saveRecordList(String exportFileName, String content)
        {
            SaveFileDialog savefileDialog = new SaveFileDialog();
            savefileDialog.Title = exportFileName;
            savefileDialog.FileName = exportFileName;
            savefileDialog.Filter = "*.txt|";

            // If the file name is not an empty string open it for saving.
            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                FileStream fs = new FileStream(savefileDialog.FileName, FileMode.OpenOrCreate);
                fs.Close();
                StreamWriter sw = new StreamWriter(savefileDialog.FileName, false);
                sw.Write(content);
                sw.Flush();
                sw.Close();
                fs.Close();
                MessageBox.Show("匯出完成");
            }
            else
            {

            }
        }

        private String convertMinToHours(int hours, int min)
        {
            int tempHours = hours + (min / 60);
            int tempMin = min % 60;
            String result = tempHours.ToString() + "小時" + tempMin+"分";
            return result;
        }
    }
}
