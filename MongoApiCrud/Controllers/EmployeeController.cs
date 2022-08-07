using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoApiCrud.Entitys;
using MongoApiCrud.Service.Repository;

namespace MongoApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly EmployeeService _employee = new EmployeeService();


        public EmployeeController()
        {
         
        }


        [Route("GetData")]
        [HttpGet]
        public IActionResult GetData()
        {

            var data = _employee.GetEmployes();
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);

        }


        [Route("AddEmp")]
        [HttpPost]
        public IActionResult AddEmp(Employes obj)
        {
            var data = _employee.AddEmployee(obj);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [Route("EditEmp")]
        [HttpPost]
        public IActionResult EditEmp(Employes obj)
        {
            var data = _employee.AddEmployee(obj);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }




        [Route("DeleteEmp")]
        [HttpDelete]
        public IActionResult DeleteEmp([FromBody] string Id)
        {
            var data = _employee.DeleteEmployee(Id);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [Route("GetEmpByID")]
        [HttpGet]
        public IActionResult GetEmpByID(string Id)
        {
            var data = _employee.GetEmployeeById(Id);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

    }
}