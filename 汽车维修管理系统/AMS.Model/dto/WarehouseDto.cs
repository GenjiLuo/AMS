using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class WarehouseDto : BaseDto
    {
        public bool IsDefault { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
    }
}
