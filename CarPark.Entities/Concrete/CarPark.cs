using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class CarPark :BaseModel
    {
    
        public string Name { get; set; }

        public string[] Phones { get; set; }

        public Address Address { get; set; }

        public string[] Employees { get; set; }

        public string WebSite { get; set; }

        public string[] Email { get; set; }

        public ICollection<WorkingDay> WorkDays { get; set; }

        public ICollection<FloorInformation> Floors { get; set; }
    }
}
