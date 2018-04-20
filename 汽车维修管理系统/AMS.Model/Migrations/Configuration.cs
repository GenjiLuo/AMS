using AMS.Model.poco;

namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AMS.Model.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AMS.Model.ModelContext context)
        {
            var defaultDepartment=new Organization()
            {
                Id = Guid.Parse("1eae766f-ea10-4c0d-8424-3c8ce9bc1a13"),
                Name = "默认部门"
            };
            var defaultUser=new User()
            {
                Id = Guid.Parse("722cb8df-6382-4d4a-b04f-60c811415e67"),
                Name = "管理员",
                Account = "admin",
                Password = "admin",
                CreateTime = DateTime.Now,
                CreateBy = Guid.Empty,
                Org = defaultDepartment
            };
            context.Organization.AddOrUpdate(defaultDepartment);
            context.User.AddOrUpdate(defaultUser);

        }
    }
}
