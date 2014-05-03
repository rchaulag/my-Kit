namespace JobBoard.Database.Migrations
{
    using JobBoard.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JobBoard.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobBoard.Database.ApplicationDbContext context)
        {

            context.Companies.AddOrUpdate(
              p => p.Id,
              new Company { Id=1, Name="Google", Location="Mountain View", NumberOfEmployees=34545 },
              new Company { Id=2, Name="Facebook", Location="Fountain View", NumberOfEmployees=34234 },
              new Company { Id=3, Name="Microsoft", Location="Westheimer", NumberOfEmployees=37999 },
              new Company { Id=4, Name="Apple", Location="Pearland", NumberOfEmployees=67878},
              new Company { Id=5, Name="Orange", Location="Bellaire", NumberOfEmployees=35676 }
            );
           
            context.Jobs.AddOrUpdate(
              p => p.Id,
              new Job { Id = 1, Title ="Jr.Dev", Description ="Code, SLeep and eat", Salary=34455, CompanyId=1},
              new Job { Id = 2, Title ="Dev", Description ="Facebook App building", Salary=99888, CompanyId=2},
              new Job { Id = 3, Title ="Sr.Dev", Description ="Application building", Salary=455558, CompanyId=1},
              new Job { Id = 4, Title ="CLeaner", Description ="Clean all Microsoft Products", Salary=99888, CompanyId=3},
              new Job {Id =5,   Title ="Webdevloper", Description ="Facebook App building", Salary=99888, CompanyId=5}
            );

        }
    }
}
