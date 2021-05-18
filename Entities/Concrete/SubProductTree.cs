using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SubProductTree : IEntity
    {
        public int SubProductID { get; set; }

        public int ProductID { get; set; }
        public int Amount { get; set; }
        public Product SubProduct { get; set; }
        public Product Product { get; set; }

    }
}
