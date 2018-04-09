namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemActivityLog")]
    public partial class SystemActivityLog
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrganizationId { get; set; }

        [Required]
        [StringLength(255)]
        public string ModuleName { get; set; }

        [Required]
        [StringLength(255)]
        public string SubModuleName { get; set; }

        [Required]
        [StringLength(4000)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string IpAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string RouteData { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public string RequestParams { get; set; }

        public string ResponseResult { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
