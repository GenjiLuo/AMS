namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportBusinessObjective")]
    public partial class ReportBusinessObjective
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public double? ReceivedCarAmount { get; set; }

        public double? SettlementOutput { get; set; }

        public double? NewMemberAmount { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public int? OrganizationId { get; set; }

        public bool IsUnified { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
