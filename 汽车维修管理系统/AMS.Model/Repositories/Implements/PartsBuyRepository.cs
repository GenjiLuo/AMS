using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class PartsBuyRepository : IPartsBuyRepository
    {
        public List<PartsBuyDto> GetAllPartsBuy()
        {
            using (var db=new ModelContext())
            {
                var partsBuys = db.PartsBuy.Select(i => new PartsBuyDto()
                {
                    Id = i.Id,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    BillNo = i.BillNo,
                    PartsBuyState = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    ReadyToPay = i.ReadyToPay,
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name,
                    Description = i.Description,
                    PartsIns = i.PartsIns.Select(j=>new PartsInDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        PartsId = j.PartsId,
                        PartsCode = j.PartsDictionary.Code,
                        BrandName = j.PartsDictionary.BrandName,
                        PartsName = j.PartsDictionary.Name,
                        SupplierPrice = j.SupplierPrice,
                        Count = j.Count,
                        PartsBuyId = j.PartsBuyId,
                        WarehouseName = i.Warehouse.Name,
                        WarehouseId = i.WarehouseId
                    }).ToList()
                }).ToList();
                return partsBuys;
            }
        }

        public ResModel AddPartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var billNo = "";
                var lastPartsBuyIndex = 0;
                var dateFormat = "";
                var index = 0;
                var indexStr = "";
                var partsBuyBill = db.BillNoSetting.FirstOrDefault(i => i.Name == BillTypeName.采购入库.ToString());
                if (partsBuyBill.DailyReset)
                {
                    var lastPartsBuy = db.PartsBuy.Where(i => i.CreateTime.Value.Day == DateTime.Now.Day).OrderByDescending(i=>i.CreateTime).FirstOrDefault();
                    lastPartsBuyIndex = lastPartsBuy?.BillNoIndex ?? 0;
                }
                else
                {
                    var lastPartsBuy = db.PartsBuy.OrderByDescending(i=>i.CreateTime).FirstOrDefault();
                    lastPartsBuyIndex = lastPartsBuy?.BillNoIndex ?? 0;
                }
                index = lastPartsBuyIndex + 1;
                indexStr = index.ToString();
                switch (partsBuyBill.SerNoLength)
                {
                    case BillSerNoLength.两位:
                        indexStr = indexStr.PadLeft(2, '0');
                        break;
                    case BillSerNoLength.三位:
                        indexStr = indexStr.PadLeft(3, '0');
                        break;
                    case BillSerNoLength.四位:
                        indexStr = indexStr.PadLeft(4, '0');
                        break;
                    case BillSerNoLength.五位:
                        indexStr = indexStr.PadLeft(5, '0');
                        break;
                    case BillSerNoLength.六位:
                        indexStr = indexStr.PadLeft(6, '0');
                        break;
                }
                switch (partsBuyBill.DateFormat)
                {
                    case BillDateFormat.简洁年月日:
                        dateFormat = DateTime.Now.ToString("yyMMdd");
                        break;
                    case BillDateFormat.完整年月日:
                        dateFormat = DateTime.Now.ToString("yyyyMMdd");
                        break;
                    case BillDateFormat.无:
                        dateFormat = "";
                        break;
                }
                billNo = partsBuyBill.Prefix + dateFormat + indexStr;

                var partsBuy = new PartsBuy()
                {
                    Id = Guid.NewGuid(),
                    SupplierId = partsBuyDto.SupplierId,
                    BillNo = billNo,
                    BillNoIndex = index,
                    State = PartsBuyState.未审核,
                    ApplyUser = operationUser.Name,
                    OperationTime = DateTime.Now,
                    TotalMoney = partsBuyDto.TotalMoney,
                    ReadyToPay = partsBuyDto.TotalMoney,
                    WarehouseId = partsBuyDto.WarehouseId,
                    Description = partsBuyDto.Description,
                    CreateTime = DateTime.Now,
                };
                var partsIns = partsBuyDto.PartsIns.Select(i => new PartsIn()
                {
                    Id = Guid.NewGuid(),
                    PartsBuyId = partsBuy.Id,
                    PartsDictionaryId = i.PartsDictionaryId,
                    SupplierPrice = i.SupplierPrice,
                    Count = i.Count,
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.PartsBuy.Add(partsBuy);
                        db.PartsIn.AddRange(partsIns);
                        db.SaveChanges();
                        scope.Complete();;
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "添加采购入库失败",Success = false};
                    }
                    return new ResModel() { Msg = "添加采购入库成功", Success = true };
                }
            }
        }

        public PartsBuyDto GetOnePartsBuy(Guid partsBuyId)
        {
            using (var db = new ModelContext())
            {
                var partsBuy = db.PartsBuy.Where(i=>i.Id == partsBuyId).Select(i => new PartsBuyDto()
                {
                    Id = i.Id,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    BillNo = i.BillNo,
                    PartsBuyState = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    ReadyToPay = i.ReadyToPay,
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name,
                    Description = i.Description,
                    PartsIns = i.PartsIns.Select(j => new PartsInDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        PartsId = j.PartsId,
                        PartsCode = j.PartsDictionary.Code,
                        BrandName = j.PartsDictionary.BrandName,
                        PartsName = j.PartsDictionary.Name,
                        SupplierPrice = j.SupplierPrice,
                        Count = j.Count,
                        PartsBuyId = j.PartsBuyId,
                        WarehouseName = i.Warehouse.Name,
                        WarehouseId = i.WarehouseId
                    }).ToList()
                }).FirstOrDefault();
                return partsBuy;
            }
        }

        public ResModel UpdatePartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsBuy = db.PartsBuy.FirstOrDefault(i => i.Id == partsBuyDto.Id);
                if (partsBuy == null)
                {
                    return new ResModel(){Msg = "更新采购入库失败，未找到该采购入库",Success = false};
                }
                partsBuy.SupplierId = partsBuyDto.SupplierId;
                partsBuy.WarehouseId = partsBuyDto.WarehouseId;
                partsBuy.ApplyUser = operationUser.Name;
                partsBuy.OperationTime = DateTime.Now;
                partsBuy.TotalMoney = partsBuyDto.TotalMoney;
                partsBuy.ReadyToPay = partsBuyDto.TotalMoney;
                partsBuy.Description = partsBuyDto.Description;
                var partsIns = partsBuyDto.PartsIns.Select(i => new PartsIn()
                {
                    Id = Guid.NewGuid(),
                    PartsBuyId = partsBuy.Id,
                    PartsDictionaryId = i.PartsDictionaryId,
                    SupplierPrice = i.SupplierPrice,
                    Count = i.Count,
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.PartsIn.RemoveRange(partsBuy.PartsIns);
                        db.SaveChanges();
                        db.PartsIn.AddRange(partsIns);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "更新失败",Success = false};
                    }
                    return new ResModel() { Msg = "更新成功", Success = true };
                }
            }
        }

        public ResModel DeletePartsBuy(Guid partsBuyId)
        {
            using (var db = new ModelContext())
            {
                var partsBuy = db.PartsBuy.FirstOrDefault(i => i.Id == partsBuyId);
                if (partsBuy == null)
                {
                    return new ResModel() { Msg = "删除采购入库失败，未找到该采购入库", Success = false };
                }
                if (partsBuy.State == PartsBuyState.已付款)
                {
                    return new ResModel() { Msg = "删除采购入库失败，该采购入库已付款,不可删除", Success = false };
                }
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        db.PartsIn.RemoveRange(partsBuy.PartsIns);
                        db.PartsBuy.Remove(partsBuy);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "删除失败", Success = false };
                    }
                    return new ResModel() { Msg = "删除成功", Success = true };
                }
            }
        }

        public List<PartsBuyDto> QueryPartsBuy(string keyword)
        {
            using (var db = new ModelContext())
            {
                var partsBuys = db.PartsBuy.Where(i=>i.Supplier.Name.Contains(keyword)).Select(i => new PartsBuyDto()
                {
                    Id = i.Id,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    BillNo = i.BillNo,
                    PartsBuyState = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    ReadyToPay = i.ReadyToPay,
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name,
                    Description = i.Description,
                    PartsIns = i.PartsIns.Select(j => new PartsInDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        PartsId = j.PartsId,
                        PartsCode = j.PartsDictionary.Code,
                        BrandName = j.PartsDictionary.BrandName,
                        PartsName = j.PartsDictionary.Name,
                        SupplierPrice = j.SupplierPrice,
                        Count = j.Count,
                        PartsBuyId = j.PartsBuyId,
                        WarehouseName = i.Warehouse.Name,
                        WarehouseId = i.WarehouseId
                    }).ToList()
                }).ToList();
                return partsBuys;
            }
        }

        public ResModel CheckPartsBuy(Guid partsBuyId ,UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsBuy = db.PartsBuy.FirstOrDefault(i => i.Id == partsBuyId);
                if (partsBuy == null)
                {
                    return new ResModel(){Msg = "审核失败，未找到该采购入库",Success = false};
                }

                if (partsBuy.State != PartsBuyState.未审核)
                {
                    return new ResModel(){Msg = "审核失败，该采购入库已审核",Success = false};
                }

                try
                {
                    partsBuy.State = PartsBuyState.未付款;
                    partsBuy.CheckUser = operationUser.Name;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "审核失败", Success = false };
                }
                return new ResModel() { Msg = "审核成功", Success = true };
            }
        }

        public ResModel UnCheckPartsBuy(Guid partsBuyId)
        {
            using (var db = new ModelContext())
            {
                var partsBuy = db.PartsBuy.FirstOrDefault(i => i.Id == partsBuyId);
                if (partsBuy == null)
                {
                    return new ResModel() { Msg = "取消审核失败，未找到该采购入库", Success = false };
                }

                if (partsBuy.State != PartsBuyState.未付款)
                {
                    return new ResModel() { Msg = "取消审核失败，该采购入库已取消审核或付款", Success = false };
                }

                try
                {
                    partsBuy.State = PartsBuyState.未审核;
                    partsBuy.CheckUser = null;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "取消审核失败", Success = false };
                }
                return new ResModel() { Msg = "取消审核成功", Success = true };
            }
        }

        public ResModel Pay(Guid partsBuyId, decimal money)
        {
            using (var db = new ModelContext())
            {
                var partsBuy = db.PartsBuy.FirstOrDefault(i => i.Id == partsBuyId);
                if (partsBuy == null)
                {
                    return new ResModel() { Msg = "付款失败，未找到该采购入库", Success = false };
                }
                if (partsBuy.State != PartsBuyState.未付款)
                {
                    return new ResModel() { Msg = "付款失败，该采购入库未审核或已付款", Success = false };
                }
                if (partsBuy.ReadyToPay > money)
                {
                    return new ResModel() { Msg = "付款失败，付款金额小于未付款金额", Success = false };
                }
                var newPartsList=new List<Parts>();
                var oldPartsList=new List<Parts>();
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        foreach (var partsIn in partsBuy.PartsIns)
                        {
                            var parts = db.Parts.FirstOrDefault(i=>i.PartsDictionary.Code == partsIn.PartsDictionary.Code && i.WarehouseId.HasValue && i.WarehouseId == partsBuy.WarehouseId);
                            if (parts == null)
                            {
                                parts = new Parts()
                                {
                                    Id = Guid.NewGuid(),
                                    PartsDictionaryId = partsIn.PartsDictionaryId,
                                    Price = partsIn.PartsDictionary.RetailPrice,
                                    Count = partsIn.Count,
                                    WarehouseId = partsBuy.WarehouseId
                                };
                                newPartsList.Add(parts);
                            }
                            else
                            {
                                parts.Count += partsIn.Count;
                                oldPartsList.Add(parts);
                            }
                            partsIn.PartsId = parts.Id;
                        }
                        partsBuy.ReadyToPay = 0;
                        partsBuy.State = PartsBuyState.已付款;
                        db.BulkInsert(newPartsList);
                        db.BulkUpdate(oldPartsList);
                        db.BulkSaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "付款失败", Success = false };
                    }
                    return new ResModel() { Msg = "付款成功，该批配件已成功入库", Success = true };
                }
            }
        }
    }
}
