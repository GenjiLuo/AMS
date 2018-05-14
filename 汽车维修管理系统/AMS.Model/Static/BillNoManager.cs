using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AMS.Model.Enum;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Static
{
    public static class BillNoManager 
    {
//        public static string  GetBillNo<T>(T t,BillTypeName billTypeName)
//        {
//            using (var db = new ModelContext())
//            {
//                var billNo = "";
//                var lastPartsBuyIndex = 0;
//                var dateFormat = "";
//                var index = "";
//                var partsBuyBill = db.t.FirstOrDefault(i => i.Name == billTypeName.ToString());
//                if (partsBuyBill.DailyReset)
//                {
//                    lastPartsBuyIndex = db.PartsBuy.Count(i => i.CreateTime.Value.Day == DateTime.Now.Day);
//                }
//                else
//                {
//                    lastPartsBuyIndex = db.PartsBuy.Count();
//                }
//                index = (lastPartsBuyIndex + 1).ToString();
//                switch (partsBuyBill.SerNoLength)
//                {
//                    case BillSerNoLength.两位:
//                        index = index.PadLeft(2, '0');
//                        break;
//                    case BillSerNoLength.三位:
//                        index = index.PadLeft(3, '0');
//                        break;
//                    case BillSerNoLength.四位:
//                        index = index.PadLeft(4, '0');
//                        break;
//                    case BillSerNoLength.五位:
//                        index = index.PadLeft(5, '0');
//                        break;
//                    case BillSerNoLength.六位:
//                        index = index.PadLeft(6, '0');
//                        break;
//                }
//                switch (partsBuyBill.DateFormat)
//                {
//                    case BillDateFormat.简洁年月日:
//                        dateFormat = DateTime.Now.ToString("yyMMdd");
//                        break;
//                    case BillDateFormat.完整年月日:
//                        dateFormat = DateTime.Now.ToString("yyyyMMdd");
//                        break;
//                    case BillDateFormat.无:
//                        dateFormat = "";
//                        break;
//                }
//                billNo = partsBuyBill.Prefix + dateFormat + index;
//                return billNo;
//            }
//        }
    }
}
