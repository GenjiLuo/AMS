using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Model.poco
{
    public class CarSeries : BaseModel
    {
        public CarSeries()
        {
            Models = new HashSet<CarModel>();
        }
        public virtual ICollection<CarModel> Models { get; set; }

        public Guid BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual CarBrand Brand { get; set; }
    }
}
