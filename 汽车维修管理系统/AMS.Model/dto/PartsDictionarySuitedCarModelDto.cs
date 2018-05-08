using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class PartsDictionarySuitedCarModelDto : BaseDto
    {
        public PartsDictionarySuitedCarModelDto()
        {
        }

        public Guid PartsDictionaryId { get; set; }
        public string PartsDictionaryName { get; set; }

        public Guid? BrandId { get; set; }
        public string CarBrandName { get; set; }
        public Guid? SeriesId { get; set; }
        public  string CarSeriesName { get; set; }
        public Guid? ModelId { get; set; }
        public string CarModelName { get; set; }
    }
}
