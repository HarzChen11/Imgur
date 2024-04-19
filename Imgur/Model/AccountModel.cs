using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Model
{
    public class AccountModel
    {
        public Data data { get; set; }
        public bool success { get; set; }
        public int status { get; set; }

        public class Data
        {
            public int id { get; set; }
            public string url { get; set; }
            public string bio { get; set; }
            public string avatar { get; set; }
            public string avatar_name { get; set; }
            public string cover { get; set; }
            public string cover_name { get; set; }
            public int reputation { get; set; }
            public string reputation_name { get; set; }
            public int created { get; set; }
            public bool pro_expiration { get; set; }
            public User_Follow user_follow { get; set; }
            public bool is_blocked { get; set; }
        }

        public class User_Follow
        {
            public bool status { get; set; }
        }

    }
}
