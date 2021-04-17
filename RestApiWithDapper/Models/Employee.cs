using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithDapper.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string PhoneExtension { get; set; }
        [Required]
        public string Salary { get; set; }
        public string Bonus { get; set; }
    }
}
