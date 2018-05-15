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
    public class PartsReturnRepository : IPartsReturnRepository
    {
        public List<PartsReturnDto> GetAllPartsReturn()
        {
            using (var db=new ModelContext())
            {
                var partsReturns = db.PartsReturn.Select(i => new PartsReturnDto()
                {
                    Id = i.Id,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    BillNo = i.BillNo,
                    PartsReturnState = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    Description = i.Description,
                    PartsOuts = i.PartsOuts.Select(j => new PartsOutDto()
                    {
                        Id = j.Id,
                        PartsReturnId = j.PartsReturnId,
                        PartsId = j.PartsId,
                        Count = j.Count,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        WarehouseName = j.Parts.Warehouse.Name,
                        Description = j.Description
                    }).ToList()
                }).ToList();
                return partsReturns;
            }
        }

        public ResModel AddPartsReturn(PartsReturnDto partsReturnDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var billNo = "";
                var lastPartsReturnIndex = 0;
                var dateFormat = "";
                var index = 0;
                var indexStr = "";
                var partsReturnBill = db.BillNoSetting.FirstOrDefault(i => i.Name == BillTypeName.配件出库.ToString());
                if (partsReturnBill.DailyReset)
                {
                    var lastPartsReturn = db.PartsReturn.Where(i => i.CreateTime.Value.Day == DateTime.Now.Day).OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastPartsReturnIndex = lastPartsReturn?.BillNoIndex ?? 0;
                }
                else
                {
                    var lastPartsReturn = db.PartsReturn.OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastPartsReturnIndex = lastPartsReturn?.BillNoIndex ?? 0;
                }
                index = lastPartsReturnIndex + 1;
                indexStr = index.ToString();
                switch (partsReturnBill.SerNoLength)
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
                switch (partsReturnBill.DateFormat)
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
                billNo = partsReturnBill.Prefix + dateFormat + indexStr;
                var partsReturn = new PartsReturn()
                {
                    Id = Guid.NewGuid(),
                    SupplierId = partsReturnDto.SupplierId,
                    BillNo = billNo,
                    BillNoIndex = index,
                    State = PartsReturnState.未审核,
                    ApplyUser = operationUser.Name,
                    OperationTime = DateTime.Now,
                    Description = partsReturnDto.Description,
                    CreateTime = DateTime.Now
                };
                var partsOuts = partsReturnDto.PartsOuts.Select(i => new PartsOut()
                {
                    Id = Guid.NewGuid(),
                    PartsReturnId = partsReturn.Id,
                    PartsId = i.PartsId,
                    Count = i.Count,
                    Description = i.Description
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.PartsReturn.Add(partsReturn);
                        db.SaveChanges();
                        db.PartsOut.AddRange(partsOuts);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "添加配件出库单失败",Success = false};
                    }
                    return new ResModel() { Msg = "添加配件出库单成功", Success = true };
                }
            }
        }

        public PartsReturnDto GetOnePartsReturn(Guid partsReturnId)
        {
            using (var db = new ModelContext())
            {
                var partsReturn = db.PartsReturn.Select(i => new PartsReturnDto()
                {
                    Id = i.Id,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    BillNo = i.BillNo,
                    PartsReturnState = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    PartsOuts = i.PartsOuts.Select(j => new PartsOutDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsReturnId = j.PartsReturnId,
                        Count = j.Count,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        WarehouseName = j.Parts.Warehouse.Name,
                        Description = j.Description
                    }).ToList()
                }).FirstOrDefault();
                return partsReturn;
            }
        }

        public ResModel UpdatePartsReturn(PartsReturnDto partsReturnDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsReturn = db.PartsReturn.FirstOrDefault(i => i.Id == partsReturnDto.Id);
                if (partsReturn == null)
                {
                    return  new ResModel(){Msg = "更新配件出库失败，未找到该配件出库",Success = false};
                }
                var partsOuts = partsReturnDto.PartsOuts.Select(i => new PartsOut()
                {
                    Id = Guid.NewGuid(),
                    PartsReturnId = partsReturn.Id,
                    PartsId = i.PartsId,
                    Count = i.Count,
                    Description = i.Description
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        partsReturn.SupplierId = partsReturnDto.SupplierId;
                        partsReturn.ApplyUser = operationUser.Name;
                        partsReturn.OperationTime = DateTime.Now;
                        partsReturn.Description = partsReturnDto.Description;

                        db.PartsOut.RemoveRange(partsReturn.PartsOuts);
                        db.SaveChanges();
                        db.PartsOut.AddRange(partsOuts);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "更新配件出库失败",Success = false};
                    }
                    return new ResModel() { Msg = "更新配件出库成功", Success = true };
                }
            }
        }

        public ResModel DeletePartsReturn(Guid partsReturnId)
        {
            using (var db = new ModelContext())
            {
                var partsReturn = db.PartsReturn.FirstOrDefault(i => i.Id == partsReturnId);
                if (partsReturn == null)
                {
                    return new ResModel() { Msg = "删除配件出库失败，未找到该配件出库", Success = false };
                }

                if (partsReturn.State != PartsReturnState.未审核)
                {
                    return new ResModel(){Msg = "删除配件出库失败，该配件出库已审核出库",Success = false};
                }
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        db.PartsOut.RemoveRange(partsReturn.PartsOuts);
                        db.SaveChanges();
                        db.PartsReturn.Remove(partsReturn);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "删除配件出库失败", Success = false };
                    }
                    return new ResModel() { Msg = "删除配件出库成功", Success = true };
                }
            }
        }

        public List<PartsReturnDto> QueryPartsReturn(string keyword)
        {
            using (var db = new ModelContext())
            {
                var partsReturns = db.PartsReturn.Where(i=>i.Supplier.Name.Contains(keyword)).Select(i => new PartsReturnDto()
                {
                    Id = i.Id,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    BillNo = i.BillNo,
                    PartsReturnState = i.State,
                    ApplyUser = i.ApplyUser,
                    CheckUser = i.CheckUser,
                    OperationTime = i.OperationTime,
                    Description = i.Description,
                    PartsOuts = i.PartsOuts.Select(j => new PartsOutDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsReturnId = j.PartsReturnId,
                        Count = j.Count,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        WarehouseName = j.Parts.Warehouse.Name,
                        Description = j.Description
                    }).ToList()
                }).ToList();
                return partsReturns;
            }
        }

        public ResModel Check(Guid partsReturnId, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsReturn = db.PartsReturn.FirstOrDefault(i => i.Id == partsReturnId);
                if (partsReturn == null)
                {
                    return new ResModel(){Msg = "审核失败，未找到该配件出库",Success = false};
                }

                using (var scope=new TransactionScope())
                {
                    try
                    {
                        partsReturn.State = PartsReturnState.已审核;
                        partsReturn.CheckUser = operationUser.Name;
                        foreach (var partsOut in partsReturn.PartsOuts)
                        {
                            var parts = db.Parts.FirstOrDefault(i => i.Id == partsOut.PartsId);
                            parts.Count -= partsOut.Count;
                            if (parts.Count < 0)
                            {
                                return new ResModel(){Msg = "审核失败，存在出库的配件数量高于在库的配件数量",Success = false};
                            }
                        }

                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "审核失败，原因可能是出库的配件数量高于在库的配件数量",Success = false};
                    }
                    return new ResModel(){Msg = "审核成功，该批配件已成功出库",Success = true};
                }
            }
        }
    }
}
