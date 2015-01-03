using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    class Database
    {
       public List<Student> students {set;get;}
  
        public void ReadData(string inputId)
        {
            string connectionString = @"Data Source= (LOCAL)\SQLEXPRESS; Database = UniversityAPP; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT T_Student.Id, T_Student.Name,T_Student.Address, T_Student.PhoneNumber,T_Department.Dept_Name FROM T_Student JOIN T_Department ON T_Student.Dept_Id = T_Department.Id";
            if (inputId != "")
            {
                query = "SELECT T_Student.Id, T_Student.Name,T_Student.Address, T_Student.PhoneNumber,T_Department.Dept_Name FROM T_Student JOIN T_Department ON T_Student.Dept_Id = T_Department.Id WHERE T_Student.Id = '"+inputId+"'";
            }
            students = new List<Student>();
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataReader reader = command.ExecuteReader();
       
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = (int) reader["Id"];
                aStudent.Name = reader["Name"].ToString();
                aStudent.Address = reader["Address"].ToString();
                aStudent.Phone = reader["PhoneNumber"].ToString();
                aStudent.Department = reader["Dept_Name"].ToString();
                students.Add(aStudent);
            }
            connection.Close();

        }

       
    }
}
