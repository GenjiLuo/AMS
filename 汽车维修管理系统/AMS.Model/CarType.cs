namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarType")]
    public partial class CarType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarType()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public int CtBrandId { get; set; }

        public int CtSeriesId { get; set; }

        public int CtTypeId { get; set; }

        public bool Deleted { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public int OldId { get; set; }

        public decimal? EstimatePrice { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        [Required]
        public string CarTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual CtBrand CtBrand { get; set; }

        public virtual CtSery CtSery { get; set; }

        public virtual CtType CtType { get; set; }
    }
}
