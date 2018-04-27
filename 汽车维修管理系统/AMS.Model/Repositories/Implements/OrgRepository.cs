using System;
using System.Collections.Generic;
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
                var orgs = db.Organization.Where(i=>i.State != (int)OrgStateEnum.删除).Select(i => new OrgDto()
                {
                    Id=i.Id,
                    Name = i.Name,
                    OrderNum = i.OrderNum,
                    State = i.State,
                    ParentId = i.ParentId,
                    Description = i.Description
                });
                return orgs.ToList();
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

        public ResModel UpdateOranization(OrgDto orgDto, UserDto userDto)
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
                    organization.State = orgDto.State;
                    organization.ParentId = orgDto.ParentId;
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

        public ResModel DeleteOranization(OrgDto orgDto, UserDto userDto)
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
                    organization.State = (int)OrgStateEnum.删除;
                    organization.UpdateBy = userDto.Id;
                    organization.UpdateTime=DateTime.Now;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除失败", Success = false };
                }
                return new ResModel() { Msg = "删除成功", Success = true };
            }
        }
    }
}
