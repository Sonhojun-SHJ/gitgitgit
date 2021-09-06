using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JsonApiParsingPractice
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("페이지 번호(1~254) : ");
            string page = Console.ReadLine();
            try
            {
                int pageNum = int.Parse(page);
                string requestURL = "https://api.odcloud.kr/api/15040443/v1/uddi:c87b4555-f28e-4f25-9ee3-a70a41e41cf2_202003131102?page="+pageNum+"&perPage=100&serviceKey=FxN742dPg5pEgSM0kdp0eEyXJ7Tj2ezuZf4buGY4pYtOu9powSSkx9W4g5URPhoLzJkPBD%2FpB3evgc5MrE7zWA%3D%3D";
                WebRequest request = WebRequest.Create(requestURL);
                request.Method = "GET";
                //request.ContentType = "application/json";

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string data = reader.ReadToEnd();
                var obj = JObject.Parse(data);
                var list = obj["data"];

                //Console.WriteLine("============ List ============");
                //Console.WriteLine(obj);

                Console.WriteLine("============ Item ============");
                foreach (var item in list)
                {
                    Console.WriteLine(item["가맹점명"]);
                    Console.WriteLine(item["주소"]);
                    Console.WriteLine("----");

                }
                //Console.WriteLine("============ Test ============");
                //Console.WriteLine(list);

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
