namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerDistributionActivityChangeDetail")]
    public partial class CustomerDistributionActivityChangeDetail
    {
        public int Id { get; set; }

        public int CustomerDistributionActivityChangeId { get; set; }

        public int CustomerLevelId { get; set; }

        public decimal? Level2RB { get; set; }

        public decimal? Level2CB { get; set; }

        public int Level2BType { get; set; }

        public decimal? Level3RB { get; set; }

        public decimal? Level3CB { get; set; }

        public int Level3BType { get; set; }

        public decimal? PackageLevel2Cb { get; set; }

        public int PackageLevel2BType { get; set; }

        public decimal? PackageLevel3Cb { get; set; }

        public int PackageLevel3BType { get; set; }

        public virtual CustomerDistributionActivityChange CustomerDistributionActivityChange { get; set; }

        public virtual CustomerLevel CustomerLevel { get; set; }
    }
}
