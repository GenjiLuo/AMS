using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class RepairItemRepository : IRepairItemRepository
    {
        public List<RepairItemDto> GetAllRepairItem()
        {
            using (var db=new ModelContext())
            {
                var repairItems = db.RepairItem.Select(i => new RepairItemDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    SerNum = i.SerNum,
                    WorkHour = i.WorkHour,
                    Price = i.Price,
                    IsHot = i.IsHot,
                    Description = i.Description,
                    OperationType = i.OperationType,
                    RepairItemTypeId = i.RepairItemTypeId,
                    RepairItemTypeName = i.RepairItemType.Name
                }).ToList();
                return repairItems;
            }
        }

        public ResModel AddRepairItem(RepairItemDto repairItemDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var repairItem=new RepairItem()
                {
                    Id = Guid.NewGuid(),
                    Name = repairItemDto.Name,
                    Description = repairItemDto.Description,
                    SerNum = repairItemDto.SerNum,
                    WorkHour = repairItemDto.WorkHour,
                    Price = repairItemDto.Price,
                    IsHot = repairItemDto.IsHot,
                    RepairItemTypeId = repairItemDto.RepairItemTypeId
                };
                try
                {
                    db.RepairItem.Add(repairItem);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加维修项目失败",Success = false};
                }
                return new ResModel() { Msg = "添加维修项目成功", Success = true };
            }
        }

        public RepairItemDto GetOneRepairItem(Guid repairItemId)
        {
            using (var db = new ModelContext())
            {
                var repairItem = db.RepairItem.Where(i=>i.Id == repairItemId).Select(i => new RepairItemDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    SerNum = i.SerNum,
                    WorkHour = i.WorkHour,
                    Price = i.Price,
                    IsHot = i.IsHot,
                    Description = i.Description,
                    RepairItemTypeId = i.RepairItemTypeId,
                    RepairItemTypeName = i.RepairItemType.Name
                }).FirstOrDefault();
                return repairItem;
            }
        }

        public ResModel UpdateRepairItem(RepairItemDto repairItemDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var repairItem = db.RepairItem.FirstOrDefault(i => i.Id == repairItemDto.Id);
                if (repairItem == null)
                {
                    return new ResModel(){Msg = "更新维修项目失败，未找到该维修项目",Success = false};
                }

                try
                {
                    repairItem.Name = repairItemDto.Name;
                    repairItem.Description = repairItemDto.Description;
                    repairItem.SerNum = repairItemDto.SerNum;
                    repairItem.WorkHour = repairItemDto.WorkHour;
                    repairItem.Price = repairItemDto.Price;
                    repairItem.IsHot = repairItemDto.IsHot;
                    repairItem.RepairItemTypeId = repairItemDto.RepairItemTypeId;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新维修项目失败",Success = false};
                }
                return new ResModel() { Msg = "更新维修项目成功", Success = true };
            }
        }

        public ResModel DeleteRepairItem(Guid repairItemId)
        {
            using (var db = new ModelContext())
            {
                var repairItem = db.RepairItem.FirstOrDefault(i => i.Id == repairItemId);
                if (repairItem == null)
                {
                    return new ResModel() { Msg = "删除维修项目失败，未找到该维修项目", Success = false };
                }

                try
                {
                    db.RepairItem.Remove(repairItem);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除维修项目失败", Success = false };
                }
                return new ResModel() { Msg = "删除维修项目成功", Success = true };
            }
        }
    }
}
