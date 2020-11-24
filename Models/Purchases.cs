using System;
using System.ComponentModel.DataAnnotations;

namespace Term_Project_Version_1.Models
{
    public class Purchases
    {
        public string ID { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int MembersID { get; set; }
        public Members Members { get; set; }

    }
}
