using Microsoft.EntityFrameworkCore;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete.Context
{
    public class SmurfsContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=45.158.14.184;Initial Catalog = SmurfDb;User ID=sa; Password= DzdTech2022++");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =45.158.14.184;User Id=sa;password=DzdTech2022++;Database=SmurfDb;");
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<CallStatus> CallStatus { get; set; }
        public DbSet<CallParameters> CallParameters { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DZDStatus> DZDStatuses { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<GeneralPremium> GeneralPremiums { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectParameters> ProjectParameters { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        
    }
}
