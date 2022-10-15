using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class ReservationDetail : BaseModel
    {
        public string SlotId { get; set; }

        public string FloorId { get; set; }
        public string CarParkId { get; set; }

       
    }
}
