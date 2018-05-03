using System.Collections.Generic;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class CarDto : BaseDto
    {
        public CarDto()
        {
        }
        public string BrandName { get; set; }
        public string SeriesName { get; set; }
        public string ModelNo { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string Color { get; set; }
    }
}
