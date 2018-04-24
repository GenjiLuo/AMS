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

        public static string BookingList = "/AutoRepair/BookingManagement/Index";
        public static string BookingCreate = "/AutoRepair/BookingManagement/Create";
        #endregion
        #region 配件管理
        public static string Supplier = "/PartDictionary/BaseInfo/Supplier";
        public static string PartDictionary = "/PartDictionary/BaseInfo/PartDictionary";

        public static string UseOrReturn = "/PartDictionary/RepairItem/UseOrReturn";
        #endregion
        #region 客户关系
        public static string Customer = "/CustomerRelation/CustomerInfo/Customer";
        public static string Car = "/CustomerRelation/CustomerInfo/Car";

        public static string Query = "/CustomerRelation/Business/Query";
        public static string Integral = "/CustomerRelation/Business/Integral";
        #endregion
        #region 报表分析
        public static string PartDictionaryProfit = "/Report/BusinessReport/PartDictionaryProfit";
        public static string BusinessSituation = "/Report/BusinessReport/BusinessSituation";

        public static string DailyRepairReport = "/Report/FinanceReport/DailyRepairReport";
        public static string WorkHourPay = "/Report/FinanceReport/WorkHourPay";
        #endregion
        #region 基础资料
        public static string OrgSchemaUrl = "/BaseInfo/OrganizationManagement/Index";
        public static string JobManagement = "/BaseInfo/OrganizationManagement/JobManagement";
        public static string EmployeeManagement = "/BaseInfo/OrganizationManagement/EmployeeManagement";

        public static string RepairItemType = "/BaseInfo/RepairDictionary/RepairItemType";
        public static string RepairItem = "/BaseInfo/RepairDictionary/RepairItem";
        #endregion
        #region 系统设置
        public static string OperationLog = "/SystemSetting/SystemLog/OperationLog";
        public static string DataLog = "/SystemSetting/SystemLog/DataLog";

        public static string ParameterControll = "/SystemSetting/SystemSetting/ParameterControll";
        public static string OrderNoSetting = "/SystemSetting/SystemSetting/OrderNoSetting";
        #endregion
    }
}
