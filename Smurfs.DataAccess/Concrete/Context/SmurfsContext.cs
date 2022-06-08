using Microsoft.EntityFrameworkCore;
using Smurfs.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.DataAccess.Concrete.Context
{
    public class SmurfsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server Name:45.158.14.184; Initial Catalog=SmurfDb;" +
                "Authentication Type:SQL Server Authentication;" +
                "Login:sa; Password:DzdTech2022++");
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<CallStatus> CallStatus { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DZDStatus> DZDStatuses { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

    }
}
