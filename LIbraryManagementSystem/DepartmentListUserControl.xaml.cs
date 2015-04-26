using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for DepartmentListUserControl.xaml
    /// </summary>
    public partial class DepartmentListUserControl 
    {
        public DepartmentListUserControl()
        {
            InitializeComponent();
            LoadDepartmentList();
        }

        private void LoadDepartmentList()
        {
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";
            String query = string.Format("select d_id, d_name from dept");
            SqlConnection connection = new SqlConnection(ConnectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                DepartementDataGrid.DataContext = ds.Tables[0].DefaultView;  // ListView
                
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
