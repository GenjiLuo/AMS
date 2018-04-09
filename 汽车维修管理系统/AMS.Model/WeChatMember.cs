namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeChatMember")]
    public partial class WeChatMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string OpenId { get; set; }

        public int? Sex { get; set; }

        [StringLength(255)]
        public string Province { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string County { get; set; }

        [StringLength(255)]
        public string HeadUrl { get; set; }

        [StringLength(255)]
        public string UnionId { get; set; }

        public int OriginalCustomerId { get; set; }

        public bool HasSubscribed { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
