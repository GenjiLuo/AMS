namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_RelationshipRecord
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public byte Type { get; set; }

        public int PrimaryEntity_Id { get; set; }

        public int RelatedEntity_Id { get; set; }
    }
}
