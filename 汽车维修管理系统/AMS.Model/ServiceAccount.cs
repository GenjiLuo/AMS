namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceAccount")]
    public partial class ServiceAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceAccount()
        {
            ServiceCredits = new HashSet<ServiceCredit>();
        }

        public int Id { get; set; }

        public int? ServiceCarId { get; set; }

        public decimal? PayPrice { get; set; }

        public decimal? LaborHoursPrice { get; set; }

        public decimal? MaterialsPrice { get; set; }

        public decimal? ManagePrice { get; set; }

        public decimal? OtherPrice { get; set; }

        public decimal? Taxes { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal? LaborHoursPrivileges { get; set; }

        public decimal? MaterialsPrivileges { get; set; }

        public decimal? ManagePrivileges { get; set; }

        public decimal? NotPayPrice { get; set; }

        public decimal? AccidentNotPayPrice { get; set; }

        public decimal? PackagePrivileges { get; set; }

        public decimal? ActualPayPrice { get; set; }

        public decimal? SumPrice { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public decimal? ActualMaterialsPrice { get; set; }

        public decimal? ActualManagePrice { get; set; }

        public decimal? FakeMaterialsPrice { get; set; }

        public decimal? FakeManagePrice { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCredit> ServiceCredits { get; set; }
    }
}
