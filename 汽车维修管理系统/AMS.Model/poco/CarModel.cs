using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Model.poco
{
    public class CarModel : BaseModel
    {
        public CarModel()
        {
            Cars=new HashSet<Car>();
            PartsDictionarySuitedCarModel=new HashSet<PartsDictionarySuitedCarModel>();
        }
        public Guid SeriesId { get; set; }
        [ForeignKey("SeriesId")]
        public virtual CarSeries Series { get; set; }

        public decimal Price { get; set; }
        public string Color { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<PartsDictionarySuitedCarModel> PartsDictionarySuitedCarModel { get; set; }

    }
}
