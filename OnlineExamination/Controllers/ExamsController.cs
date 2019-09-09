using OnlineExamination.Models;
using OnlineExamination.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OnlineExamination.Controllers
{
    public class ExamsController : Controller
    {

        private readonly ApplicationDbContext _Context;

        public ExamsController()
        {
            _Context = new ApplicationDbContext();
        }



        // GET: Exams
        public ActionResult Index()
        {
            var ViewModel = new ExamViewModel
            {
                DomainModel = new Exam(),
                ExamsList = _Context.Exam.ToList()
        };
           
            return View(ViewModel);
        }



        // GET: Exams
        public ActionResult Details(int id)
        {
            var ViewModel = new ExamDetailsViewModel
            {
                DomainModel = _Context.Exam.Include(m=>m.Questions).
                SingleOrDefault(m => m.Id == id),
                QuestionModel = new Question()
            };

            
            if (User.IsInRole("Admin"))            
                return View(ViewModel);

            
            return View("PublicDetails",ViewModel);
        }
        public ActionResult Create(ExamViewModel viewmodel)
        {
            var exam = viewmodel.DomainModel;
            if (ModelState.IsValid)
            {
                _Context.Exam.Add(exam);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = _Context.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DurationInMinutes")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _Context.Entry(exam).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = _Context.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = _Context.Exam.Find(id);
            _Context.Exam.Remove(exam);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
