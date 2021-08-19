using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class BorrowInfo
    {
        [Required]
        public string IdUser { get; set; }
        [Required]
        public int IdBook { get; set; }
    }
}
