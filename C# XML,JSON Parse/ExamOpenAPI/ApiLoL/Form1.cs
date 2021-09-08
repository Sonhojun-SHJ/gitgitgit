using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiLoL
{
    public partial class Form1 : Form
    {
        static string requestURL = "https://ddragon.leagueoflegends.com/realms/kr.json";
        string version;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            version = takeVersion(requestURL);
            label1.Text = "Version : " + version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string champion = textBox1.Text;
            string championURL = "https://ddragon.leagueoflegends.com/cdn/" + version + "/data/ko_KR/champion.json";

            try
            {
                string data = jsonParse(championURL);
                var obj = JObject.Parse(data);
                var list = obj["data"];

                foreach (var item in list)
                {
                    foreach(var item2 in item)
                    {
                        if (item2["name"].ToString() == champion)
                        {
                            label2.Text = "난이도 : " + item2["info"]["difficulty"].ToString();
                            label3.Text = "분류 : " + item2["tags"][0].ToString() + ", " +item2["tags"][1].ToString();
                            label4.Text = "체력 : " + item2["stats"]["hp"].ToString();
                            label5.Text = "방어 : " + item2["stats"]["armor"].ToString();
                            label6.Text = "마법 방어 : " + item2["stats"]["spellblock"].ToString();
                            label7.Text = "AD : " + item2["stats"]["attackdamage"].ToString();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private string takeVersion(string url)
        {
            try
            {
                string data = jsonParse(url);
                var obj = JObject.Parse(data);

                return obj["v"].ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }

        private string jsonParse(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        
    }
}
