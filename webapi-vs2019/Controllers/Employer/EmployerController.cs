using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployerController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employer")]
        public IHttpActionResult Create(Employer employerObj)
        {
            _db.employers.Add(employerObj);
            _db.SaveChanges();
            return Ok(employerObj);
        }

        [HttpGet]
        [Route("api/get/employer/all")]
        public IHttpActionResult GetAllEmployer()
        {
            var result = _db.employers.ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpGet]
        [Route("api/get/employer/{uid}")]
        public IHttpActionResult GetEmployer(string uid)
        {
            var result = _db.employers.Where(x => x.Uid == uid).FirstOrDefault();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpPut]
        [Route("api/update/employer")]
        public IHttpActionResult Update(Employer employerObj)
        {
            var result = _db.employers.Find(employerObj.Id);

            if (result != null)
            {
                result.FirstName = employerObj.FirstName;
                result.LastName = employerObj.LastName;
                result.CompanyName = employerObj.CompanyName;
                result.CompanyAddress = employerObj.CompanyAddress;

                _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(result);
            }

            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employer/{Id}")]
        public IHttpActionResult Delete(int Id)
        {
            var result = _db.employers.Find(Id);
            if (result != null)
            {
                _db.employers.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}