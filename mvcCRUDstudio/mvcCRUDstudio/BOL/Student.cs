namespace mvcCRUDstudio.BOL
{
    public class Student
    {

        public int Sid { get; set; }
        public string? Sname { get; set; }
        public string? Course { get; set; }

        public Student() { }

        public Student(int id)
        {
            Sid = id;
        }



    }
}
