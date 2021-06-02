using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class WorkCenterOperation : IEntity
    {
        [Key]
        public int WcOprID { get; set; }

        /// <summary>
        /// Machine that make Operation which belongs this object done
        /// </summary>
        public WorkCenter WorkCenter { get; set; }
        public int WorkCenterID { get; set; }

        /// <summary>
        /// Operation that is done by machine belongs this object
        /// </summary>
        public Operation Operation { get; set; }
        public int OperationID { get; set; }
        public int Speed { get; set; }


    }
}
