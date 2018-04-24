using System.Collections.Generic;
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
                    Description = "ϵͳĬ������",
                    CreateTime = DateTime.Now
                };
                context.Organization.Add(defaultDepartment);
                if (!context.User.Any())
                {
                    var defaultUser = new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ĭ�Ϲ���Ա",
                        Account = "admin",
                        Password = "admin",
                        Description = "ϵͳĬ������",
                        Org = defaultDepartment,
                        CreateTime = DateTime.Now
                    };
                    context.User.Add(defaultUser);
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
                                        Url = CommonUrl.WashCarCreate
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "�ۺϿ���",
                                        Url = CommonUrl.RepairCreate
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
                                        Url = CommonUrl.BookingCreate
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "ԤԼ�б�",
                                        Url = CommonUrl.BookingList
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
                                        Url = CommonUrl.Supplier
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "�������",
                                        Url = CommonUrl.PartDictionary
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
                                        Url = CommonUrl.UseOrReturn
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
                                        Url = CommonUrl.Customer
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "����",
                                        OrderNum = 1,
                                        Url = CommonUrl.Car
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
                                        Url = CommonUrl.Query
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ֵ���",
                                        OrderNum = 1,
                                        Url = CommonUrl.Integral
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
                                        Url = CommonUrl.DailyRepairReport
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��ʱ��ɱ���",
                                        OrderNum = 1,
                                        Url = CommonUrl.WorkHourPay
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
                                        Url = CommonUrl.BusinessSituation
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ë��ͳ��",
                                        OrderNum = 1,
                                        Url = CommonUrl.PartDictionaryProfit
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
                                        Url = CommonUrl.OrgSchemaUrl
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "Ա������",
                                        OrderNum = 1,
                                        Url = CommonUrl.EmployeeManagement
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��λ����",
                                        OrderNum = 2,
                                        Url = CommonUrl.JobManagement
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
                                        Url = CommonUrl.RepairItem
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά����Ŀ����",
                                        OrderNum = 1,
                                        Url = CommonUrl.RepairItemType
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
                                        Url = CommonUrl.ParameterControll
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ݺ�����",
                                        OrderNum = 1,
                                        Url = CommonUrl.OrderNoSetting
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
                                        Url = CommonUrl.OperationLog
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "������־",
                                        OrderNum = 1,
                                        Url = CommonUrl.DataLog
                                    }
                                }
                            }
                        }
                    }
                };
                context.Menu.AddRange(defaultMenus);
            }
        }
    }
}
