namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeLabel")]
    public partial class EmployeeLabel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeLabel()
        {
            UserEmployeeLabels = new HashSet<UserEmployeeLabel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string LabelName { get; set; }

        [Required]
        [StringLength(255)]
        public string Remark { get; set; }

        [Required]
        [StringLength(255)]
        public string SearchKey { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEmployeeLabel> UserEmployeeLabels { get; set; }
    }
}
