using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace LOSCHE
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        string strConn = @"Provider=microsoft.JET.OLEDB.4.0;data source=Database11.mdb";

        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;
        public Form1()
        {
            InitializeComponent();

            try
            {
                _driverService = ChromeDriverService.CreateDefaultService();
                _driverService.HideCommandPromptWindow = true;

                _options = new ChromeOptions();
                _options.AddArgument("disable-gpu");
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("이름", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("lv", 60, HorizontalAlignment.Center);

            try
            {
                _options.AddArgument("headless");
                _options.AddArgument("user_agent = Mozilla/5.0 (Linux; Android 9; SM-G975F) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.83 Mobile Safari/537.36 ");

                _driver = new ChromeDriver(_driverService, _options);

                _driver.Navigate().GoToUrl("https://loawa.com/main");

                //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                var sum1 = _driver.FindElementByXPath("/html/body/div[6]/div/div[3]/div[2]/div[2]/div[1]/p/strong");
                labelControl1.Text = sum1.Text;

                var sum2 = _driver.FindElementByXPath("/html/body/div[6]/div/div[3]/div[2]/div[2]/div[2]/p/strong");
                labelControl2.Text = sum2.Text;

                var sum3 = _driver.FindElementByXPath("/html/body/div[6]/div/div[3]/div[2]/div[2]/div[3]/p/strong");
                labelControl3.Text = sum3.Text;
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }

        private void LOSTBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                string sql = "select * from LvTable order by lv desc";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                listView1.Items.Clear();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["nic"].ToString();
                    item.SubItems.Add(dr["lv"].ToString());
                    listView1.Items.Add(item);
                }

                dr.Close();
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.f1 = this;
            f2.ShowDialog();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                ListViewItem item = items[0];
                string itemlv = item.SubItems[1].Text;

                string[] data = { item.Text, itemlv };

                Form3 f3 = new Form3(data);
                f3.f1 = this;
                f3.ShowDialog();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("삭제하시겠습니까?", "Delete", MessageBoxButtons.OKCancel);

            if(result == DialogResult.OK)
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                string sql = "delete from LvTable where nic='" + listView1.SelectedItems[0].Text + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                string sql2 = "select * from LvTable order by lv desc";
                OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
                OleDbDataReader dr = cmd2.ExecuteReader();
                listView1.Items.Clear();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["nic"].ToString();
                    item.SubItems.Add(dr["lv"].ToString());
                    listView1.Items.Add(item);
                }

                dr.Close();
                conn.Close();
            }
            else
            {
                return;

            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("초기화 하시겠습니까?", "Initialization", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                try
                {
                    OleDbConnection conn = new OleDbConnection(strConn);
                    conn.Open();

                    string sql = "update LvTable set hw1='0',hw2='0',hw3='0'";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("초기화 되었습니다.");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            _driver.Quit();
        }

        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
