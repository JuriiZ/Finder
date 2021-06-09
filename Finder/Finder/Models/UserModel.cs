using System;
using System.Collections.Generic;
using System.Text;

namespace Finder.Models
{
    public class UserModel
    {
        Random rnd = new Random();
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public int age
        {
            get => rnd.Next(18, 35);
        }
        public int distance
        {
            get => rnd.Next(1, 30);
        }
    }
}
