using System.Collections.Generic;
using AMS.Model.poco;

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
                    Name = "Ĭ�ϲ���"
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
                        CreateTime = DateTime.Now,
                        CreateBy = Guid.Empty,
                        Org = defaultDepartment
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
                        Icon = "../Content/img/common/service.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά�޹���",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ϴ������",
                                        Url = "ϴ������Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�ۺϿ���",
                                        Url = "�ۺϿ���Url"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ԤԼ����",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�½�ԤԼ",
                                        Url = "�½�ԤԼUrl"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ԤԼ�б�",
                                        Url = "ԤԼ�б�Url"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "�������",
                        Icon = "../Content/img/common/warehouse.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��������",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��Ӧ�̹���",
                                        Url = "��Ӧ�̹���Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�������",
                                        Url = "�������Url"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά������",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά��������",
                                        Url = "ά��������Url"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "�ͻ���ϵ",
                        Icon = "../Content/img/common/customer.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "�ͻ�����",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�ͻ�",
                                        Url = "�ͻ�Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "����",
                                        Url = "����Url"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ҵ�����",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "�ۺϲ�ѯ",
                                        Url = "�ۺϲ�ѯUrl"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ֵ���",
                                        Url = "���ֵ���Url"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "�������",
                        Icon = "../Content/img/common/report.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "���񱨱�",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά��ͳ���ձ�",
                                        Url = "ά��ͳ���ձ�Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��ʱ��ɱ���",
                                        Url = "��ʱ��ɱ���Url"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��Ӫ����",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��Ӫ�ſ�����",
                                        Url = "��Ӫ�ſ�����Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ë��ͳ��",
                                        Url = "���ë��ͳ��Url"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "��������",
                        Icon = "../Content/img/common/baseinfo.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "��˾����",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "Ա������",
                                        Url = "Ա������Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��λ����",
                                        Url = "��λ����Url"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ά���ֵ�",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά������",
                                        Url = "ά������Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "ά����Ŀ����",
                                        Url = "ά����Ŀ����Url"
                                    }
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        Id = Guid.NewGuid(),
                        Name = "ϵͳ����",
                        Icon = "../Content/img/common/system.png",
                        SubMenu = new List<Menu>()
                        {
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ϵͳ����",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "��������",
                                        Url = "��������Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "���ݺ�����",
                                        Url = "���ݺ�����Url"
                                    }
                                }
                            },
                            new Menu()
                            {
                                Id = Guid.NewGuid(),
                                Name = "ϵͳ��־",
                                Icon = "fa-book",
                                SubMenu = new List<Menu>()
                                {
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "������־",
                                        Url = "������־Url"
                                    },
                                    new Menu()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "������־",
                                        Url = "������־Url"
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
