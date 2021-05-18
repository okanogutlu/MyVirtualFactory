using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDTO: IDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public List<OrderItem>  OrderItem { get; set; }
        public Entities.Concrete.Enums.OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Deadline { get; set; }

    }
}
