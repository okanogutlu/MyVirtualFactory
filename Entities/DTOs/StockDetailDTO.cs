using Core.Entities;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StockDetailDTO:IDTO
    {
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public ProductTypes ProductTypeName { get; set; }
        public int AmountOfStock { get; set; }

    }
}
