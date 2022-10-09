using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductBasket:Ient

    {
        public int ProductBasketId { get; set; }
        public int ProductCount { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }

        public Product pros { get; set; }

        


    }
}
