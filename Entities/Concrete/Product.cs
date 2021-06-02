using Core.Entities;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public Product()
        {
            OrderItems = new List<OrderItem>();
            SubProductTrees = new List<SubProductTree>(); 
            //ProductTrees = new List<SubProductTree>(); 
        }

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        /// <summary>
        /// Every product is a member of a product type as an enum.
        /// </summary>
        public ProductTypes ProductType { get; set; }

        /// <summary>
        /// Customer can only see IsSalable=true datas.
        /// </summary>
        public bool IsSalable { get; set; }

        /// <summary>
        /// Total stock of the product
        /// </summary>
        public Stock Stock { get; set; }
        public int Price { get; set; }


        public virtual ICollection<OrderItem>OrderItems { get; set; }  //Bir product, birden fazla sipariş itemı olabilir
        public virtual ICollection<SubProductTree>SubProductTrees { get; set; } //bir product, birden fazla subproduct a sahip olabilir
       /* public virtual ICollection<SubProductTree> ProductTrees { get; set; } //bir product, başka productların subproduct'ı olabilir*/


    }
}
