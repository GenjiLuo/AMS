namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FakePartsInventoryRequest")]
    public partial class FakePartsInventoryRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FakePartsInventoryRequest()
        {
            FakePartsInventoryRequestDetails = new HashSet<FakePartsInventoryRequestDetail>();
        }

        public int Id { get; set; }

        public int? ServiceCarId { get; set; }

        public int? ShopId { get; set; }

        public decimal? Count { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime? RequestDate { get; set; }

        public int? RequestUserId { get; set; }

        public int? RelatedUserId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        public virtual User User3 { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual Shop Shop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequestDetail> FakePartsInventoryRequestDetails { get; set; }
    }
}
