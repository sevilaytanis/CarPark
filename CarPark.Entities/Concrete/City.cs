using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class City : BaseModel
    {
      
        public string Name { get; set; }

        public string Plate { get; set; }

        public string Latitute { get; set; }

        public string Longitute { get; set; }

        //public ICollection<County> Counties;

        public ICollection<String> Counties { get; set; }

    }
}
