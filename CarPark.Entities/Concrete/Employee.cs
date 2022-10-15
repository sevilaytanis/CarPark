using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class Employee : BaseModel
    {
    
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }

        public EmployeeContact Contact { get; set; }

        public ICollection<Address> Adresses { get; set; }

        public short Status { get; set; }

        public DateTime CreateDate { get; set; }
        
        public DateTime? UpdateDate { get; set; }

    }
}
