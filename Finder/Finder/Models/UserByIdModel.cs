using System;
using System.Collections.Generic;
using System.Text;

namespace Finder.Models
{
    public class UserByIdModel
    {
        public UserModel data { get; set; }
        public Support support { get; set; }

        public class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }
    }
}
