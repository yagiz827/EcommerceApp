using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:Ient
    {
        //one to one with basket
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        //one to many with comments
        public ICollection<Comments> comments { get; set; }
        public List <ProductBasket> basketss { get; set; }
        public ICollection<Orders> orders { get; set; }


        //one to many with orders



    }
}
