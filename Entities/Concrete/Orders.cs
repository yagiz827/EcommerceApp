using Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Orders:Ient
    {
        //one to many with users

        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }

        public List<OrderDetail> Detail { get; set; }


        


    }
}
