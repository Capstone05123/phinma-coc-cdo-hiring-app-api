using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployeeEducationController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employee/education")]
        public IHttpActionResult Create(Education educationObj)
        {

            _db.educations.Add(educationObj);
            _db.SaveChanges();
            return Ok(educationObj);

        }

        [HttpGet]
        [Route("api/get/employee/education/{uid}")]
        public IHttpActionResult GetEmployeeEducation(string uid)
        {
            var result = _db.educations.Where(x => x.Uid == uid).ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpPut]
        [Route("api/update/employee/education")]
        public IHttpActionResult Update(Education educationObj)
        {
            var result = _db.educations.Find(educationObj.Id);

            if (result != null)
            {
                result.Degree = educationObj.Degree;
                result.AreaOfStudy = educationObj.AreaOfStudy;
                result.SchoolName = educationObj.SchoolName;
                result.SchoolYear = educationObj.SchoolYear;
                _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(result);
            }

            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employee/education/{Id}")]
        public IHttpActionResult DeleteEmployeeEducation(int Id)
        {
            var result = _db.educations.Find(Id);
            if (result != null)
            {
                _db.educations.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}