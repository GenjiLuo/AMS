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
                    CreateTime = DateTime.Now,
                    OrgHope = "�õĿ�ʼ�ǳɹ���һ��"
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
            //�˵�����
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
                                Icon = "fa-gavel",
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
                                        QuickMenuIcon = "../../Content/img/home/Repair.Create.ServiceBooking.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "ԤԼ�б�",
                                        Url = CommonUrl.BookingList,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.ServiceBooking.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��ʷ��ѯ",
                                OrderNum = 1,
                                Icon = "fa-file-text-o",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "ά����ʷ��ѯ",
                                        Url = CommonUrl.RepairHistory,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairHistory.png"
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
                                Icon = "fa-cube",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "��Ӧ��",
                                        Url = CommonUrl.Supplier,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.Supplier.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 1,
                                        Name = "�������",
                                        Url = CommonUrl.PartDictionary,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsDictionary.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 2,
                                        Name = "�ⷿ",
                                        Url = CommonUrl.Warehouse,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.Warehouse.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "���",
                                OrderNum = 1,
                                Icon = "fa-long-arrow-right",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "�ɹ����",
                                        Url = CommonUrl.PartsBuy,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsBuyWarehousing.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "����",
                                OrderNum = 2,
                                Icon = "fa-long-arrow-left",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "�������",
                                        Url = CommonUrl.PartsReturn,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsOtherStackOut.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "���Ԥ��",
                                OrderNum = 3,
                                Icon = "fa-bell",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        OrderNum = 0,
                                        Name = "Ԥ����ѯ",
                                        Url = CommonUrl.PartsWarning,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsInventoryWarning.png"
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
                                Icon = "fa-male",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�ͻ�",
                                        OrderNum = 0,
                                        Url = CommonUrl.Customer,
                                        QuickMenuIcon = "../../Content/img/home/Customer.Index.Customer.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "����",
                                        OrderNum = 1,
                                        Url = CommonUrl.Car,
                                        QuickMenuIcon = "../../Content/img/home/Customer.Index.Car.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ҵ�����",
                                OrderNum = 1,
                                Icon = "fa-street-view",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�ۺϲ�ѯ",
                                        OrderNum = 0,
                                        Url = CommonUrl.Query,
                                        QuickMenuIcon = "../../Content/img/home/Customer.Index.CustomerBusiness.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���Ա��",
                                        OrderNum = 1,
                                        Url = CommonUrl.MemberCardCreate,
                                        QuickMenuIcon = "../../Content/img/home/Member.Create.Member.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��ֵ",
                                        OrderNum = 2,
                                        Url = CommonUrl.Charge,
                                        QuickMenuIcon = "../../Content/img/home/Member.MemberCharge.MemberCharge.png"
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
                                Icon = "fa-area-chart",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά��ͳ���ձ�",
                                        OrderNum = 0,
                                        Url = CommonUrl.DailyRepairReport,
                                        QuickMenuIcon = "../../Content/img/home/Report.RepairDailyReport.FinanceReport.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��Ӫ����",
                                OrderNum = 1,
                                Icon = "fa-area-chart",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��Ӫ�ſ�����",
                                        OrderNum = 0,
                                        Url = CommonUrl.BusinessSituation,
                                        QuickMenuIcon = "../../Content/img/home/Report.GrossmarginReport.RepairReport.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά�ޱ���",
                                OrderNum = 2,
                                Icon = "fa-bar-chart",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά�޲��ϻ���",
                                        OrderNum = 0,
                                        Url = CommonUrl.RepairPartsSummary,
                                        QuickMenuIcon = "../../Content/img/home/Report.RepairMaterialSummarizing.RepairReport.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "�ⷿ����",
                                OrderNum = 3,
                                Icon = "fa-line-chart",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "����̵����",
                                        OrderNum = 0,
                                        Url = CommonUrl.PartsInventoryCheckSummary,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsSaleRanking.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "���ͳ��",
                                OrderNum = 4,
                                Icon = "fa-line-chart",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�����������",
                                        OrderNum = 0,
                                        Url = CommonUrl.PartsSaleRank,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsSaleRanking.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�����������",
                                        OrderNum = 1,
                                        Url = CommonUrl.PartsOverStokedRank,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsSaleRanking.png"
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
                                Icon = "fa-home",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��֯�ṹ",
                                        OrderNum = 0,
                                        Url = CommonUrl.OrgSchemaUrl,
                                        QuickMenuIcon = "../../Content/img/home/Users.Index.Organization.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "Ա������",
                                        OrderNum = 1,
                                        Url = CommonUrl.EmployeeManagement,
                                        QuickMenuIcon = "../../Content/img/home/Users.Index.Organization.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��λ����",
                                        OrderNum = 2,
                                        Url = CommonUrl.JobManagement,
                                        QuickMenuIcon = "../../Content/img/home/Users.Index.Organization.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά���ֵ�",
                                OrderNum = 1,
                                Icon = "fa-cogs",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά������",
                                        OrderNum = 0,
                                        Url = CommonUrl.RepairType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairItemType.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά����Ŀ����",
                                        OrderNum = 1,
                                        Url = CommonUrl.RepairItemType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairItemType.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά����Ŀ",
                                        OrderNum = 2,
                                        Url = CommonUrl.RepairItem,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairItemType.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���㷽ʽ",
                                        OrderNum = 3,
                                        Url = CommonUrl.ServiceAccountType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairItemType.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ʽ",
                                        OrderNum = 4,
                                        Url = CommonUrl.PaymentType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairItemType.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��Ʊ����",
                                        OrderNum = 5,
                                        Url = CommonUrl.ServiceTicketType,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairItemType.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���͹���",
                                        OrderNum = 6,
                                        Url = CommonUrl.CarModel,
                                        QuickMenuIcon = "../../Content/img/home/Repair.Index.RepairItemType.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "����ֵ�",
                                OrderNum = 2,
                                Icon = "fa-cogs",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�������",
                                        OrderNum = 0,
                                        Url = CommonUrl.PartsType,
                                        QuickMenuIcon = "../../Content/img/home/Part.Index.PartsType.png"
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
                                Icon = "fa-cogs",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��������",
                                        OrderNum = 0,
                                        Url = CommonUrl.ParameterControll,
                                        QuickMenuIcon = "../../Content/img/home/System.ParametricControl.SystemSettings.png"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ݺ�����",
                                        OrderNum = 1,
                                        Url = CommonUrl.OrderNoSetting,
                                        QuickMenuIcon = "../../Content/img/home/System.ParametricControl.SystemSettings.png"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ϵͳ��־",
                                OrderNum = 1,
                                Icon = "fa-pencil",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "������־",
                                        OrderNum = 0,
                                        Url = CommonUrl.OperationLog,
                                        QuickMenuIcon = "../../Content/img/home/System.ParametricControl.SystemSettings.png"
                                    }
                                }
                            }
                        }
                    }
                };
                context.Menu.AddRange(defaultMenus);
            }
            //���ݺ�Ĭ������
            if (!context.BillNoSetting.Any())
            {
                var billNoSettings=new List<BillNoSetting>()
                {
                    new BillNoSetting()
                    {
                        Id = Guid.NewGuid(),
                        Name = "�ɹ����",
                        Prefix = "CR",
                        DateFormat = BillDateFormat.���������,
                        SerNoLength = BillSerNoLength.��λ,
                        DailyReset = true,
                        BillNoPreview = "CR1805120001"
                    },
                    new BillNoSetting()
                    {
                        Id = Guid.NewGuid(),
                        Name = "�������",
                        Prefix = "QC",
                        DateFormat = BillDateFormat.���������,
                        SerNoLength = BillSerNoLength.��λ,
                        DailyReset = true,
                        BillNoPreview = "QC1805120001"
                    },
                    new BillNoSetting()
                    {
                        Id = Guid.NewGuid(),
                        Name = "ԤԼ����",
                        Prefix = "YY",
                        DateFormat = BillDateFormat.���������,
                        SerNoLength = BillSerNoLength.��λ,
                        DailyReset = true,
                        BillNoPreview = "YY1805120001"
                    },
                    new BillNoSetting()
                    {
                        Id = Guid.NewGuid(),
                        Name = "�ӳ�����",
                        Prefix = "JC",
                        DateFormat = BillDateFormat.���������,
                        SerNoLength = BillSerNoLength.��λ,
                        DailyReset = true,
                        BillNoPreview = "JC1805120001"
                    },
                    new BillNoSetting()
                    {
                        Id = Guid.NewGuid(),
                        Name = "��Ա��ֵ",
                        Prefix = "MC",
                        DateFormat = BillDateFormat.���������,
                        SerNoLength = BillSerNoLength.��λ,
                        DailyReset = true,
                        BillNoPreview = "MC1805120001"
                    }
                };
                context.BillNoSetting.AddRange(billNoSettings);
            }
        }
    }
}
