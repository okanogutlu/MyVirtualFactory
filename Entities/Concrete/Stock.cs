using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Stock:IEntity
    {
        [Key]
        public int StockID { get; set; }

        /// <summary>
        /// Represents which stock is
        /// </summary>
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int AmountOfStock { get; set; }
    }
}
