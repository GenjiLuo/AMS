namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceAccountSham")]
    public partial class ServiceAccountSham
    {
        public int Id { get; set; }

        public int ServiceCarShamId { get; set; }

        public decimal? PayPrice { get; set; }

        public decimal? LaborHoursPrice { get; set; }

        public decimal? MaterialsPrice { get; set; }

        public decimal? ManagePrice { get; set; }

        public decimal? OtherPrice { get; set; }

        public decimal? Taxes { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal? LaborHoursPrivileges { get; set; }

        public decimal? MaterialsPrivileges { get; set; }

        public decimal? NotPayPrice { get; set; }

        public decimal? AccidentNotPayPrice { get; set; }

        public decimal? ActualPayPrice { get; set; }

        public decimal? SumPrice { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual ServiceCarSham ServiceCarSham { get; set; }
    }
}
