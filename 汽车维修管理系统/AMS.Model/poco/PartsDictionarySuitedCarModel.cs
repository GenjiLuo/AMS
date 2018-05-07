using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;

namespace AMS.Model.poco
{
    public class PartsDictionarySuitedCarModel : BaseModel
    {
        public PartsDictionarySuitedCarModel()
        {
        }

        public Guid PartsDictionaryId { get; set; }
        [ForeignKey("PartsDictionaryId")]
        public virtual PartsDictionary PartsDictionary { get; set; }

        public Guid? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual CarBrand CarBrand { get; set; }
        public Guid? SeriesId { get; set; }
        [ForeignKey("SeriesId")]
        public virtual CarSeries CarSeries { get; set; }
        public Guid? ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual CarModel CarModel { get; set; }
    }
}
