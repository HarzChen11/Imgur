using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Imgur
{
    public class HttpRequest
    {

        public static T GetRequest<T>(String url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers.Add("Authorization", "Client-ID 61a381f1d52b1ef");
            request.Method = "GET";

            string result = " ";
            // 取得回應資料

            // 接收響應關聯的流的內部資料
            using (WebResponse response = request.GetResponse())
            {
                // 將流傳輸到具有所需編碼格式的更高級別的流讀取器
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                    T model = JsonConvert.DeserializeObject<T>(result);
                    return model;
                }
            }

        }

        public static void PostRequest(String url, Dictionary<string, string> dictionary)
        {
            var client = new RestClient(url);
            //client.Timeout = -1;
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Authorization", "Client-ID 61a381f1d52b1ef");
            request.AddHeader("Authorization", "Bearer 8fc55f298e8531e6ea075d73aa9dc9d16d447e80");
            request.AlwaysMultipartFormData = true;
            foreach (var dic in dictionary)
            {
                request.AddParameter(dic.Key, dic.Value);
            }

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }

        public static void PostRequest(String url)
        {
            var client = new RestClient(url);
            //client.Timeout = -1;
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Authorization", "Client-ID 61a381f1d52b1ef");
            request.AddHeader("Authorization", "Bearer 8fc55f298e8531e6ea075d73aa9dc9d16d447e80");
            request.AlwaysMultipartFormData = true;
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }

        //public static string PutRequest(String url, Dictionary<string, string> dictionary)
        //{
        //    var client = new RestClient(url);
        //    //client.Timeout = -1;
        //    var request = new RestRequest("",Method.Put);
        //    request.AddHeader("Authorization", "Bearer 8fc55f298e8531e6ea075d73aa9dc9d16d447e80");
        //    request.AlwaysMultipartFormData = true;
        //    RestResponse response = client.Execute(request);
        //    return (response.Content);

        //}


        public static void DelRequest(String url, Dictionary<string, string> dictionary)
        {
            var client = new RestClient(url);
            //client.Timeout = -1;
            var request = new RestRequest("", Method.Delete);
            request.AddHeader("Authorization", "Bearer 8fc55f298e8531e6ea075d73aa9dc9d16d447e80");
            request.AlwaysMultipartFormData = true;
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }


    }
}
