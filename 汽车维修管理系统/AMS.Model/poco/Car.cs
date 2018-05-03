using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Model.poco
{
    public class Car : BaseModel
    {
        public Car()
        {
            CustomerCars=new HashSet<CustomerCar>();
        }
        public virtual ICollection<CustomerCar> CustomerCars { get; set; }

        public string BrandName { get; set; }
        public string SeriesName { get; set; }
        public string ModelNo { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string Color { get; set; }
    }
}
