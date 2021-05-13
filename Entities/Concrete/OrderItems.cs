using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class OrderItem
    {
        public int orderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }

    }
}
