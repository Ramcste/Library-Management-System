using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AddDepartmentPage.xaml
    /// </summary>
    public partial class AddDepartmentPage 
    {
        public AddDepartmentPage()
        {
            InitializeComponent();

            LoadDeptId();
        }

        private void insertdeptButton_Click(object sender, RoutedEventArgs e)
        {
            Department department=new Department();

            department.Dept_id = int.Parse(DeptidTextBox.Text);
            department.Name = DeptnameTextBox.Text;


            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("insert into dept values('{0}','{1}')", department.Dept_id,department.Name);

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
              //  int n = Convert.ToInt32(cmd.ExecuteScalar());
               // if (n == 1)
               // {
                    MessageBox.Show("Data is inserted Successfully!!");
                    connection.Close();
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void LoadDeptId()
        {

            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";
            
            String query = string.Format("select Upper(d_id) from dept");
           
            SqlConnection connection = new SqlConnection(ConnectionString);
            
            try
           {
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int sid = int.Parse(reader[0].ToString());
                DeptidTextBox.Text = (sid + 1).ToString(CultureInfo.InvariantCulture);

            }
        }
        
            catch(Exception ex)
{
            MessageBox.Show(ex.Message);
}   
        }
            
        }
    }

