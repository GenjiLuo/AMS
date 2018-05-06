using System;

namespace AMS.Model.dto
{
    public class CarSeriesDto : BaseDto
    {
        public Guid BrandId { get; set; }
        public  string BrandName { get; set; }
    }
}
