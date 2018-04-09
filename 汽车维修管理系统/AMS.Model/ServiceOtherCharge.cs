namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceOtherCharge")]
    public partial class ServiceOtherCharge
    {
        public int Id { get; set; }

        public int ServiceCarId { get; set; }

        public int ServiceOtherChargeTypeId { get; set; }

        public int ServiceAccountTypeId { get; set; }

        public decimal? Price { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual ServiceAccountType ServiceAccountType { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual ServiceOtherChargeType ServiceOtherChargeType { get; set; }
    }
}
