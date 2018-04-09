namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceBookingRepairItem")]
    public partial class ServiceBookingRepairItem
    {
        public int Id { get; set; }

        public int? ServiceAccountTypeId { get; set; }

        public int? RepairItemCodeId { get; set; }

        public double? LaborHours { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? SumPrice { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int? ServiceBookingId { get; set; }

        public int? ServiceCarId { get; set; }

        public decimal? PicCount { get; set; }

        public virtual RepairItemCode RepairItemCode { get; set; }

        public virtual ServiceAccountType ServiceAccountType { get; set; }

        public virtual ServiceBooking ServiceBooking { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }
    }
}
