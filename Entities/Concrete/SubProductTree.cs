using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class SubProductTree : IEntity
    {
        [Key]
        public int SubProductID { get; set; }

        public int ProductID { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }

    }
}
