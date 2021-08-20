using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using webapi_vs2019.Models;

namespace webapi_vs2019.Controllers
{
    public class EmployerProposalController : ApiController
    {
        dbContext _db = new dbContext();

        [HttpPost]
        [Route("api/create/employer/proposal")]
        public IHttpActionResult Create(Proposal proposalObj)
        {
            _db.proposals.Add(proposalObj);
            _db.SaveChanges();
            return Ok(proposalObj);
        }

        [HttpGet]
        [Route("api/get/employer/proposal/{uid}")]
        public IHttpActionResult GetAllProposal(string uid)
        {
            var result = _db.proposals.Where(x => x.Uid == uid).ToList();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Result not found");
        }

        [HttpPut]
        [Route("api/update/employer/proposal")]
        public IHttpActionResult Update(string id, bool isApproved)
        {
            var result = _db.proposals.Find(id);

            if (result != null)
            {
                result.isApproved = isApproved;

                _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(result);
            }

            else
                return BadRequest("Result not found");
        }

        [HttpDelete]
        [Route("api/remove/employer/proposal/{Id}")]
        public IHttpActionResult Delete(int Id)
        {
            var result = _db.proposals.Find(Id);
            if (result != null)
            {
                _db.proposals.Remove(result);
                _db.SaveChanges();
                return Ok("Removed successfully!");
            }
            else
                return BadRequest("Result not found");
        }
    }
}