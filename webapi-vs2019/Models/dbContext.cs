using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{
    public class dbContext : DbContext
    {
        public dbContext() : base("capstone05123Db") { }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<EmploymentHistory> employmentHistories { get; set; }
        public DbSet<EmployeeSkills> employeeSkills { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Employer> employers { get; set; }
        public DbSet<MessageTemplate> messageTemplates { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Proposal> proposals { get; set; }

    }
}