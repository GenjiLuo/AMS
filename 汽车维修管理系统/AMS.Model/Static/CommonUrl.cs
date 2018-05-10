using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace AMS.Model.Static
{
    public static class CommonUrl
    {
        #region 维修接待
        public static string WashCarCreate = "/AutoRepair/RepairManagement/WashCarCreate";
        public static string RepairCreate = "/AutoRepair/RepairManagement/RepairCreate";
        public static string RepairHistory= "/AutoRepair/RepairHistory/Index";

        public static string BookingList = "/AutoRepair/BookingManagement/Index";
        public static string BookingCreate = "/AutoRepair/BookingManagement/Create";
        #endregion
        #region 配件管理
        public static string Supplier = "/PartDictionary/Supplier/Index";
        public static string PartDictionary = "/PartDictionary/PartsDictionary/Index";
        public static string PartsBuy = "/PartDictionary/PartsBuy/Index";
        public static string PartsReturn = "/PartDictionary/PartsReturn/Index";
        public static string Warehouse = "/PartDictionary/Warehouse/Index";
        public static string PartsWarning = "/PartDictionary/PartsWarning/Index";

        #endregion
        #region 客户关系
        public static string Customer = "/CustomerRelation/CustomerInfo/Index";
        public static string Car = "/CustomerRelation/Car/Index";

        public static string Query = "/CustomerRelation/Business/Query";
        public static string MemberCardCreate = "/CustomerRelation/MemberCard/Create";
        public static string Charge = "/CustomerRelation/ChargeManagement/Charge";

        #endregion
        #region 报表分析
        public static string BusinessSituation = "/Report/BusinessReport/BusinessSituation";
        public static string DailyRepairReport = "/Report/FinanceReport/DailyRepairReport";
        public static string RepairPartsSummary = "/Report/WarehouseReport/PartsSummary"; 
        public static string PartsInventoryCheckSummary = "/Report/PartsReport/PartsInventoryCheckSummary";
        public static string PartsSaleRank = "/Report/PartsReport/PartsSaleRank"; 
        public static string PartsOverStokedRank = "/Report/PartsReport/PartsOverStokedRank";

        #endregion
        #region 基础资料
        public static string OrgSchemaUrl = "/BaseInfo/OrganizationManagement/Index";
        public static string JobManagement = "/BaseInfo/JobManagement/Index";
        public static string EmployeeManagement = "/BaseInfo/EmployeeManagement/Index";

        public static string RepairType = "/BaseInfo/RepairType/Index";
        public static string RepairItemType = "/BaseInfo/RepairItemType/Index";
        public static string RepairItem = "/BaseInfo/RepairItem/Index";
        public static string ServiceAccountType = "/BaseInfo/ServiceAccountType/Index";
        public static string PaymentType = "/BaseInfo/PaymentType/Index";
        public static string ServiceTicketType = "/BaseInfo/ServiceTicketType/Index";
        public static string CarModel = "/BaseInfo/CarModel/Index";

        public static string PartsType = "/BaseInfo/PartsType/Index";


        #endregion
        #region 系统设置
        public static string OperationLog = "/SystemSetting/SystemLog/OperationLog";

        public static string ParameterControll = "/SystemSetting/SystemSetting/ParameterControll";
        public static string OrderNoSetting = "/SystemSetting/SystemSetting/OrderNoSetting";
        #endregion
    }
}
