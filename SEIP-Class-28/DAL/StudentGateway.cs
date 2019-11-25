using SEIP_Class_28.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SEIP_Class_28.DAL
{
    public class StudentGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["StudentInfoDB"].ConnectionString;

        public List<Student> Get()
        {
            string query = "SELECT * from Students";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Student> studentList = new List<Student>();

            while (reader.Read())
            {
                //Student aStudent = new Student();
                //aStudent.Id = Convert.ToInt32(reader["Id"]);
                //aStudent.Name = reader["Name"].ToString();
                //aStudent.Address = reader["Address"].ToString();
                //aStudent.Contact = reader["Contact"].ToString();

                //studentList.Add(aStudent);

                studentList.Add(new Student()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Address"].ToString(),
                    Contact = reader["Contact"].ToString()
                });
            }

            reader.Close();
            connection.Close();

            return studentList;
        }

        public Student Find(int? id)
        {
            string query = "SELECT * from Students WHERE Id='" + id + "'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Student existStudent = null;

            while (reader.Read())
            {
                existStudent = new Student();
                existStudent.Id = Convert.ToInt32(reader["Id"]);
                existStudent.Name = reader["Name"].ToString();
                existStudent.Address = reader["Address"].ToString();
                existStudent.Contact = reader["Contact"].ToString();
            }

            reader.Close();
            connection.Close();

            return existStudent;
        }

        public int Add(Student student)
        {
            string query = "INSERT INTO Students Values(@Name, @Address, @Contact)";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("Name", SqlDbType.NVarChar);
            command.Parameters["Name"].Value = student.Name;

            command.Parameters.Add("Address", SqlDbType.NVarChar);
            command.Parameters["Name"].Value = student.Address;

            command.Parameters.Add("Contact", SqlDbType.NVarChar);
            command.Parameters["Name"].Value = student.Contact;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool Update(Student student)
        {
            string query = "UPDATE Students SET Name='" + student.Name + "', Address='" + student.Address + "', Contact='" + student.Contact + "' WHERE Id='" + student.Id + "'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Student student)
        {
            string query = "DELETE FROM Students WHERE Id='" + student.Id + "'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}