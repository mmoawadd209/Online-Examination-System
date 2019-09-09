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
    public class ChoiceController : ApiController
    {
        private readonly ApplicationDbContext Context;

        public ChoiceController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        // GET: api/Choices
        public IEnumerable<Choice> GetChoices()
        {
            return Context.Choice.ToList();
        }

        // GET: api/Choices/5
        [ResponseType(typeof(Choice))]
        public IHttpActionResult GetChoice(int id)
        {
            Choice choice = Context.Choice.Find(id);
            if (choice == null)
            {
                return NotFound();
            }

            return Ok(choice);
        }

        // PUT: api/Choices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChoice(int id, Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != choice.Id)
            {
                return BadRequest();
            }

            Context.Entry(choice).State = EntityState.Modified;

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoiceExists(id))
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

        // POST: api/Choices
        [ResponseType(typeof(Choice))]
        public IHttpActionResult PostChoice(Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Choice.Add(choice);
            Context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = choice.Id }, choice);
        }

        // DELETE: api/Choices/5
        [ResponseType(typeof(Choice))]
        public IHttpActionResult DeleteChoice(int id)
        {
            Choice choice = Context.Choice.Find(id);
            if (choice == null)
            {
                return NotFound();
            }

            Context.Choice.Remove(choice);
            Context.SaveChanges();

            return Ok(choice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChoiceExists(int id)
        {
            return Context.Choice.Count(e => e.Id == id) > 0;
        }
    }
}