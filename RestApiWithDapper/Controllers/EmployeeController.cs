using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiWithDapper.Interfaces;
using RestApiWithDapper.Models;

namespace RestApiWithDapper.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDapper Idapper;

        public EmployeeController(IDapper idapper)
        {
            Idapper = idapper;
        }
       
        [HttpPost]
        public async Task<int> Create([FromBody] Employee employee)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@FirstName", employee.FirstName, DbType.String);
            dbparams.Add("@LastName", employee.LastName, DbType.String);
            dbparams.Add("@Department", employee.Department, DbType.String);
            dbparams.Add("@JobTitle", employee.JobTitle, DbType.String);
            dbparams.Add("@PhoneExtension", employee.PhoneExtension, DbType.String);
            dbparams.Add("@Salary", employee.Salary, DbType.String);
            dbparams.Add("@Bonus", employee.Bonus, DbType.String);
            var result = await Task.FromResult(Idapper.Insert<string>("SPInsertInfo", dbparams,commandType: CommandType.StoredProcedure));
            return 0;
        }

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            var result = await Task.FromResult(Idapper.GetAll<Employee>("SPGetAllEmployeeData", null, commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpGet("{Id:int}")]
        public async Task<Employee> Get(int Id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@id", Id, DbType.Int32);
            var result = await Task.FromResult(Idapper.Get<Employee>($"SPGetParticularEmployee", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpDelete("{Id:int}")]
        public async Task<int> Delete(int Id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@id", Id, DbType.Int32);
            var result = await Task.FromResult(Idapper.Execute($"SPDeleteEmployee", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }



        [HttpPut]
        public async Task<int> Update([FromBody] Employee employee)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@FirstName", employee.FirstName, DbType.String);
            dbparams.Add("@LastName", employee.LastName, DbType.String);
            dbparams.Add("@Department", employee.Department, DbType.String);
            dbparams.Add("@JobTitle", employee.JobTitle, DbType.String);
            dbparams.Add("@PhoneExtension", employee.PhoneExtension, DbType.String);
            dbparams.Add("@Salary", employee.Salary, DbType.String);
            dbparams.Add("@Bonus", employee.Bonus, DbType.String);
            dbparams.Add("@id", employee.EmployeeId, DbType.Int32);

            var updateArticle = await Task.FromResult(Idapper.Update<string>("SPUpdatEmployee", dbparams, commandType: CommandType.StoredProcedure));
            return 0;
        }
    }

}
