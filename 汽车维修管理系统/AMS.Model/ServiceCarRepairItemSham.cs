namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCarRepairItemSham")]
    public partial class ServiceCarRepairItemSham
    {
        public int Id { get; set; }

        public int ServiceCarShamId { get; set; }

        public int ServiceAccountTypeId { get; set; }

        public int RepairItemCodeId { get; set; }

        public int? RepairManId { get; set; }

        [StringLength(255)]
        public string FlowStatus { get; set; }

        public double? LaborHours { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? LaborHoursPrice { get; set; }

        public decimal? CheckLaborHoursPrice { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual RepairItemCode RepairItemCode { get; set; }

        public virtual ServiceAccountType ServiceAccountType { get; set; }

        public virtual User User { get; set; }

        public virtual ServiceCarSham ServiceCarSham { get; set; }
    }
}
