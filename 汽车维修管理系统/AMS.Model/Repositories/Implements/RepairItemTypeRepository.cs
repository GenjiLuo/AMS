using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class RepairItemTypeRepository : IRepairItemTypeRepository
    {
        public List<RepairItemTypeDto> GetAllRepairItemType()
        {
            using (var db=new ModelContext())
            {
                var repariItemTypes = db.RepairItemType.Select(i => new RepairItemTypeDto()
                {
                    Id=i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    OperationType = i.OperationType
                }).ToList();
                return repariItemTypes;
            }
        }

        public ResModel AddRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var repairItemType = new RepairItemType()
                {
                    Id = Guid.NewGuid(),
                    Name = repairItemTypeDto.Name,
                    Description=repairItemTypeDto.Description
                };
                try
                {
                    db.RepairItemType.Add(repairItemType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加维修项目类型失败",Success = false};
                }
                return new ResModel() { Msg = "添加维修项目类型成功", Success = true };
            }
        }

        public RepairItemTypeDto GetOneRepairItemType(Guid repairItemTypeId)
        {
            using (var db=new ModelContext())
            {
                var repairItemType = db.RepairItemType.Where(i => i.Id == repairItemTypeId).Select(i=>new RepairItemTypeDto()
                {
                    Id=i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    OperationType = i.OperationType
                }).FirstOrDefault();
                return repairItemType;
            }
        }

        public ResModel UpdateRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var repairItemType = db.RepairItemType.FirstOrDefault(i => i.Id == repairItemTypeDto.Id);
                if (repairItemType == null)
                {
                    return new ResModel(){Msg = "更新维修项目类型失败，未找到该维修项目类型",Success = false};
                }

                try
                {
                    repairItemType.Name = repairItemTypeDto.Name;
                    repairItemType.Description = repairItemTypeDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                   return new ResModel(){Msg = "更新维修项目类型失败",Success = false};
                }
                return new ResModel() { Msg = "更新维修项目类型成功", Success = true };
            }
        }

        public ResModel DeleteRepairItemType(Guid repairItemTypeId)
        {
            using (var db = new ModelContext())
            {
                var repairItemType = db.RepairItemType.FirstOrDefault(i => i.Id == repairItemTypeId);
                if (repairItemType == null)
                {
                    return new ResModel() { Msg = "删除维修项目类型失败，未找到该维修项目类型", Success = false };
                }

                try
                {
                    db.RepairItemType.Remove(repairItemType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除维修项目类型失败", Success = false };
                }
                return new ResModel() { Msg = "删除维修项目类型成功", Success = true };
            }
        }
    }
}
