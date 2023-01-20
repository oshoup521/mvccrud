using Microsoft.AspNetCore.Mvc;
using mvcCRUDstudio.BOL;
using mvcCRUDstudio.BLL;

namespace mvcCRUDstudio.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            students = StudentManager.GetStudents();
            ViewData["students"] = students;
            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student newStudent)
        {
            try
            {
                StudentManager.Insert(newStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit()
        {
            
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student updateStudent) 
        {
            try
            {
                ViewBag.student = updateStudent;
                StudentManager.Update(updateStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData["id"] = id;
            StudentManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}