namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_ContentPartFieldDefinitionRecord
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Settings { get; set; }

        public int? ContentFieldDefinitionRecord_id { get; set; }

        public int? ContentPartDefinitionRecord_Id { get; set; }
    }
}
