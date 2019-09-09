using OnlineExamination.Models;
using OnlineExamination.ViewModels;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace OnlineExamination.Controllers
{
    public class ChoicesController : Controller
    {
    

        private readonly ApplicationDbContext _Context;

        public ChoicesController()
        {
            _Context = new ApplicationDbContext();
        }

        public ActionResult Create(QuestionDetailsViewModel viewmodel)
        {
            var choice = viewmodel.ChoiceModel;
            var question = _Context.Question.Find(viewmodel.DomainModel.Id);
            choice.QuestionId = viewmodel.DomainModel.Id;
            choice.Question = question;
            if (ModelState.IsValid)
            {
                _Context.Choice.Add(choice);
                _Context.SaveChanges();
                return RedirectToAction("Details", "Questions", new { id = viewmodel.DomainModel.Id });
            }

            return RedirectToAction("Details", "Questions", new { id = viewmodel.DomainModel.Id });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Choice = _Context.Choice.Find(id);
            if (Choice == null)
            {
                return HttpNotFound();
            }
            return View(Choice);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Choice Choice)
        {

            if (ModelState.IsValid)
            {
                _Context.Entry(Choice).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("Details", "Questions", new { id = Choice.QuestionId });
            }
            return View(Choice);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Choice = _Context.Choice.Find(id);
            if (Choice == null)
            {
                return HttpNotFound();
            }
            return View(Choice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Choice = _Context.Choice.Find(id);
            _Context.Choice.Remove(Choice);
            _Context.SaveChanges();
            return RedirectToAction("Details", "Questions", new { id = Choice.QuestionId });
        }

    }
}