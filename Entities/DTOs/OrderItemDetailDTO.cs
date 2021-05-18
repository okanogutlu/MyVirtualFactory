using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderItemDetailDTO:IDTO
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
    }
}
