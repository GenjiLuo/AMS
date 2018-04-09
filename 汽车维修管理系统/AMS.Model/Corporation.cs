namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Corporation")]
    public partial class Corporation
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string PinYin { get; set; }

        [StringLength(255)]
        public string LegalPerson { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string PostCode { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Tel { get; set; }

        [StringLength(255)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string OpenBank { get; set; }

        [StringLength(255)]
        public string Account { get; set; }

        [StringLength(255)]
        public string TaxCode { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        [StringLength(255)]
        public string CorporationCode { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
