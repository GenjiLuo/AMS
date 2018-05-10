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
                    OrderNo = i.OrderNo,
                    BillNo = i.BillNo,
                    State = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    ReadyToPay = i.ReadyToPay,
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name,
                    Description = i.Description,
                    Parts = i.Parts.Select(j=>new PartsDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        PartsCode = j.PartsDictionary.Code,
                        BrandName = j.PartsDictionary.BrandName,
                        Name = j.PartsDictionary.Name,
                        Price = j.Price,
                        Count = j.Count,
                        PartsBuyId = j.PartsBuyId
                    }).ToList()
                }).ToList();
                return partsBuys;
            }
        }

        public ResModel AddPartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsBuy = new PartsBuy()
                {
                    Id = Guid.NewGuid(),
                    SupplierId = partsBuyDto.SupplierId,
                    OrderNo = "",
                    BillNo = "",
                    State = PartsBuyState.未审核,
                    ApplyUser = operationUser.Name,
                    OperationTime = DateTime.Now,
                    TotalMoney = partsBuyDto.TotalMoney,
                    ReadyToPay = partsBuyDto.TotalMoney,
                    WarehouseId = partsBuyDto.WarehouseId,
                    Description = partsBuyDto.Description
                };
                var parts = partsBuyDto.Parts.Select(i => new Parts()
                {
                    Id = Guid.NewGuid(),
                    PartsDictionaryId = i.PartsDictionaryId,
                    Price = i.Price,
                    Count = i.Count,
                    PartsBuyId = partsBuy.Id,
                    WarehouseId = partsBuy.WarehouseId
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.PartsBuy.Add(partsBuy);
                        db.Parts.AddRange(parts);
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
                    OrderNo = i.OrderNo,
                    BillNo = i.BillNo,
                    State = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    ReadyToPay = i.ReadyToPay,
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name,
                    Description = i.Description,
                    Parts = i.Parts.Select(j => new PartsDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        PartsCode = j.PartsDictionary.Code,
                        BrandName = j.PartsDictionary.BrandName,
                        Name = j.PartsDictionary.Name,
                        Price = j.Price,
                        Count = j.Count,
                        PartsBuyId = j.PartsBuyId
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
                var parts = partsBuyDto.Parts.Select(i => new Parts()
                {
                    Id = Guid.NewGuid(),
                    PartsDictionaryId = i.PartsDictionaryId,
                    Price = i.Price,
                    Count = i.Count,
                    PartsBuyId = partsBuy.Id,
                    WarehouseId = partsBuy.WarehouseId
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.Parts.RemoveRange(partsBuy.Parts);
                        db.SaveChanges();
                        db.Parts.AddRange(parts);
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
                    return new ResModel() { Msg = "删除采购入库失败，该采购入库已付款", Success = false };
                }
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        db.Parts.RemoveRange(partsBuy.Parts);
                        db.PartsBuy.Remove(partsBuy);
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
                    OrderNo = i.OrderNo,
                    BillNo = i.BillNo,
                    State = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    ReadyToPay = i.ReadyToPay,
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name,
                    Description = i.Description,
                    Parts = i.Parts.Select(j => new PartsDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        PartsCode = j.PartsDictionary.Code,
                        BrandName = j.PartsDictionary.BrandName,
                        Name = j.PartsDictionary.Name,
                        Price = j.Price,
                        Count = j.Count,
                        PartsBuyId = j.PartsBuyId
                    }).ToList()
                }).ToList();
                return partsBuys;
            }
        }
    }
}
