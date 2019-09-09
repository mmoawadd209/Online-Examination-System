using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineExamination.Models;

namespace OnlineExamination.APIs
{
    public class ResultController : ApiController
    {
        private readonly ApplicationDbContext Context;

        public ResultController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        // GET: api/Results
        public IEnumerable<Result> GetResults()
        {
            return Context.Result.ToList();
        }

        // GET: api/Results/5
        [ResponseType(typeof(Result))]
        public IHttpActionResult GetResult(int id)
        {
            Result result = Context.Result.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Results/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResult(int id, Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != result.Id)
            {
                return BadRequest();
            }

            Context.Entry(result).State = EntityState.Modified;

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Results
        [ResponseType(typeof(Result))]
        public IHttpActionResult PostResult(Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Result.Add(result);
            Context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = result.Id }, result);
        }

        // DELETE: api/Results/5
        [ResponseType(typeof(Result))]
        public IHttpActionResult DeleteResult(int id)
        {
            Result result = Context.Result.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            Context.Result.Remove(result);
            Context.SaveChanges();

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultExists(int id)
        {
            return Context.Result.Count(e => e.Id == id) > 0;
        }
    }
}