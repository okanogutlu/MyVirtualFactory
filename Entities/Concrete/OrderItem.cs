using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderItem : IEntity
    {
        public int orderItemID { get; set; }

        /// <summary>
        /// Every order item belongs to a main order.
        /// </summary>
        public Order Order { get; set; }

        public int OrderID { get; set; }

        /// <summary>
        /// Order item is also a product
        /// </summary>
        public Product Product { get; set; }
        public int ProductID { get; set; }
        /// <summary>
        /// Represents have many order item ordered.
        /// </summary>
        public int Amount { get; set; }

    }
}
