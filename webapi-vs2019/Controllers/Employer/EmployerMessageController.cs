using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployerMessageController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employer/message")]
        public IHttpActionResult Create(Notification notificationObj)
        {
            _db.notifications.Add(notificationObj);
            _db.SaveChanges();
            return Ok(notificationObj);
        }

        [HttpGet]
        [Route("api/get/employer/message/{uid}")]
        public IHttpActionResult GetEmployerMessage(string uid)
        {
            var result = _db.notifications.Where(x => x.Uid == uid).ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employer/message/{Id}")]
        public IHttpActionResult Delete(int Id)
        {
            var result = _db.notifications.Find(Id);
            if (result != null)
            {
                _db.notifications.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}