using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class ServiceTicketTypeRepository : IServiceTicketTypeRepository
    {
        public List<ServiceTicketTypeDto> GetAllServiceTicketType()
        {
            using (var db=new ModelContext())
            {
                var serviceTicketTypes = db.ServiceTicketType.Select(i => new ServiceTicketTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Rate = i.Rate,
                    Description = i.Description
                }).ToList();
                return serviceTicketTypes;
            }
        }

        public ResModel AddServiceTicketType(ServiceTicketTypeDto serviceTicketTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceTicketType = new ServiceTicketType()
                {
                    Id = Guid.NewGuid(),
                    Name = serviceTicketTypeDto.Name,
                    Description = serviceTicketTypeDto.Description,
                    Rate = serviceTicketTypeDto.Rate
                };
                try
                {
                    db.ServiceTicketType.Add(serviceTicketType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加发票类型失败",Success = false};
                }
                return new ResModel() { Msg = "添加发票类型成功", Success = true };
            }
        }

        public ServiceTicketTypeDto GetOneServiceTicketType(Guid serviceTicketTypeId)
        {
            using (var db = new ModelContext())
            {
                var serviceTicketType = db.ServiceTicketType.Where(i=>i.Id == serviceTicketTypeId).Select(i => new ServiceTicketTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Rate = i.Rate,
                    Description = i.Description
                }).FirstOrDefault();
                return serviceTicketType;
            }
        }

        public ResModel UpdateServiceTicketType(ServiceTicketTypeDto serviceTicketTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceTicketType = db.ServiceTicketType.FirstOrDefault(i => i.Id == serviceTicketTypeDto.Id);
                if(serviceTicketType == null)
                {
                    return new ResModel(){Msg = "更新发票类型失败，未找到该发票类型",Success = false};
                }

                try
                {
                    serviceTicketType.Name = serviceTicketTypeDto.Name;
                    serviceTicketType.Description = serviceTicketTypeDto.Description;
                    serviceTicketType.Rate = serviceTicketTypeDto.Rate;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新发票类型失败",Success = false};
                }
                return new ResModel() { Msg = "更新发票类型成功", Success = true };
            }
        }

        public ResModel DeleteServiceTicketType(Guid serviceTicketTypeId)
        {
            using (var db = new ModelContext())
            {
                var serviceTicketType = db.ServiceTicketType.FirstOrDefault(i => i.Id == serviceTicketTypeId);
                if (serviceTicketType == null)
                {
                    return new ResModel() { Msg = "删除发票类型失败，未找到该发票类型", Success = false };
                }

                try
                {
                    db.ServiceTicketType.Remove(serviceTicketType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除发票类型失败", Success = false };
                }
                return new ResModel() { Msg = "删除发票类型成功", Success = true };
            }
        }

        public List<ServiceTicketTypeDto> QueryServiceTicketType(string keyword)
        {
            using (var db = new ModelContext())
            {
                var serviceTicketTypes = db.ServiceTicketType.Where(i=>i.Name.Contains(keyword)).Select(i => new ServiceTicketTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Rate = i.Rate,
                    Description = i.Description
                }).ToList();
                return serviceTicketTypes;
            }
        }
    }
}
