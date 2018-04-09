namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Camera")]
    public partial class Camera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Camera()
        {
            Stations = new HashSet<Station>();
        }

        public int Id { get; set; }

        public int? OrganizationId { get; set; }

        [StringLength(255)]
        public string DeviceId { get; set; }

        [StringLength(255)]
        public string DeviceBrand { get; set; }

        public int DeviceState { get; set; }

        [StringLength(1024)]
        public string Remark { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Station> Stations { get; set; }
    }
}
