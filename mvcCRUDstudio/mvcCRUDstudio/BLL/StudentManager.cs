using mvcCRUDstudio.BOL;
using mvcCRUDstudio.DAL;

namespace mvcCRUDstudio.BLL
{
    public class StudentManager
    {
        public static List<Student> GetStudents()
        {
            List<Student> allStudents = new List<Student>();
            allStudents = DBManager.GetStudents();
            return allStudents;
        }

        public static Student GetStudent(int id)
        {
            Student newStudent = DBManager.GetStudent(id);
            return newStudent;
        }

        public static bool Delete(int id)
        {
            return DBManager.Delete(id);
        }

        public static bool Insert(Student newStudent)
        {
            return DBManager.Insert(newStudent);
        }

        public static bool Update(Student student)
        {
            return DBManager.Update(student);
        }
    }
}