namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HomeContent")]
    public partial class HomeContent
    {
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentText { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
