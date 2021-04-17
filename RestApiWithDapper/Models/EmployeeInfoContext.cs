
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithDapper.Models
{
    public class EmployeeInfoContext : DbContext
    {
        public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options) : base(options) { }
        //public DbSet<Employee> EmployeeInformation { get; set; }
    }
}
