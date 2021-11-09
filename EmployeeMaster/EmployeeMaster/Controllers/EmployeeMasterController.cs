using EmployeeMaster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaster.Controllers
{
    //[Route("api/[controller]")]
   // [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        Employee emp;
        public EmployeeMasterController(IConfiguration config)
        {
            emp = new Employee(config["DefaultConnection"]);

        }
       

        // Employee emp = new Employee("Data Source=DESKTOP-4U5NJOS;Initial Catalog=master; Integrated Security=true");
        //    string Connection;
        //    public EmployeeController()
        //    {
        //         Connection = "Data Source=DESKTOP-4U5NJOS;Initial Catalog=employeeBD; Integrated Security=true";
        //        // SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4U5NJOS;Initial Catalog=employeeBD; Integrated Security=true");

        //    }



        [Route("api/Employee")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel e)
        {
            if (emp.AddEmp(e) == 0)
            {
                return StatusCode(404, "Empty List");

            }
            else
            {
                return Ok("Added");

            }
        }


        [Route("api/Employee")]
        [HttpGet]
        public async Task<IActionResult> AllEmployee()
        {
            IEnumerable<EmployeeModel> employee = emp.AllEmployee();

            if (employee == null)
            {
                return StatusCode(404, "Empty List");
            }

            return Ok(employee);
        }


        [Route("api/Employee/{id}")]
        [HttpGet]
        public async Task<IActionResult> EmployeeById(int id)
        {
            if (id < 1)
            {
                return StatusCode(400, "bad request");
            }
            EmployeeModel employee = emp.GetEmpById(id);
            if (employee == null)
            {
                return StatusCode(404, "Record not found");
            }
            return Ok(employee);
        }

        [Route("api/Employee")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeModel e)
        {

            var msg = emp.Update(e);
            if (msg == 0)
            {
                return StatusCode(400, "bad request");

            }
            else
            {
                return Ok("Updated..!");

            }
        }

        [Route("api/Employee/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                if (emp.Delete(id) == 0)
                {
                    return StatusCode(404, "Record not found");
                }
                else
                {
                    return Ok("Deleted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
