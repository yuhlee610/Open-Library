using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data
{
    public class Book
    {
        public Book()
        {
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
