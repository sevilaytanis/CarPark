using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace CarPark.Entities.Concrete
{
    [CollectionName("Employee")]
    public class Employee : MongoIdentityUser
    {
        public Employee()
        {
            CreateDate = DateTime.Now;
            Status = 1;
        }

        public string Username { get; set; }



        public string Password { get; set; }

        public EmployeeContact Contact { get; set; }

        public ICollection<Address> Adresses { get; set; }

        public short Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
