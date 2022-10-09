using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Category:Ient
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> products { get; set; }
    }
}
 