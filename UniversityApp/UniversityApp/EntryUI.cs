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
    public partial class EntryUI : Form
    {
        public EntryUI()
        {
            InitializeComponent();
        }
        Database aDatabase=new Database();
        private void EntryUI_Load(object sender, EventArgs e)
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string phone = phoneTextBox.Text;
            Department selectedDepartment = (Department) deptComboBox.SelectedItem;
           
            string connectionString = @"Data Source= (LOCAL)\SQLEXPRESS; Database = UniversityAPP; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO T_STUDENT VALUES('" + name + "','" + address + "','" + phone + "','" +selectedDepartment.Id + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                MessageBox.Show("Successfully Saved!");
            }
            else
            {
                MessageBox.Show("Couldn't Save the data ", " Error");
            }
        }
    }
}
