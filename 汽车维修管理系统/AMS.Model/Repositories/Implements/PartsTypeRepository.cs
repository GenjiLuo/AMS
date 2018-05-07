using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AutoMapper;

namespace AMS.Model.Repositories.Implements
{
    public class PartsTypeRepository : IPartsTypeRepository
    {
        public PartsTypeRepository()
        {
        }
        public List<PartsTypeDto> GetAllPartsType()
        {
            using (var db=new ModelContext())
            {
                var partsTypes = db.PartsType.Select(i=>new PartsTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    ParentId = i.ParentId,
                    ParentName = i.ParentPartsType.Name,
                    Description = i.Description
                }).ToList();
                return partsTypes;
            }
        }

        public PartsTypeDto GetOnePartsType(Guid partsTypeId)
        {
            using (var db = new ModelContext())
            {
                var partsType = db.PartsType.Where(i=>i.Id == partsTypeId).Select(i => new PartsTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    ParentId = i.ParentId,
                    ParentName = i.ParentPartsType.Name,
                    Description = i.Description
                }).FirstOrDefault();
                return partsType;
            }
        }

        public ResModel AddPartsType(PartsTypeDto partsTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsType=new PartsType()
                {
                    Id = Guid.NewGuid(),
                    Name = partsTypeDto.Name,
                    ParentId = partsTypeDto.ParentId == Guid.Empty ? null : partsTypeDto.ParentId,
                    Description = partsTypeDto.Description
                };
                try
                {
                    db.PartsType.Add(partsType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加失败",Success = false};
                }
                return new ResModel() { Msg = "添加成功", Success = true };
            }
        }

        public ResModel UpdatePartsType(PartsTypeDto partsTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsType = db.PartsType.FirstOrDefault(i => i.Id == partsTypeDto.Id);
                if (partsType == null)
                {
                    return new ResModel(){Msg = "更新配件类型失败，未找到该配件类型",Success = false};
                }

                try
                {
                    partsType.Name = partsTypeDto.Name;
                    partsType.ParentId = partsTypeDto.ParentId == Guid.Empty ? null : partsTypeDto.ParentId;
                    partsType.Description = partsTypeDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新配件类型失败", Success = false };
                }
                return new ResModel() { Msg = "更新配件类型成功", Success = true };
            }
        }

        public ResModel DeletePartsType(Guid partsTypeId)
        {
            using (var db = new ModelContext())
            {
                var partsType = db.PartsType.FirstOrDefault(i => i.Id == partsTypeId);
                if (partsType == null)
                {
                    return new ResModel() { Msg = "删除配件类型失败，未找到该配件类型", Success = false };
                }

                try
                {
                    db.PartsType.Remove(partsType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除配件类型失败", Success = false };
                }
                return new ResModel() { Msg = "删除配件类型成功", Success = true };
            }
        }

        public List<PartsTypeDto> QueryPartsType(string keyWord)
        {
            using (var db = new ModelContext())
            {
                var partsTypes = db.PartsType.Where(i=>i.Name.Contains(keyWord)).Select(i => new PartsTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    ParentId = i.ParentId,
                    ParentName = i.ParentPartsType.Name,
                    Description = i.Description
                }).ToList();
                return partsTypes;
            }
        }
    }
}
