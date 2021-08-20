using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployerMessageTemplateController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employer/message/template")]
        public IHttpActionResult Create(MessageTemplate messageTemplateObj)
        {
            _db.messageTemplates.Add(messageTemplateObj);
            _db.SaveChanges();
            return Ok(messageTemplateObj);
        }

        [HttpGet]
        [Route("api/get/employer/message/template/{uid}")]
        public IHttpActionResult GetEmployerMessage(string uid)
        {
            var result = _db.messageTemplates.Where(x => x.Uid == uid).ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpPut]
        [Route("api/update/employer/message/template")]
        public IHttpActionResult Update(MessageTemplate messageTemplateObj)
        {
            var result = _db.messageTemplates.Find(messageTemplateObj.Id);

            if (result != null)
            {
                result.Message = messageTemplateObj.Message;

                _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(result);
            }

            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employer/message/template/{Id}")]
        public IHttpActionResult Delete(int Id)
        {
            var result = _db.messageTemplates.Find(Id);
            if (result != null)
            {
                _db.messageTemplates.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}