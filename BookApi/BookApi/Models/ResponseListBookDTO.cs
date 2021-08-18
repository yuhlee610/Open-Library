using BookApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class ListBookDTO
    {
        public List<BookDTO> Books { get; set; }
        public int TotalPage { get; set; } 
        public int CurrentPage { get; set; } 
    }
}
