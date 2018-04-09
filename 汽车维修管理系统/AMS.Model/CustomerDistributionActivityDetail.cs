namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerDistributionActivityDetail")]
    public partial class CustomerDistributionActivityDetail
    {
        public int Id { get; set; }

        public int CustomerDistributionActivityId { get; set; }

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

        public virtual CustomerDistributionActivity CustomerDistributionActivity { get; set; }

        public virtual CustomerLevel CustomerLevel { get; set; }
    }
}
