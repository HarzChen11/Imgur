using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur
{
    public class Program
    {
        static void Main(string[] args)
        {
            // get 取得圖片資料
            //抓不到https://imgur.com/gallery/HAOrLh4，可抓到https://imgur.com/gallery/lBGMRlE
            getImageModel model = ImgurService.getImage<getImageModel>("eSUB0G1");
            Console.WriteLine(model.data.id);

            // post 建立相簿
            //ImgurService.creatAlbum();

            // post 上傳照片
            //ImgurService.uploadPic();

            // get Gallery
            //GalleryModel model = ImgurService.getGallery<GalleryModel>("hot", "top", "day", 1);
            //Console.WriteLine(model.data[0].account_id);

            // get Album/Image comments
            //CommentsModel model = ImgurService.getComment<CommentsModel>("Ptgeshm", "new");
            //Console.WriteLine(model.data[0].id);

            // post Album/Image Voting
            //ImgurService.imgVoting("XC3PifV");

            // get Album/Image Votes，
            //VotesModel model = ImgurService.imgVotes<VotesModel>("XC3PifV");
            //Console.WriteLine(model.data.ups);

            // get AccountBase
            //AccountModel model = ImgurService.getAccount<AccountModel>("HarzChen");
            //Console.WriteLine(model.data.id);

            // 删除相片
            //ImgurService.delImage("B5o0fjr");

            Console.ReadKey();
        }
    }
}
