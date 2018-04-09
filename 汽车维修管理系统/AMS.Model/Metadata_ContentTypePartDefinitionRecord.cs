namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_ContentTypePartDefinitionRecord
    {
        public int Id { get; set; }

        public string Settings { get; set; }

        public int? ContentPartDefinitionRecord_id { get; set; }

        public int? ContentTypeDefinitionRecord_Id { get; set; }
    }
}
