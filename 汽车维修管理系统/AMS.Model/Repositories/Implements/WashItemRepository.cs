using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class WashItemRepository : IWashItemRepository
    {
        public List<WashItemDto> GetAllWashItem()
        {
            using (var db=new ModelContext())
            {
                var washItems = db.WashItem.Select(i => new WashItemDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Description = i.Description
                }).ToList();
                return washItems;
            }
        }

        public ResModel AddWashItem(WashItemDto washItemDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var washItem = new WashItem()
                {
                    Id = Guid.NewGuid(),
                    Name = washItemDto.Name,
                    Price = washItemDto.Price,
                    Description = washItemDto.Description
                };
                try
                {
                    db.WashItem.Add(washItem);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                   return new ResModel(){Msg = "添加洗车项目失败",Success = false};
                }
                return new ResModel() { Msg = "添加洗车项目成功", Success = true };
            }
        }

        public WashItemDto GetOneWashItem(Guid washItemId)
        {
            using (var db = new ModelContext())
            {
                var washItem = db.WashItem.Where(i=>i.Id == washItemId).Select(i => new WashItemDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Description = i.Description
                }).FirstOrDefault();
                return washItem;
            }
        }

        public ResModel UpdateWashItem(WashItemDto washItemDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var washItem = db.WashItem.FirstOrDefault(i => i.Id == washItemDto.Id);
                if (washItem == null)
                {
                    return new ResModel(){Msg = "更新洗车项目失败，未找到该洗车项目",Success = false};
                }

                try
                {
                    washItem.Name = washItemDto.Name;
                    washItem.Price = washItemDto.Price;
                    washItem.Description = washItemDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新洗车项目失败", Success = false };
                }
                return new ResModel() { Msg = "更新洗车项目成功", Success = true };
            }
        }

        public ResModel DeleteWashItem(Guid washItemId)
        {
            using (var db = new ModelContext())
            {
                var washItem = db.WashItem.FirstOrDefault(i => i.Id == washItemId);
                if (washItem == null)
                {
                    return new ResModel() { Msg = "删除洗车项目失败，未找到该洗车项目", Success = false };
                }

                try
                {
                    db.WashItem.Remove(washItem);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除洗车项目失败", Success = false };
                }
                return new ResModel() { Msg = "删除洗车项目成功", Success = true };
            }
        }

        public List<WashItemDto> QueryWashItem(string keyword)
        {
            using (var db = new ModelContext())
            {
                var washItems = db.WashItem.Where(i => i.Name.Contains(keyword)).Select(i => new WashItemDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Description = i.Description
                }).ToList();
                return washItems;
            }
        }
    }
}
