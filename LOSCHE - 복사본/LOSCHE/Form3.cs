using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LOSCHE
{
    public partial class Form3 : DevExpress.XtraEditors.XtraForm
    {
        public Form1 f1;

        string strConn = @"Provider=microsoft.JET.OLEDB.4.0;data source=Database11.mdb";
        string ReceivedName;
        string ReceivedLv;

        string hw1;
        string hw2;
        string hw3;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(string[] data)
        {
            InitializeComponent();

            ReceivedName = data[0];
            ReceivedLv = data[1];
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label3.Text = ReceivedName;
            textEdit1.Text = ReceivedLv;

            MakeHomework(ReceivedLv);

            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                string sql = "select hw1,hw2,hw3 from LvTable where nic='" + ReceivedName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    hw1 = dr["hw1"].ToString();
                    hw2 = dr["hw2"].ToString();
                    hw3 = dr["hw3"].ToString();
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            if (int.Parse(hw1) == 1)
            {
                checkEdit1.Checked = true;
            }
            if (int.Parse(hw2) == 1)
            {
                checkEdit2.Checked = true;
            }
            if (int.Parse(hw3) == 1)
            {
                checkEdit3.Checked = true;
            }
        }

        private void MakeHomework(string lv)
        {
            if (int.Parse(lv) < 1370)
            {
                checkEdit1.Text = "ore";
                checkEdit2.Visible = false;
                checkEdit3.Visible = false;
            }
            else if (int.Parse(lv) >= 1370 && int.Parse(lv) < 1415)
            {
                checkEdit1.Text = "ore";
                checkEdit2.Text = "ar";
                checkEdit3.Visible = false;
            }
            else if (int.Parse(lv) >= 1415 && int.Parse(lv) < 1430)
            {
                checkEdit1.Text = "ar";
                checkEdit2.Text = "bal";
                checkEdit3.Visible = false;
            }
            else if (int.Parse(lv) >= 1430 && int.Parse(lv) < 1475)
            {
                checkEdit1.Text = "ar";
                checkEdit2.Text = "bal";
                checkEdit3.Text = "via";
            }
            else if (int.Parse(lv) >= 1475 && int.Parse(lv) < 1490)
            {
                checkEdit1.Text = "bal";
                checkEdit2.Text = "via";
                checkEdit3.Text = "cu";
            }
            else if (int.Parse(lv) >= 1490)
            {
                checkEdit1.Text = "군1";
                checkEdit2.Text = "군2";
                checkEdit3.Text = "군3";
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sql;
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();

            if (checkEdit1.Checked)
            {
                sql = "update LvTable set hw1='1' where nic='" + ReceivedName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                sql = "update LvTable set hw1='0' where nic='" + ReceivedName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            if (checkEdit2.Checked)
            {
                sql = "update LvTable set hw2='1' where nic='" + ReceivedName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                sql = "update LvTable set hw2='0' where nic='" + ReceivedName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            if (checkEdit3.Checked)
            {
                sql = "update LvTable set hw3='1' where nic='" + ReceivedName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                sql = "update LvTable set hw3='0' where nic='" + ReceivedName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            string sql2 = "update LvTable set lv='" + textEdit1.Text + "' where nic='" + ReceivedName + "'";
            OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
            cmd2.ExecuteNonQuery();

            string sql3 = "select * from LvTable order by lv desc";
            OleDbCommand cmd3 = new OleDbCommand(sql3, conn);
            OleDbDataReader dr = cmd3.ExecuteReader();
            f1.listView1.Items.Clear();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["nic"].ToString();
                item.SubItems.Add(dr["lv"].ToString());
                f1.listView1.Items.Add(item);
            }

            dr.Close();
            conn.Close();
            this.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Enabled == true)
                textEdit1.Enabled = false;
            else
                textEdit1.Enabled = true;
        }
    }
}