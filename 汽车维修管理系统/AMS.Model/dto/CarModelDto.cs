using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class CarModelDto : BaseDto
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid SeriesId { get; set; }
        public string SeriesName { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string Color { get; set; }
    }
}
