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

    public partial class Form1 : Form
    {
        public class EmployeeData
        {
            public string Date { get; set; }
            public List<string> Time { get; set; }
            public int TotalWorkTime { get; set; }
        }

        List<string> employeeList = new List<string>();
        string type = "";
        string selectedName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void clockBtn_Click(object sender, EventArgs e)
        {
            string username = nameInput.Text;
            string savePath = System.Windows.Forms.Application.StartupPath;
            string dateAndTime = DateTime.Now.ToString(); // 2017-03-4 20:02:10
            string date = DateTime.Now.ToString().Substring(0,9);
            string time = DateTime.Now.TimeOfDay.ToString();
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
                        if (readLine.Contains(date))
                        {
                            recordData = "," + time.Substring(0, 8);
                            dateExist = true;
                            Console.WriteLine(recordData);
                        }
                        else
                        {
                            recordData = "日期:" + date + "," + "時間:" + time.Substring(0, 8);
                            dateExist = false;
                            
                        }
                    }
                    sr.Close();
                    StreamWriter sw = new StreamWriter(fullPath, true);
                    if (dateExist)
                    {
                        sw.Write(recordData);
                    }
                    else
                    {
                        sw.WriteLine(recordData);
                    }


                    sw.Flush();
                    sw.Close();
                    ReadEmployeeClockRecord(savePath, name);
                }
                else
                {
                    FileStream fs = new FileStream(fullPath, FileMode.Create);
                    fs.Close();
                    recordData = "日期:" + date + "," + "時間:" + time.Substring(0, 8);
                    StreamWriter sw = new StreamWriter(fullPath, true);
                    sw.Write(recordData);
                    sw.Flush();
                    sw.Close();
                    ReadEmployeeClockRecord(savePath, name);

                }
                employeeState.Text = "打卡成功";
                employeeState.ForeColor = Color.Green;
            }
            else
            {
                employeeState.Text = "員工不存在";
                employeeState.ForeColor = Color.Red;
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
                employeeState.Text = "新增成功";
                employeeState.ForeColor = Color.Green;


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
                employeeState.Text = "無員工";
                employeeState.ForeColor = Color.Red;
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
                employeeState.Text = "";

            }
            else
            {
                employeeState.Text = "無打卡紀錄";
                employeeState.ForeColor = Color.Red;
            }

        }

        public Boolean checkNameExist(string name)
        {
            if (employeeList.Contains(name) && name != null && !name.Equals("輸入性名") &&  !name.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void addNew_Click(object sender, EventArgs e)
        {
            string username = nameInput.Text;
            if (checkNameExist(username))
            {
                employeeState.Text = "員工已加入，或名字相同!";
                employeeState.ForeColor = Color.Red;
            }
            else
            {
                if (username == null || username.Equals("輸入性名") || username.Equals(""))
                {
                    employeeState.Text = "員工不存在";
                    employeeState.ForeColor = Color.Red;
                }
                else
                {
                    string savePath = System.Windows.Forms.Application.StartupPath;
                    employeeList.Add(username);
                    WriteNewEmpolyee(savePath, username);
                    employeeState.Text = "加入成功";
                    employeeState.ForeColor = Color.Green;
                }

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
            ReadEmployeeClockRecord(savePath, selectedName);
            Console.WriteLine(selectedName);
        }


    }
}
