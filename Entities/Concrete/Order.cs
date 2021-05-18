using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderID { get; set; }

        /// <summary>
        /// Every Order made by a Customer.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// UserID belongs to User
        /// </summary>
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Order must be completed before the Deadline
        /// </summary>
        public DateTime Deadline { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order() => OrderItems = new List<OrderItem>();
    }
}
