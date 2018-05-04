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
            //Ԥ��š�Ա��Ĭ������
            if (!context.Organization.Any())
            {
                var defaultDepartment = new Organization()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ĭ�ϲ���",
                    OrderNum = 0,
                    OperationType = (int)OperationTypeEnum.ϵͳԤ��,
                    Description = "ϵͳĬ������",
                    CreateTime = DateTime.Now
                };
                context.Organization.Add(defaultDepartment);
                if (!context.User.Any())
                {
                    var defaultUser = new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = "ϵͳ����Ա",
                        Account = "admin",
                        Password = "admin",
                        Description = "ϵͳĬ������",
                        OperationType = (int)OperationTypeEnum.ϵͳԤ��,
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
                        Name = "�ֿ����Ա",
                        Description = "ϵͳĬ������",
                        OperationType = (int)OperationTypeEnum.ϵͳԤ��,
                        Org = defaultDepartment,
                        CreateTime = DateTime.Now
                    };
                    context.Job.Add(defaultJob);
                }
            }
            //Ԥ��˵�����
            if (!context.Menu.Any())
            {
                var defaultMenus = new List<Menu>()
                {
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "ά�޽Ӵ�",
                        OrderNum = 0,
                        Icon = "../../Content/img/common/service.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά�޹���",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "ϴ������",
                                        Url = CommonUrl.WashCarCreate,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "�ۺϿ���",
                                        Url = CommonUrl.RepairCreate,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ԤԼ����",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "�½�ԤԼ",
                                        Url = CommonUrl.BookingCreate,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "ԤԼ�б�",
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
                        Name = "�������",
                        OrderNum = 1,
                        Icon = "../../Content/img/common/warehouse.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��������",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "��Ӧ�̹���",
                                        Url = CommonUrl.Supplier,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "�������",
                                        Url = CommonUrl.PartDictionary,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά������",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "ά��������",
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
                        Name = "�ͻ���ϵ",
                        OrderNum = 2,
                        Icon = "../../Content/img/common/customer.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "�ͻ�����",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�ͻ�",
                                        OrderNum = 0,
                                        Url = CommonUrl.Customer,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "����",
                                        OrderNum = 1,
                                        Url = CommonUrl.Car,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ҵ�����",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�ۺϲ�ѯ",
                                        OrderNum = 0,
                                        Url = CommonUrl.Query,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ֵ���",
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
                        Name = "�������",
                        OrderNum = 3,
                        Icon = "../../Content/img/common/report.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "���񱨱�",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά��ͳ���ձ�",
                                        OrderNum = 0,
                                        Url = CommonUrl.DailyRepairReport,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��ʱ��ɱ���",
                                        OrderNum = 1,
                                        Url = CommonUrl.WorkHourPay,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��Ӫ����",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��Ӫ�ſ�����",
                                        OrderNum = 0,
                                        Url = CommonUrl.BusinessSituation,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ë��ͳ��",
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
                        Name = "��������",
                        OrderNum = 4,
                        Icon = "../../Content/img/common/baseinfo.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��˾����",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��֯�ṹ",
                                        OrderNum = 0,
                                        Url = CommonUrl.OrgSchemaUrl,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "Ա������",
                                        OrderNum = 1,
                                        Url = CommonUrl.EmployeeManagement,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��λ����",
                                        OrderNum = 2,
                                        Url = CommonUrl.JobManagement,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά���ֵ�",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά������",
                                        OrderNum = 0,
                                        Url = CommonUrl.RepairType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά����Ŀ����",
                                        OrderNum = 1,
                                        Url = CommonUrl.RepairItemType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά����Ŀ",
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
                        Name = "ϵͳ����",
                        OrderNum = 5,
                        Icon = "../../Content/img/common/system.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ϵͳ����",
                                OrderNum = 0,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��������",
                                        OrderNum = 0,
                                        Url = CommonUrl.ParameterControll,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ݺ�����",
                                        OrderNum = 1,
                                        Url = CommonUrl.OrderNoSetting,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ϵͳ��־",
                                OrderNum = 1,
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "������־",
                                        OrderNum = 0,
                                        Url = CommonUrl.OperationLog,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.WashCar.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "������־",
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
            //Ԥ���ݲ˵�
            if (!context.QuickMenu.Any())
            {
                var defaultUser = context.User.FirstOrDefault();
                var defaultMenu1 = context.Menu.FirstOrDefault(i => i.Name == "��֯�ṹ");
                var defaultMenu2 = context.Menu.FirstOrDefault(i => i.Name == "Ա������");

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
