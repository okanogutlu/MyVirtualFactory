using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
   public class WorkCenter : IEntity
    {


        [Key]
        public int WorkCenterID { get; set; }

        /// <summary>
        /// Name of the machine of the factory
        /// </summary>
        public string WorkCenterName { get; set; }

        /// <summary>
        /// If Active=true, machine is currently working.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Every machine can do multiple operations.
        /// </summary>
        public virtual ICollection<WorkCenterOperation> WorkCenterOperations { get; set; }

        public WorkCenter() => WorkCenterOperations = new List<WorkCenterOperation>();
    }
}
