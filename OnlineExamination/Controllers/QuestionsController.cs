using OnlineExamination.Models;
using OnlineExamination.ViewModels;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using System.Linq;

namespace OnlineExamination.Controllers
{
    public class QuestionsController : Controller
    {

        private readonly ApplicationDbContext _Context;

        public QuestionsController()
        {
            _Context = new ApplicationDbContext();
        }

        public ActionResult Create(ExamDetailsViewModel viewmodel)
        {
            var question = viewmodel.QuestionModel;
            question.ExamId = viewmodel.DomainModel.Id;
            if (ModelState.IsValid)
            {
                
                _Context.Question.Add(question);
                _Context.SaveChanges();
                return RedirectToAction("Details","Exams",new {id = viewmodel.DomainModel.Id });
            }

            return RedirectToAction("Details", "Exams", new { id = viewmodel.DomainModel.Id });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var question = _Context.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Question question)
        {
          
            if (ModelState.IsValid)
            {
                _Context.Entry(question).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("Details", "Exams", new { id = question.ExamId });
            }
            return View(question);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var question = _Context.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var question = _Context.Question.Find(id);
            _Context.Question.Remove(question);
            _Context.SaveChanges();
            return RedirectToAction("Details", "Exams", new { id = question.ExamId });
        }


        public ActionResult Details(int id)
        {
            var ViewModel = new QuestionDetailsViewModel
            {
                DomainModel = _Context.Question.Include(m => m.Choices).SingleOrDefault(m => m.Id == id),
                ChoiceModel = new Choice()
            };

            return View(ViewModel);
        }

    }
}