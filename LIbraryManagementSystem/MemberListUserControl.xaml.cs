using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for MemberListUserControl.xaml
    /// </summary>
    public partial class MemberListUserControl : UserControl
    {
        public MemberListUserControl()
        {
            InitializeComponent();
            loadMemberList();
        }

        private void loadMemberList()
        {

            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select * from member");
            SqlConnection connection = new SqlConnection(ConnectionString);
            DataSet ds = new DataSet();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                MemberDataGrid.DataContext = ds.Tables[0].DefaultView; //DataGrid
                connection.Close();




            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
