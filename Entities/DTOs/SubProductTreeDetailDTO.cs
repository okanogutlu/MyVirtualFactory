using Core.Entities;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SubProductTreeDetailDTO:IDTO
    {
        public int SubProductID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public ProductTypes ProductTypeName { get; set; }
        public int Amount { get; set; }

    }
}
