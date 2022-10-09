using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:Ient

    {
        //one to many with comment
        //one to many with basket
        public string Name { get; set; }
        public int ProductId { get; set; }


        public ProductBasket basket { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public ICollection<Comments> Comments { get; set; }
     
    }
}
