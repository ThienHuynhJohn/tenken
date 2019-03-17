using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenkenWeb.Models
{
    public class Book
    {
        public int bookID { get; set; }
        public string bookName { get; set; }
        public int bookTypeID { get; set; }
        public string bookTypeName { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public string ImageUrl { get; set; }
    }
}
