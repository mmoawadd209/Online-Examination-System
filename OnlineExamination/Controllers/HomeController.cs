
using OnlineExamination.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace OnlineExamination.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public HomeController()
        {
            _Context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View("Admin");

            }

            var Exams = _Context.Exam.Include(m => m.Questions).ToList();

            return View(Exams);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}