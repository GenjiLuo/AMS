using AMS.Model.Enum;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class BillNoSettingDto : BaseDto
    {
        public string Prefix { get; set; }
        public BillDateFormat DateFormat { get; set; }
        public BillSerNoLength SerNoLength { get; set; }
        public bool DailyReset { get; set; }
        public string BillNoPreview { get; set; }
    }
}
