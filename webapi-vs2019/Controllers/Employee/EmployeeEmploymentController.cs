using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployeeEmploymentController : ApiController
    {
        dbContext _db = new dbContext();
        [HttpPost]
        [Route("api/create/employee/employment")]
        public IHttpActionResult Create(EmploymentHistory employmentHistoryObj)
        {
            _db.employmentHistories.Add(employmentHistoryObj);
            _db.SaveChanges();
            return Ok(employmentHistoryObj);
        }

        [HttpGet]
        [Route("api/get/employee/employment/{uid}")]
        public IHttpActionResult GetEmployeeEmployment(string uid)
        {
            var result = _db.employmentHistories.Where(x => x.Uid == uid).ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpPut]
        [Route("api/update/employee/employment")]
        public IHttpActionResult Update(EmploymentHistory educationObj)
        {
            var result = _db.employmentHistories.Find(educationObj.Id);
            if (result != null)
            {
                result.Title = educationObj.Title;
                result.Description = educationObj.Description;
                result.Year = educationObj.Year;
                _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(result);
            }
            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employee/employment/{Id}")]
        public IHttpActionResult DeleteEmployeeEducation(int Id)
        {
            var result = _db.employmentHistories.Find(Id);
            if (result != null)
            {
                _db.employmentHistories.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}