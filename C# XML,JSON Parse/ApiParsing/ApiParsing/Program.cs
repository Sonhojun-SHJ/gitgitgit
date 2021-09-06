using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ApiParsing
{
    class Program
    {
        static string requestURL = "http://data.ex.co.kr/openapi/safeDriving/forecast?key=test&type=xml";
        static void Main(string[] args)
        {
            try
            {
                WebRequest request = WebRequest.Create(requestURL);
                request.Method = "GET";
                //request.ContentType = "application/json";

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string data = reader.ReadToEnd();

                XmlDocument obj = new XmlDocument();
                obj.LoadXml(data);
                XmlNode list = obj["data"]["list"];

                Console.WriteLine("============ List ============");
                Console.WriteLine(obj.InnerXml);

                Console.WriteLine("============ Item ============");

                Console.WriteLine(string.Format("{0}: {1}", "날짜", list["sdate"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "시간", list["stime"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "전국 교통량", list["cjunkook"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "지방 방향 교통량", list["cjibangDir"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "서울 방향 교통량", list["cseoulDir"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "서울->대전 소요시간", list["csudj"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "서울->대구 소요시간", list["csudg"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "서울->울산 소요시간", list["csuus"].InnerText));
                Console.WriteLine(string.Format("{0}: {1}", "서울->부산 소요시간", list["csubs"].InnerText));
                //Console.WriteLine(item["csudg"]) ;

                Console.WriteLine("============ Test ============");
                Console.WriteLine(list.InnerXml);

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
