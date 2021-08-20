using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployeeSkillController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employee/skills")]
        public IHttpActionResult Create(EmployeeSkills employeeSkillsObj)
        {
            _db.employeeSkills.Add(employeeSkillsObj);
            _db.SaveChanges();
            return Ok(employeeSkillsObj);
        }
        [HttpGet]
        [Route("api/get/employee/skills/{uid}")]
        public IHttpActionResult GetEmployeeSkills(string uid)
        {
            var result = _db.employeeSkills.Where(x => x.Uid == uid).ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }
        [HttpDelete]
        [Route("api/remove/employee/skills/{Id}")]
        public IHttpActionResult DeleteEmployeeEducation(int Id)
        {
            var result = _db.employeeSkills.Find(Id);
            if (result != null)
            {
                _db.employeeSkills.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}