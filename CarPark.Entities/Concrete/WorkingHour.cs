using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class WorkingHour
    {
        ICollection<TranslationModel> Translation { get; set; }
    }
}
