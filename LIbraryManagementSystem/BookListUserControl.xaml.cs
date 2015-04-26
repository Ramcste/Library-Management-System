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
    /// Interaction logic for BookListUserControl.xaml
    /// </summary>
    public partial class BookListUserControl : UserControl
    {
        public BookListUserControl()
        {
            InitializeComponent();

            LoadAllBooks();
        }

        private void LoadAllBooks()
        
        {
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select  b_id, b_name, b_authorname1, b_authorname2, b_authorname3, b_noofbooks, b_deptname, b_publishername, b_edition, b_shelfno from book");

            SqlConnection connection = new SqlConnection(ConnectionString);



            try
            {
                connection.Open();

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                BookList.DataContext = ds.Tables[0].DefaultView; //DataGrid
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
