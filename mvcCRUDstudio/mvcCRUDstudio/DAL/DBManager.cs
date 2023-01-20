﻿using mvcCRUDstudio.BOL;
using MySql.Data.MySqlClient;
using System.Data;

namespace mvcCRUDstudio.DAL
{
    public static class DBManager
    {
        public static string conString = @"server=localhost;port=3306;user=root;password=welcome@123;database=osho";

        public static List<Student> GetStudents()
        {
            List<Student> allStudents = new List<Student>();
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                con.Open();
                string query = "SELECT * FROM student";
                MySqlCommand cmd = new MySqlCommand(query, con);
                //cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int sid = int.Parse(reader["sid"].ToString());
                    string sname = reader["sname"].ToString();
                    string course = reader["course"].ToString();

                    Student student = new Student
                    {
                        Sid = sid,
                        Sname = sname,
                        Course = course
                    };
                    allStudents.Add(student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return allStudents;
        }

        public static Student GetStudent(int id)
        {
            Student newStudent = null;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                string query = "SELECT * FROM student WHERE sid=" + id;
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = mySqlCommand;
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                DataRowCollection rows = dt.Rows;
                foreach (DataRow row in rows)
                {
                    newStudent = new Student();
                    newStudent.Sid = int.Parse(row["sid"].ToString());
                    newStudent.Sname = row["sname"].ToString();
                    newStudent.Course = row["course"].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return newStudent;
        }

        public static bool Delete(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "DELETE FROM student WHERE sid=" + id;
                MySqlCommand command = new MySqlCommand(query, con);
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public static bool Insert(Student newStudent)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "Insert into student (sname,course) Values('" + newStudent.Sname + "','" + newStudent.Course + "')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return status;

        }

        public static bool Update(Student student)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "UPDATE student SET sname='" + student.Sname + "', course='" + student.Course + "' WHERE sid=" + student.Sid;
                MySqlCommand command = new MySqlCommand(query, con);
                con.Open();
                command.ExecuteNonQuery();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }

    }
}
