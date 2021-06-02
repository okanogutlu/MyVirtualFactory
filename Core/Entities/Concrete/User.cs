using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User:  IEntity 
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// A person can have multiple Orders
        /// </summary>
        public virtual ICollection<IOrder> Orders { get; set; }

        public User(List<IOrder> Orders) => this.Orders = Orders;
        public User()
        {

        }

        
        //public virtual ICollection<Order> Orders { get; set; }
        //public User() => Orders = new List<Order>();
    }
}
