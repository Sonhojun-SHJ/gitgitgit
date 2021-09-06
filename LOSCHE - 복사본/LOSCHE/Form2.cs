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
    public partial class Form2 : DevExpress.XtraEditors.XtraForm
    {
        string strConn = @"Provider=microsoft.JET.OLEDB.4.0;data source=Database11.mdb";
        public Form1 f1;
        public Form2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                MessageBox.Show("닉네임을 입력하세요.");
                textEdit1.Focus();
                return;
            }
            if (textEdit2.Text == "")
            {
                MessageBox.Show("레벨을 입력하세요.");
                textEdit2.Focus();
                return;
            }

            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();

            string sql = "insert into LvTable(nic,lv,hw1,hw2,hw3) values(@nic,@lv,0,0,0)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.Add("@nic", textEdit1.Text);
            cmd.Parameters.Add("@lv", textEdit2.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("저장되었습니다.");

                string refresh = "select * from LvTable order by lv desc";
                OleDbCommand cmd2 = new OleDbCommand(refresh, conn);
                OleDbDataReader dr = cmd2.ExecuteReader();
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
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}