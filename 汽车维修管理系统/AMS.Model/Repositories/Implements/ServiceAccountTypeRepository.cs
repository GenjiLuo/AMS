using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class ServiceAccountTypeRepository : IServiceAccountTypeRepository
    {
        public List<ServiceAccountTypeDto> GetAllServiceAccountType()
        {
            using (var db=new ModelContext())
            {
                var serviceAccountTypes = db.ServiceAccountType.Select(i => new ServiceAccountTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description
                }).ToList();
                return serviceAccountTypes;
            }
        }

        public ResModel AddServiceAccountType(ServiceAccountTypeDto serviceAccountTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceAccountType = new ServiceAccountType()
                {
                    Id = Guid.NewGuid(),
                    Name = serviceAccountTypeDto.Name,
                    Description = serviceAccountTypeDto.Description
                };
                try
                {
                    db.ServiceAccountType.Add(serviceAccountType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加结算方式失败",Success = false};
                }
                return new ResModel() { Msg = "添加结算方式成功", Success = true };
            }
        }

        public ServiceAccountTypeDto GetOneServiceAccountType(Guid serviceAccountTypeId)
        {
            using (var db = new ModelContext())
            {
                var serviceAccountType = db.ServiceAccountType.Where(i=>i.Id == serviceAccountTypeId).Select(i => new ServiceAccountTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description
                }).FirstOrDefault();
                return serviceAccountType;
            }
        }

        public ResModel UpdateServiceAccountType(ServiceAccountTypeDto serviceAccountTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceAccountType = db.ServiceAccountType.FirstOrDefault(i => i.Id == serviceAccountTypeDto.Id);
                if (serviceAccountType == null)
                {
                    return new ResModel(){Msg = "更新结算方式失败，未找到该结算方式",Success = false};
                }

                try
                {
                    serviceAccountType.Name = serviceAccountTypeDto.Name;
                    serviceAccountType.Description = serviceAccountTypeDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新结算方式失败", Success = false };
                }
                return new ResModel() { Msg = "更新结算方式成功", Success = true };
            }
        }

        public ResModel DeleteServiceAccountType(Guid serviceAccountTypeId)
        {
            using (var db = new ModelContext())
            {
                var serviceAccountType = db.ServiceAccountType.FirstOrDefault(i => i.Id == serviceAccountTypeId);
                if (serviceAccountType == null)
                {
                    return new ResModel() { Msg = "删除结算方式失败，未找到该结算方式", Success = false };
                }

                try
                {
                    db.ServiceAccountType.Remove(serviceAccountType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除结算方式失败", Success = false };
                }
                return new ResModel() { Msg = "删除结算方式成功", Success = true };
            }
        }

        public List<ServiceAccountTypeDto> QueryServiceAccountType(string keyword)
        {
            using (var db = new ModelContext())
            {
                var serviceAccountTypes = db.ServiceAccountType.Where(i=>i.Name.Contains(keyword)).Select(i => new ServiceAccountTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description
                }).ToList();
                return serviceAccountTypes;
            }
        }
    }
}
