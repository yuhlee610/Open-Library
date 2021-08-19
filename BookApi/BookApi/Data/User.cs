using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Books = new HashSet<Book>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
