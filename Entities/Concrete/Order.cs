using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Deadline { get; set; }
    }
}
