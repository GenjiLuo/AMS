namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarFaultyCarMessageHandleHistory")]
    public partial class CarFaultyCarMessageHandleHistory
    {
        public int Id { get; set; }

        public int CarFaultsMessageId { get; set; }

        public DateTime? HandleTime { get; set; }

        [Required]
        [StringLength(500)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual CarFaultsMessage CarFaultsMessage { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
