using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Entities.DTOs
{
    public class ActiveUserDTO:IDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }

        public List<OperationClaim>  Claims { get; set; }
    }
}
