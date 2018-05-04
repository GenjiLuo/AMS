using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Model.poco;
using AMS.Model.Static;

namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ModelContext context)
        {
            //预填部门、员工默认数据
            if (!context.Organization.Any())
            {
                var defaultDepartment = new Organization()
                {
                    Id = Guid.NewGuid(),
                    Name = "默认部门",
                    OrderNum = 0,
                    OperationType = (int)OperationTypeEnum.系统预置,
                    Description = "系统默认数据",
                    CreateTime = DateTime.Now
                };
                context.Organization.Add(defaultDepartment);
                if (!context.User.Any())
                {
                    var defaultUser = new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = "系统管理员",
                        Account = "admin",
                        Password = "admin",
                        Description = "系统默认数据",
                        OperationType = (int)OperationTypeEnum.系统预置,
                        Org = defaultDepartment,
                        CreateTime = DateTime.Now
                    };
                    context.User.Add(defaultUser);
                }
                if (!context.Job.Any())
                {
                    var defaultJob = new Job()
                    {
                        Id = Guid.NewGuid(),
                        Name = "仓库管理员",
                        Description = "系统默认数据",
                        OperationType = (int)OperationTypeEnum.系统预置,
                        Org = defaultDepartment,
                        CreateTime = DateTime.Now
                    };
                    context.Job.Add(defaultJob);
                }
            }
            //预填菜单数据
            if (!context.Menu.Any())
            {
                var defaultMenus = new List<Menu>()
                {
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "维修接待",
                        OrderNum = 0,
                        Icon = "../../Content/img/common/service.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "维修管理",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "洗车开单",
                                        Url = CommonUrl.WashCarCreate,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "综合开单",
                                        Url = CommonUrl.RepairCreate,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "预约管理",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "新建预约",
                                        Url = CommonUrl.BookingCreate,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "预约列表",
                                        Url = CommonUrl.BookingList,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "配件管理",
                        OrderNum = 1,
                        Icon = "../../Content/img/common/warehouse.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "基础数据",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "供应商管理",
                                        Url = CommonUrl.Supplier,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "配件档案",
                                        Url = CommonUrl.PartDictionary,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "维修用料",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "维修领退料",
                                        Url = CommonUrl.UseOrReturn,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "客户关系",
                        OrderNum = 2,
                        Icon = "../../Content/img/common/customer.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "客户资料",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "客户",
                                        OrderNum = 0,
                                        Url = CommonUrl.Customer,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "车辆",
                                        OrderNum = 1,
                                        Url = CommonUrl.Car,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "业务办理",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "综合查询",
                                        OrderNum = 0,
                                        Url = CommonUrl.Query,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "积分调整",
                                        OrderNum = 1,
                                        Url = CommonUrl.Integral,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "报表分析",
                        OrderNum = 3,
                        Icon = "../../Content/img/common/report.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "财务报表",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "维修统计日报",
                                        OrderNum = 0,
                                        Url = CommonUrl.DailyRepairReport,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "工时提成报表",
                                        OrderNum = 1,
                                        Url = CommonUrl.WorkHourPay,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "运营报表",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "经营概况报表",
                                        OrderNum = 0,
                                        Url = CommonUrl.BusinessSituation,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "配件毛利统计",
                                        OrderNum = 1,
                                        Url = CommonUrl.PartDictionaryProfit,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "基础资料",
                        OrderNum = 4,
                        Icon = "../../Content/img/common/baseinfo.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "公司管理",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "组织结构",
                                        OrderNum = 0,
                                        Url = CommonUrl.OrgSchemaUrl,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "员工管理",
                                        OrderNum = 1,
                                        Url = CommonUrl.EmployeeManagement,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "岗位管理",
                                        OrderNum = 2,
                                        Url = CommonUrl.JobManagement,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "维修字典",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "维修类型",
                                        OrderNum = 0,
                                        Url = CommonUrl.RepairType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "维修项目类型",
                                        OrderNum = 1,
                                        Url = CommonUrl.RepairItemType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "维修项目",
                                        OrderNum = 1,
                                        Url = CommonUrl.RepairItem,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "系统设置",
                        OrderNum = 5,
                        Icon = "../../Content/img/common/system.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "系统设置",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "参数控制",
                                        OrderNum = 0,
                                        Url = CommonUrl.ParameterControll,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "单据号配置",
                                        OrderNum = 1,
                                        Url = CommonUrl.OrderNoSetting,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "系统日志",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "操作日志",
                                        OrderNum = 0,
                                        Url = CommonUrl.OperationLog,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "数据日志",
                                        OrderNum = 1,
                                        Url = CommonUrl.DataLog,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            }
                        }
                    }
                };
                context.Menu.AddRange(defaultMenus);
            }
            //预填快捷菜单
            if (!context.QuickMenu.Any())
            {
                var defaultUser = context.User.FirstOrDefault();
                var defaultMenu1 = context.Menu.FirstOrDefault(i => i.Name == "组织结构");
                var defaultMenu2 = context.Menu.FirstOrDefault(i => i.Name == "员工管理");

                if (defaultUser != null && defaultMenu1!=null) 
                {
                    var defaultQuickMenu1 = new QuickMenu()
                    {
                        Id = Guid.NewGuid(),
                        UserId = defaultUser.Id,
                        Menu = defaultMenu1,
                    };
                    context.QuickMenu.Add(defaultQuickMenu1);
                }
                if (defaultUser != null && defaultMenu2 != null)
                {
                    var defaultQuickMenu2 = new QuickMenu()
                    {
                        Id = Guid.NewGuid(),
                        UserId = defaultUser.Id,
                        Menu = defaultMenu2,
                    };
                    context.QuickMenu.Add(defaultQuickMenu2);
                }

            }
        }
    }
}
