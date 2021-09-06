using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlApiParsingPractice
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("페이지 번호 : ");
            string page = Console.ReadLine();
            int pagenum = int.Parse(page);
            try
            {
                string requestURL = "https://api.odcloud.kr/api/15040443/v1/uddi:c87b4555-f28e-4f25-9ee3-a70a41e41cf2_202003131102?page="+pagenum+"&perPage=100&returnType=XML&serviceKey=FxN742dPg5pEgSM0kdp0eEyXJ7Tj2ezuZf4buGY4pYtOu9powSSkx9W4g5URPhoLzJkPBD%2FpB3evgc5MrE7zWA%3D%3D";
                WebRequest request = WebRequest.Create(requestURL);
                request.Method = "GET";
                //request.ContentType = "application/json";

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string data = reader.ReadToEnd();

                XmlDocument obj = new XmlDocument();
                obj.LoadXml(data);
                XmlNode list = obj["results"]["data"];

                //Console.WriteLine(list.InnerXml);

                for (int i = 0; i < list.ChildNodes.Count; i++)
                {
                    XmlNode sn = list.ChildNodes[i];
                    
                    for (int j = 0; j < 5; j++)
                    {
                        if (sn.ChildNodes[j].Attributes["name"].Value == "가맹점명")
                        {
                            Console.WriteLine(sn.ChildNodes[j].InnerText);
                        }
                    }
                    
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
