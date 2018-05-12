using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class ParameterControlRepository : IParameterControlRepository
    {
        public ResModel UpdateParameterControl(List<ParameterControlDto> parameterControlDtos, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var parameterControls = parameterControlDtos.Select(i => new ParameterControl()
                {
                    Id = i.Id,
                    ParameterName = i.ParameterName,
                    Value1 = i.Value1,
                    Value2 = i.Value2,
                    Value1Type1 = i.Value1Type1,
                    Value1Type2 = i.Value1Type2
                });
                try
                {
                    db.BulkUpdate(parameterControls);
                    db.BulkSaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新参数控制失败",Success = false};
                }
                return new ResModel() { Msg = "更新参数控制成功", Success = true };
            }
        }

        public List<ParameterControlDto> GetAllParameterControls()
        {
            using (var db=new ModelContext())
            {
                var parameterControls = db.ParameterControl.Select(i => new ParameterControlDto()
                {
                    Id = i.Id,
                    ParameterName = i.ParameterName,
                    Value1 = i.Value1,
                    Value2 = i.Value2,
                    Value1Type1 = i.Value1Type1,
                    Value1Type2 = i.Value1Type2
                }).ToList();
                return parameterControls;
            }
        }
    }
}
