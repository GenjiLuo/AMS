namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_OneToManyRelationshipRecord
    {
        public int Id { get; set; }

        public int? Relationship_Id { get; set; }

        public int? LookupField_Id { get; set; }

        public int? RelatedListProjection_Id { get; set; }

        [StringLength(255)]
        public string RelatedListLabel { get; set; }

        public bool ShowRelatedList { get; set; }

        public byte? DeleteOption { get; set; }
    }
}
