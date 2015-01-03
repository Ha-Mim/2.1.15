using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    public partial class UniversityUI : Form
    {
        Database aDatabase = new Database();
        public UniversityUI()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Database aDatabase = new Database();
            showListView.Items.Clear();
            aDatabase.ReadData(idSearchTextBox.Text);
            
            foreach (Student aStudent in aDatabase.students)
            {
                ListViewItem myView = new ListViewItem();
                myView.Text = (aStudent.Id.ToString());
                myView.SubItems.Add(aStudent.Name);
                myView.SubItems.Add(aStudent.Address);
                myView.SubItems.Add(aStudent.Phone);
                myView.SubItems.Add(aStudent.Department);

                showListView.Items.Add(myView);
            }
            
        }

        private void searchDeptButton_Click(object sender, EventArgs e)
        {
            Department selectedDepartment = (Department)deptComboBox.SelectedItem;
            string connectionString = @"Data Source= (LOCAL)\SQLEXPRESS; Database = UniversityAPP; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string 
                query = "SELECT T_Student.Id, T_Student.Name,T_Student.Address, T_Student.PhoneNumber,T_Department.Dept_Name FROM T_Student JOIN T_Department ON T_Student.Dept_Id = T_Department.Id WHERE T_Student.Dept_Id = '" + selectedDepartment.Id + "'";
            
            List <Student>students = new List<Student>();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = (int)reader["Id"];
                aStudent.Name = reader["Name"].ToString();
                aStudent.Address = reader["Address"].ToString();
                aStudent.Phone = reader["PhoneNumber"].ToString();
                aStudent.Department = reader["Dept_Name"].ToString();
                students.Add(aStudent);
                ListViewItem myView = new ListViewItem();
                myView.Text = (aStudent.Id.ToString());
                myView.SubItems.Add(aStudent.Name);
                myView.SubItems.Add(aStudent.Address);
                myView.SubItems.Add(aStudent.Phone);
                myView.SubItems.Add(aStudent.Department);

                showListView.Items.Add(myView);
            }
            connection.Close();

        }

        private void UniversityUI_Load(object sender, EventArgs e)
        {
            List<Department> departmentList = new List<Department>();
            string connectionString = @"Data Source= (LOCAL)\SQLEXPRESS; Database = UniversityAPP; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM T_Department";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = (int)reader["Id"];
                aDepartment.Name = reader["Dept_Name"].ToString();
                departmentList.Add(aDepartment);

            }
            reader.Close();
            connection.Close();
            foreach (Department Department1 in departmentList)
            {
                deptComboBox.Items.Add(Department1);
            }
            deptComboBox.DisplayMember = "Name";
            deptComboBox.ValueMember = "Id";
        }

            
            
        }
    }


  