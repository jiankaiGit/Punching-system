﻿using System;
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

    public partial class Form1 : Form
    {
        public class EmployeeData
        {
            public string Date { get; set; }
            public List<string> Time { get; set; }
            public int TotalWorkTime { get; set; }
        }

        public List<string> employeeList = new List<string>();
        string type = "";
        string selectedName = "";
        public Form1()
        {
            InitializeComponent();
            ContextMenu contextMenu = new ContextMenu();
            MenuItem notifyIconMenuItem1 = new MenuItem();
            //可以設定是否可勾選
            notifyIconMenuItem1.Checked = true;
             //在NotifyIcon中的頁籤，順序用
            notifyIconMenuItem1.Index = 1;
            //設定顯示的文字，後面的(S&)代表使用者按S鍵也可以觸發Click事件!
            notifyIconMenuItem1.Text = "關閉";
            //設定按下後的事情
            notifyIconMenuItem1.Click += (sender, e) => {
                this.Close();
            };
            //將MenuItem加入到ContextMenu容器中!
            contextMenu.MenuItems.Add(notifyIconMenuItem1);
            //設定notifyIcon的選單內容等於剛剛宣告的選單容器ContextMen;
            notifyIcon1.ContextMenu = contextMenu;
        }

        private void clockBtn_Click(object sender, EventArgs e)
        {
            string savePath = System.Windows.Forms.Application.StartupPath;
            string dateAndTime = DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss"); // 2017-03-4 20:02:10
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            WriteClockRecord(savePath, selectedName,dateAndTime,date,time);
        }

        public void WriteClockRecord(string savePath, string name, string record, string date, string time)
        {
            EmployeeData empData = new EmployeeData();
            List<string> tempTime = new List<string>();
            string allTime = null;
            string recordData = null;
            Boolean dateExist = false;
            if (checkNameExist(name))
            {
                string fullPath = savePath + "/紀錄/員工打卡紀錄/" + name + ".txt";
                if (File.Exists(fullPath))
                {
                    StreamReader sr = new StreamReader(fullPath);

                    string readLine;
                    while ((readLine = sr.ReadLine()) != null)
                    {
                        String readData = readLine.Substring(readLine.IndexOf("日期:") + 3, readLine.IndexOf(",") -3).Replace(" ","");
                        //有打過卡的日期
                        if (readData.Equals(date))
                        {
                            recordData = "," + time;
                            dateExist = true;
                            Console.WriteLine(recordData);
                        }
                        else
                        {
                            recordData = "日期:" + date + "," + "時間:" + time;
                            dateExist = false;
                            
                        }
                    }
                    sr.Close();
                    StreamWriter sw = new StreamWriter(fullPath, append:true);
                    if (dateExist)
                    {
                        sw.Write(recordData);
                    }
                    else
                    {
                        sw.Write("\n"+recordData);
                    }


                    sw.Flush();
                    sw.Close();
                    ReadEmployeeClockRecord(savePath, name);
                }
                else
                {
                    FileStream fs = new FileStream(fullPath, FileMode.Create);
                    fs.Close();
                    recordData = "日期:" + date + "," + "時間:" + time;
                    StreamWriter sw = new StreamWriter(fullPath, true);
                    sw.Write(recordData);
                    sw.Flush();
                    sw.Close();
                    ReadEmployeeClockRecord(savePath, name);

                }
                MessageBox.Show("打卡成功");
            }
            else
            {
                MessageBox.Show("員工不存在");
            }

        }

        public void WriteNewEmpolyee(string savePath, string name)
        {
                string fullPath = savePath + "/紀錄/員工列表.txt";
                FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate);
                fs.Close();
                StreamWriter sw = new StreamWriter(fullPath,true);
                sw.WriteLine(name);
                sw.Flush();
                sw.Close();
                nameInputCB.Items.Add(name);
        }

        public void ReadEmployeeList(string path)
        {
            string fullPath = path + "/紀錄/員工列表.txt";
            if (File.Exists(fullPath))
            {
                StreamReader sr = new StreamReader(fullPath);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    employeeList.Add(line);
                    nameInputCB.Items.Add(line);
                    Console.WriteLine(line.ToString());
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("無員工");
            }

        }

        public void ReadEmployeeClockRecord(string path,string name)
        {
            string fullPath = path + "/紀錄/員工打卡紀錄/" + name + ".txt";
            string tempRecord = "";
            string tmpTime = null;
            DateTime dt1, dt2;
            dataInfo.Items.Clear();
            if (File.Exists(fullPath))
            {
                StreamReader sr = new StreamReader(fullPath);
                String line;
                string firstTime, lastTime, totalTime;
                List<string> timeTemp = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    tmpTime = line.Substring(line.IndexOf("時間:")+3);
                    if (tmpTime.Contains(','))
                    {
                        timeTemp = tmpTime.Split(',').ToList();
                        firstTime = timeTemp[0];
                        lastTime = timeTemp[timeTemp.Count()-1];
                        dt1 = Convert.ToDateTime(firstTime);
                        dt2 = Convert.ToDateTime(lastTime);
                        TimeSpan ts = dt2 - dt1;
                        tempRecord = line.Substring(0, 16)+ "上班: "+firstTime+",下班: "+lastTime+" 時數: "+ts.ToString().Substring(0,5);

                    }
                    else
                    {
                        tempRecord = line.Insert(16, "上班: ")+" 時數: 00:00";
                    }

                    Console.WriteLine(line.ToString());
                    dataInfo.Items.Add(tempRecord);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("無打卡紀錄");
            }

        }

        public Boolean checkNameExist(string name)
        {
            foreach (string ExistName in employeeList) 
            {
                if (ExistName.Equals(name)) {
                    return true;
                }
            }
            
            if (name == null || name.Equals("輸入性名") || name.Equals("")) 
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string savePath = System.Windows.Forms.Application.StartupPath;
            if (!Directory.Exists(savePath + "/紀錄"))
            {
                Directory.CreateDirectory(savePath+"/紀錄");
                Directory.CreateDirectory(savePath + "/紀錄/員工打卡紀錄");
            }
            ReadEmployeeList(savePath);
        }

        private void nameInputCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string savePath = System.Windows.Forms.Application.StartupPath;
            selectedName = nameInputCB.SelectedItem.ToString();
            //get employee record
            ReadEmployeeClockRecord(savePath, selectedName);

            //set export button visible
            wantExportBtn.Visible = true;
            Console.WriteLine(selectedName);
        }

        private void newNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNameMsg addNameMsg = new AddNameMsg(this);
            addNameMsg.Show();
            this.Enabled = false;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本:1.2.0");
        }

        private void wantExportBtn_Click(object sender, EventArgs e)
        {
            ExportForm exportForm = new ExportForm(this);
            exportForm.SetRecord(dataInfo);
            exportForm.SetName(selectedName);
            exportForm.Show();
            this.Enabled = false;
        }

        private void GotoTooList(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) 
            {
                e.Cancel = true;
                this.Hide();
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
                notifyIcon1.Text = "興盛打卡系統";
                notifyIcon1.Tag = string.Empty;
                notifyIcon1.ShowBalloonTip(3000, "興盛打卡系統", "我在這裡唷!!!", ToolTipIcon.Info);
            
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 還原視窗, 隱藏佇列圖示並將程式恢復顯示Taskbar
            wantExportBtn.Visible = true;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
