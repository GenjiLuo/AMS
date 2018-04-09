namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCardConsume")]
    public partial class MemberCardConsume
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberCardConsume()
        {
            CustomerPackages = new HashSet<CustomerPackage>();
            ServiceCars = new HashSet<ServiceCar>();
        }

        public int Id { get; set; }

        public int? OrganizationId { get; set; }

        public int? MemberCardId { get; set; }

        [StringLength(200)]
        public string BillNo { get; set; }

        public double? Money { get; set; }

        public double? Emoney { get; set; }

        public double? CurrentBalance { get; set; }

        public double? DiscountRate { get; set; }

        [StringLength(255)]
        public string RepairNo { get; set; }

        public int? MemberScoreId { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackage> CustomerPackages { get; set; }

        public virtual MemberCard MemberCard { get; set; }

        public virtual MemberCardScore MemberCardScore { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars { get; set; }
    }
}
