using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User:  IEntity 
    {
        /// <summary>
        /// A person can have multiple Orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
        public User() => Orders = new List<Order>();
    }
}
