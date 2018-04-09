namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsDictionaryCarType")]
    public partial class PartsDictionaryCarType
    {
        public int Id { get; set; }

        public int PartsDictionaryId { get; set; }

        public int CtBrandId { get; set; }

        public int CtSeriesId { get; set; }

        public int CtTypeId { get; set; }

        public bool Deleted { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        [Required]
        public string CarTypeName { get; set; }

        public virtual CtBrand CtBrand { get; set; }

        public virtual CtSery CtSery { get; set; }

        public virtual CtType CtType { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }
    }
}
