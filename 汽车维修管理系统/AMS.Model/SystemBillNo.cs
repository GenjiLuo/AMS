namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemBillNo")]
    public partial class SystemBillNo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SystemBillNo()
        {
            SystemBillNoKeys = new HashSet<SystemBillNoKey>();
        }

        public int Id { get; set; }

        public int BillNoType { get; set; }

        [Required]
        [StringLength(50)]
        public string Prefix { get; set; }

        public int DateType { get; set; }

        public int Digit { get; set; }

        public bool HasDailyReset { get; set; }

        public bool HasDistinguishShop { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemBillNoKey> SystemBillNoKeys { get; set; }
    }
}
