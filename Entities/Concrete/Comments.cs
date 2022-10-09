﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comments:Ient
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User user{get; set;}
    }
}
