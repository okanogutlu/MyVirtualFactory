using Core.Entities;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Operation : IEntity
    {
        
        public int OperationID { get; set; }

        /// <summary>
        /// Operation's name
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Types of Products as enum object
        /// </summary>
        public ProductTypes ProductTypes { get; set; }

    }
}
