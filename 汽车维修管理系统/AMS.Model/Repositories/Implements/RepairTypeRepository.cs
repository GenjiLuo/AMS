using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class RepairTypeRepository : IRepairTypeRepository
    {
        public List<RepairTypeDto> GetAllRepairType()
        {
            using (var db=new ModelContext())
            {
                var repairTypes = db.RepairType.Select(i => new RepairTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    OperationType = i.OperationType
                }).ToList();
                return repairTypes;
            }
        }

        public ResModel AddRepairType(RepairTypeDto repairTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var repairType = new RepairType()
                {
                    Id = Guid.NewGuid(),
                    Name = repairTypeDto.Name,
                    Description = repairTypeDto.Description
                };
                try
                {
                    db.RepairType.Add(repairType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加维修类型失败",Success = false};
                }
                return new ResModel() { Msg = "添加维修类型成功", Success = true };
            }
        }

        public RepairTypeDto GetOneRepairType(Guid repairTypeId)
        {
            using (var db=new ModelContext())
            {
                var repairType = db.RepairType.Where(i => i.Id == repairTypeId).Select(i => new RepairTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    OperationType = i.OperationType
                }).FirstOrDefault();
                return repairType;
            }
        }

        public ResModel UpdateRepairType(RepairTypeDto repairTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var repairType = db.RepairType.FirstOrDefault(i => i.Id == repairTypeDto.Id);
                if (repairType == null)
                {
                    return new ResModel(){Msg = "更新维修类型失败，未找到该维修类型",Success = false};
                }

                try
                {
                    repairType.Name = repairTypeDto.Name;
                    repairType.Description = repairTypeDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新维修类型失败",Success = false};
                }
                return new ResModel() { Msg = "更新维修类型成功", Success = true };
            }
        }

        public ResModel DeleteRepairType(Guid repairTypeId)
        {
            using (var db=new ModelContext())
            {
                var repairType = db.RepairType.FirstOrDefault(i => i.Id == repairTypeId);
                if (repairType == null)
                {
                    return new ResModel() { Msg = "删除维修类型失败，未找到该维修类型", Success = false };
                }

                try
                {
                    db.RepairType.Remove(repairType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除维修类型失败", Success = false };
                }
                return new ResModel() { Msg = "删除维修类型成功", Success = true };
            }
        }
    }
}
