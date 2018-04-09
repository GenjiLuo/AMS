namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Framework_ContentItemRecord
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public int? ContentType_id { get; set; }
    }
}
