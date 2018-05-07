using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Model.poco
{
    public class CarBrand : BaseModel
    {
        public CarBrand()
        {
            Series=new HashSet<CarSeries>();
            PartsDictionarySuitedCarModel=new HashSet<PartsDictionarySuitedCarModel>();
        }

        public virtual ICollection<CarSeries> Series { get; set; }
        public virtual ICollection<PartsDictionarySuitedCarModel> PartsDictionarySuitedCarModel { get; set; }
    }
}
