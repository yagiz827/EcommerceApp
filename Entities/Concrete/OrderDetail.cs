using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderDetail
    {
        [Key]
        public int DetId { get; set; }
        public int OrderId{ get; set; }
        public Orders order { get; set; }
        public string Adress { get; set; }
        public Product products { get; set; }
        public int Count { get; set; }
        
    }
}
