namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerInfo")]
    public partial class CustomerInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string Tel { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string QQ { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(255)]
        public string WeChat { get; set; }

        [StringLength(255)]
        public string IdCardNo { get; set; }

        [StringLength(4000)]
        public string Remark { get; set; }

        [StringLength(255)]
        public string Hobby { get; set; }

        [StringLength(255)]
        public string DistanceToShop { get; set; }

        [StringLength(255)]
        public string CustomerAgeGroup { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
