using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Imgur
{
    public class ImgurService
    {


        // get 取得圖片資料，有問題
        public static T getImage<T>(string imageHash)
        {
            T model = HttpRequest.GetRequest<T>($"https://api.imgur.com/3/image/{imageHash}");
            return model;
        }

        // post 建立相簿, => HttpWebRequest寫法
        #region
        //public static void creatAlbum(string url)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    //request.Headers.Add("Authorization", "Client-ID 61a381f1d52b1ef");
        //    request.Headers.Add("Authorization", "Bearer 8fc55f298e8531e6ea075d73aa9dc9d16d447e80");
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    var postData =
        //        new //要傳遞的參數Sample
        //        {
        //            title = "album of api",
        //            description = "123"
        //        };
        //    string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
        //    byte[] byteArray = Encoding.UTF8.GetBytes(postBody);//要發送的字串轉為byte[]

        //    using (Stream reqStream = request.GetRequestStream())
        //    {
        //        reqStream.Write(byteArray, 0, byteArray.Length);
        //    }

        //    string responseStr = "";
        //    using (WebResponse response = request.GetResponse())
        //    {
        //        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        //        {
        //            responseStr = reader.ReadToEnd();
        //            Console.WriteLine(responseStr);
        //        }
        //    }
        //}
        #endregion

        // post 建立相簿
        public static void creatAlbum()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("title", "test album");
            dict.Add("description", "test test test");
            HttpRequest.PostRequest($"https://api.imgur.com/3/album", dict);
        }

        // post 上傳照片 (到相簿)
        public static void uploadPic()
        {
            //將圖片e格式轉為 base64
            byte[] imageArray = File.ReadAllBytes(@"C:\Users\user\Downloads\下載.png");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("image", base64ImageRepresentation);
            dict.Add("type", "base64");
            dict.Add("title", "testupload");
            dict.Add("description", "testpicture");
            //dict.Add("album", "41XE0Bh"); // 指定上傳的相簿
            HttpRequest.PostRequest($"https://api.imgur.com/3/upload", dict);
        }

        // get Gallery
        public static T getGallery<T>(string section, string sort, string window, int page = 1)
        {
            //https://api.imgur.com/3/gallery/{{section}}/{{sort}}/{{window}}/{{page}}?showViral={{showViral}}&mature={{showMature}}&album_previews={{albumPreviews}}
            T model = HttpRequest.GetRequest<T>($"https://api.imgur.com/3/gallery/hot/top/day/1?section={section}&sort={sort}&window={window}&page={page}");
            return model;
        }

        // get more Image
        public static T getGalleryImage<T>(string galleryHash)
        {
            T model = HttpRequest.GetRequest<T>($"https://api.imgur.com/3/gallery/album/{galleryHash}");
            return model;
        }

        // post Comment Voting
        public static void CommentVoting(string commentId, string vote)
        {
            HttpRequest.PostRequest($"https://api.imgur.com/3/comment/{commentId}/vote/{vote}");
        }

        // get Album/Image comments
        public static T getComment<T>(string galleryHash, string commentSort)
        {
            //https://api.imgur.com/3/gallery/{{galleryHash}}/comments/{{commentSort}}

            T model = HttpRequest.GetRequest<T>($"https://api.imgur.com/3/gallery/{galleryHash}/comments/{commentSort}");
            return model;
        }

        // post Album/Image Voting
        public static void imgVoting(string galleryHash, string vote = "up")
        {
            HttpRequest.PostRequest($"https://api.imgur.com/3/gallery/{galleryHash}/vote/{vote}");
        }

        // get Album/Image Votes
        public static T imgVotes<T>(string galleryHash)
        {
            T model = HttpRequest.GetRequest<T>($"https://api.imgur.com/3/gallery/{galleryHash}/votes");
            return model;
        }

        // get AccountBase
        public static T getAccount<T>(string username)
        {
            T model = HttpRequest.GetRequest<T>($"https://api.imgur.com/3/account/{username}");
            return model;
        }

        // 删除相片
        public static void delImage(string imageHash)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            HttpRequest.DelRequest($"https://api.imgur.com/3/image/{imageHash}", dict);
        }

        // 新增留言
        public static void CommentCreat(string imageHash, string text)
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("image_id", imageHash);
            dict.Add("comment", text);

            HttpRequest.PostRequest($"https://api.imgur.com/3/comment", dict);
        }

        // 新增留言的回覆
        public static void ChildCommentCreat(string imageHash, string text, string commentId)
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("image_id", imageHash);
            dict.Add("comment", text);

            HttpRequest.PostRequest($"https://api.imgur.com/3/comment/{commentId}", dict);
        }
    }
}
