using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WorkCenterOperationsDetailDTO:IDTO
    {
        public int WorkCenterOperationID { get; set; }
        public int WorkCenterID { get; set; }
        public string WorkCenterName { get; set; }
        public int OperationID { get; set; }
        public string OperationName { get; set; }
        public string ProductType { get; set; }
        public int Speed { get; set; }

    }
}
