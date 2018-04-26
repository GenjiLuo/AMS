using System;
using System.Linq;
using AMS.Model.dto;
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
    }
}
