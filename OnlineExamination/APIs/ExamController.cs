using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineExamination.Models;

namespace OnlineExamination.Controllers
{
    public class ExamController : ApiController
    {
        private readonly ApplicationDbContext _Context;

        public ExamController()
        {
            _Context = new ApplicationDbContext();
        }

        // GET: api/Exams
        public IEnumerable<Exam> GetExams()
        {
            return _Context.Exam.ToList();
        }

        // GET: api/Exams/5
        [ResponseType(typeof(Exam))]
        public IHttpActionResult GetExam(int id)
        {
            Exam exam = _Context.Exam.Include(m => m.Questions).FirstOrDefault(m=>m.Id==id);
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        // PUT: api/Exams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExam(int id, Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exam.Id)
            {
                return BadRequest();
            }

            _Context.Entry(exam).State = EntityState.Modified;

            try
            {
                _Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams
        [ResponseType(typeof(Exam))]
        public IHttpActionResult PostExam(Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Context.Exam.Add(exam);
            _Context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exam.Id }, exam);
        }

        // DELETE: api/Exams/5
        [ResponseType(typeof(Exam))]
        public IHttpActionResult DeleteExam(int id)
        {
            Exam exam = _Context.Exam.Find(id);
            if (exam == null)
            {
                return NotFound();
            }

            _Context.Exam.Remove(exam);
            _Context.SaveChanges();

            return Ok(exam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamExists(int id)
        {
            return _Context.Exam.Count(e => e.Id == id) > 0;
        }
    }
}