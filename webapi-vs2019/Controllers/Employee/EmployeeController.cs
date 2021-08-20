using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployeeController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employee")]
        public IHttpActionResult Create(Employee employeeObj)
        {
            _db.employees.Add(employeeObj);
            _db.SaveChanges();
            return Ok(employeeObj);
        }
        [HttpGet]
        [Route("api/get/employee/all")]
        public IHttpActionResult GetAllEmployee()
        {
            var result = _db.employees.ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }
        [HttpGet]
        [Route("api/get/employee/{uid}")]
        public IHttpActionResult GetEmployee(string uid)
        {
            var result = _db.employees.Where(x => x.Uid == uid).FirstOrDefault();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpPut]
        [Route("api/update/employee")]
        public IHttpActionResult Update(Employee employeeObj)
        {
            var result = _db.employees.Find(employeeObj.Id);

            if (result != null)
            {
                result.FirstName = employeeObj.FirstName;
                result.LastName = employeeObj.LastName;
                result.Address = employeeObj.Address;
                result.ExperienceLevel = employeeObj.ExperienceLevel;
                result.Description = employeeObj.Description;
                _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(result);
            }

            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employee/{Id}")]
        public IHttpActionResult Delete(int Id)
        {
            var result = _db.employees.Find(Id);
            if (result != null)
            {
                _db.employees.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}