using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class OrgRepository : IOrgRepository
    {
        public ResModel UpdateOrgHope(OrgDto orgDto, UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var org = db.Organization.FirstOrDefault(i => i.Id == orgDto.Id);
                if (org == null)
                {
                    return new ResModel() { Msg = "修改失败，未找到该部门", Success = false };
                }
                try
                {
                    org.OrgHope = orgDto.OrgHope;
                    org.UpdateBy = userDto.Id;
                    org.UpdateTime=DateTime.Now;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "修改失败", Success = false };
                }
                return new ResModel() {Msg = "修改成功", Success = true};
            }
        }

        public ResModel GetOrgHope(OrgDto orgDto)
        {
            using (var db=new ModelContext())
            {
                var org = db.Organization.FirstOrDefault(i => i.Id == orgDto.Id);
                if (org == null)
                {
                    return new ResModel(){Msg = "未找到该部门的企业寄语",Success = false};
                }
                return new ResModel() { Msg = "", Success = true, Data = new { orgHope = org.OrgHope } };
            }
        }

        public List<OrgDto> GetOrganization()
        {
            using (var db=new ModelContext())
            {
                var orgs = db.Organization.Select(i => new OrgDto()
                {
                    Id=i.Id,
                    Name = i.Name,
                    OrderNum = i.OrderNum,
                    State = i.State,
                    ParentId = i.ParentId,
                    ParentOrgName = i.ParentOrg.Name,
                    Description = i.Description
                });
                return orgs.ToList();
            }
        }

        public ResModel GetOneOrganization(OrgDto orgDto)
        {
            using (var db=new ModelContext())
            {
                var organization = db.Organization.Where(i => i.Id == orgDto.Id).Select(i=>new OrgDto()
                {
                    Id=i.Id,
                    Name = i.Name,
                    ParentId = i.ParentId,
                    ParentOrgName = i.ParentOrg.Name,
                    Description = i.Description,
                    State = i.State,
                }).FirstOrDefault();
                if (organization == null)
                {
                    return new ResModel(){Msg = "没有找到该部门",Success = false};
                }
                return new ResModel() { Msg = "", Success = true,Data = organization};
            }
        }

        public ResModel AddOrganization(OrgDto orgDto, UserDto userDto)
        {
            using (var db=new ModelContext())
            {
                var organization = new Organization()
                {
                    Id = Guid.NewGuid(),
                    Name = orgDto.Name,
                    OrgHope = "愿您成功！",
                    ParentId = orgDto.ParentId,
                    State = (int)OrgStateEnum.激活,
                    Description = orgDto.Description,
                    CreateBy = userDto.Id,
                    CreateTime = DateTime.Now
                };
                try
                {
                    db.Organization.Add(organization);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加失败",Success = false};
                }
                return new ResModel() { Msg = "添加成功", Success = true };
            }
        }

        public ResModel UpdateOrganization(OrgDto orgDto, UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var organization = db.Organization.FirstOrDefault(i => i.Id == orgDto.Id);
                if (organization == null)
                {
                    return new ResModel(){Msg = "更新失败，没有找到该部门",Success = false};
                }

                try
                {
                    organization.Name = orgDto.Name;
                    //organization.ParentId = orgDto.ParentId;
                    organization.Description = orgDto.Description;
                    organization.UpdateBy = userDto.Id;
                    organization.UpdateTime=DateTime.Now;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新失败",Success = false};
                }
                return new ResModel() { Msg = "更新成功", Success = true };
            }
        }

        public ResModel DeleteOrganization(OrgDto orgDto)
        {
            using (var db = new ModelContext())
            {
                var organization = db.Organization.FirstOrDefault(i => i.Id == orgDto.Id);
                if (organization == null)
                {
                    return new ResModel() { Msg = "删除失败，没有找到该部门", Success = false };
                }

                try
                {
                    db.Organization.Remove(organization);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除失败,该部门含下属部门或员工", Success = false };
                }
                return new ResModel() { Msg = "删除成功", Success = true };
            }
        }

        public ResModel DisableOrganization(OrgDto orgDto, UserDto userDto)
        {
            using (var db=new ModelContext())
            {
                var organization = db.Organization.FirstOrDefault(i => i.Id == orgDto.Id && i.State == (int) OrgStateEnum.激活);
                if (organization == null)
                {
                    return new ResModel() { Msg = "禁用失败，没有找到该部门或已被禁用", Success = false };
                }

                try
                {
                    organization.State = (int)OrgStateEnum.禁用;
                    organization.UpdateTime=DateTime.Now;
                    organization.UpdateBy = userDto.Id;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "禁用失败", Success = false };
                }
                return new ResModel() { Msg = "禁用成功", Success = true };
            }
        }

        public ResModel AcitveOrganization(OrgDto orgDto, UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var organization = db.Organization.FirstOrDefault(i => i.Id == orgDto.Id && i.State == (int)OrgStateEnum.禁用);
                if (organization == null)
                {
                    return new ResModel() { Msg = "激活失败，没有找到该部门或已被激活", Success = false };
                }

                try
                {
                    organization.State = (int)OrgStateEnum.激活;
                    organization.UpdateTime = DateTime.Now;
                    organization.UpdateBy = userDto.Id;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "激活失败", Success = false };
                }
                return new ResModel() { Msg = "激活成功", Success = true };
            }
        }
    }
}
