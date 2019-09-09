using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineExamination.Models;
using OnlineExamination.ViewModels;

namespace OnlineExamination.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ApplicationDbContext _Context;

        public ResultsController()
        {
            _Context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var result = _Context.Result.Include(r => r.Exam);
            return View(result.ToList());
        }

      

        // GET: Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = _Context.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

      
        public ActionResult Create(int Id)
        {
            var ViewModel = new ResultViewModel
            {
                Exam  = _Context.Exam.SingleOrDefault(m => m.Id == Id),
                Questions = _Context.Question.Include(m=>m.Choices).Where(x=>x.ExamId == Id).ToList()
            };
      
            return View(ViewModel);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResultViewModel ViewModel)
        {

            ViewModel.Exam = _Context.Exam.FirstOrDefault(x => x.Id == ViewModel.DomainModel.ExamId);
            
            ViewModel.DomainModel.Time = DateTime.Now;
            if (ModelState.IsValid)
            {
                _Context.Result.Add(ViewModel.DomainModel);
                _Context.SaveChanges();
                return View("DisplayResults",ViewModel.DomainModel);
            }

            return RedirectToAction("index","home");
        }


        // GET: Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = _Context.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamId = new SelectList(_Context.Exam, "Id", "Name", result.ExamId);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamId,UserId,Score,Time")] Result result)
        {
            if (ModelState.IsValid)
            {
                _Context.Entry(result).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamId = new SelectList(_Context.Exam, "Id", "Name", result.ExamId);
            return View(result);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = _Context.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result result = _Context.Result.Find(id);
            _Context.Result.Remove(result);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
