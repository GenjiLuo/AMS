namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarLabelRelation")]
    public partial class CarLabelRelation
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int CarLabelId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Car Car { get; set; }

        public virtual CarLabel CarLabel { get; set; }
    }
}
