using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendApi.Model
{
    public class Friend
    {
        public Friend()
        {
            Id = 0;
            Name = "";
            FriendType = "";
            isClose = false;
            BirthDate = DateTime.Now;
            Gendar = "";

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendType { get; set; }
        public bool isClose { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gendar { get; set; }
    }
}
