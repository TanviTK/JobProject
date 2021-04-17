using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiWithDapper.Models;

namespace RestApiWithDapper.Controllers
{
    [Route("api/Home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //private readonly EmployeeController EmployeeDetail;
        
        public IActionResult Index()
        {
           //List<Employee> AllEmployeeInformation = EmployeeDetail.Get().Result;
            return null;
        }
    }
}
