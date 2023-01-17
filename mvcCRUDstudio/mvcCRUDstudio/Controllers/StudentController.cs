using Microsoft.AspNetCore.Mvc;
using mvcCRUDstudio.Models;

namespace mvcCRUDstudio.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            students = DBManager.GetStudents();
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
                DBManager.Insert(newStudent);
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
                DBManager.Update(updateStudent);
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
            DBManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cors;
//using mvcCRUDstudio.Models;
//using mvcCRUDstudio;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace TestADOnet.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        // GET: api/<ValuesController>
//        [HttpGet]
//        [EnableCors]
//        public IEnumerable<Student> Get()
//        {
//            List<Student> students = new List<Student>();
//            students = DBManager.GetStudents();
//            return students;
//        }

//        // get api/<valuescontroller>/5
//        [HttpGet("{id}")]
//        [EnableCors]
//        public Student get(int id)
//        {
//            Student student = new Student();
//            student = DBManager.GetStudent(id);
//            return student;
//        }

//        // post api/<valuescontroller>
//        [HttpPost]
//        public void post(Student newStudent)
//        {
//            DBManager.Insert(newStudent);
//        }

//        // put api/<valuescontroller>/5
//        [HttpPut("{id}")]
//        public void put(Student student)
//        {
//            DBManager.Update(student);
//        }

//        // delete api/<valuescontroller>/5
//        [HttpDelete("{id}")]
//        [EnableCors]
//        public void delete(int id)
//        {
//            DBManager.Delete(id);
//        }
//    }
//}

