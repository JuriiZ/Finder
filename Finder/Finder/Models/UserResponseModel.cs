using System;
using System.Collections.Generic;
using System.Text;

namespace Finder.Models
{
    public class UserResponseModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UserModel> data { get; set; }
        public Support support { get; set; }

        public class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }
    
    }
}
