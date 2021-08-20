using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployerPostController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employer/posts")]
        public IHttpActionResult Create(Post postObj)
        {
            _db.posts.Add(postObj);
            _db.SaveChanges();
            return Ok(postObj);
        }

        [HttpGet]
        [Route("api/get/employer/posts/all")]
        public IHttpActionResult GetAllEmployerPosts(string uid)
        {
            var result = _db.posts.ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpGet]
        [Route("api/get/employer/posts/{uid}")]
        public IHttpActionResult GetEmployerPosts(string uid)
        {
            var result = _db.posts.Where(x => x.Uid == uid).ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpPut]
        [Route("api/update/employer/posts")]
        public IHttpActionResult Update(Post postObj)
        {
            var result = _db.posts.Find(postObj.Id);

            if (result != null)
            {
                result.Title = postObj.Title;
                result.Location = postObj.Location;
                result.Details = postObj.Details;
                result.ProjectLength = postObj.ProjectLength;
                result.ExperienceLevel = postObj.ExperienceLevel;
                result.Salary = postObj.Salary;
                result.IsVisible = postObj.IsVisible;

                _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(result);
            }

            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employer/posts/{Id}")]
        public IHttpActionResult Delete(int Id)
        {
            var result = _db.posts.Find(Id);
            if (result != null)
            {
                _db.posts.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}