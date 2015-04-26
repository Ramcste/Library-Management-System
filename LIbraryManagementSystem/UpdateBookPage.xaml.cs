using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for UpdateBookPage.xaml
    /// </summary>
    public partial class UpdateBookPage 
    {
        public UpdateBookPage()
        {
            InitializeComponent();
            LoadBookId();
            LoadDeptname();
        }

        private void LoadBookId()
        {
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select b_id from book");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int sid = int.Parse(reader[0].ToString());
                    BookidnoComboBox.Items.Add(sid);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }


        private void LoadDeptname()
        {
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select d_name from dept");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sname = reader[0].ToString();
                    DeptnameBox.Items.Add(sname);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookidnoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf; Integrated Security = True";

            String query = string.Format("select b_isbnno, b_name, b_authorname1,b_authorname2, b_authorname3, b_price, b_noofbooks, b_deptname, b_publishername, b_edition, b_shelfno from book where b_id='"+BookidnoComboBox.SelectedValue+"'");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sisbno = reader[0].ToString();
                    string sname = reader[1].ToString();
                    string sauthorname1 = reader[2].ToString();
                    string sauthorname2 = reader[3].ToString();
                    string sauthorname3 = reader[4].ToString();
                    int sprice = int.Parse(reader[5].ToString());
                    int snoofbooks = int.Parse(reader[6].ToString());
                    string sdeptname = reader[7].ToString();
                    string spublishername = reader[8].ToString();
                    string sedition = reader[9].ToString();
                    string sshelfno = reader[10].ToString();

                    BookisbnnoBox.Text = sisbno;
                    BooknameBox.Text = sname;
                    Authorname1Box.Text = sauthorname1;
                    Authorname2Box.Text = sauthorname2;
                    Authorname3Box.Text = sauthorname3;
                    PriceBox.Text = sprice.ToString(CultureInfo.InvariantCulture);
                    NumbersofbookBox.Text = snoofbooks.ToString(CultureInfo.InvariantCulture);
                    DeptnameBox.Text = sdeptname;
                    PublisherBox.Text = spublishername;
                    EditionBox.Text = sedition;
                    ShelfnoBox.Text = sshelfno;

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   


        }

      

        private void UpdateBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("update  book  set  b_isbnno='"+BookisbnnoBox.Text+"', b_name='"+BooknameBox.Text+"', b_authorname1='"+Authorname1Box.Text+"', b_authorname2='"+Authorname2Box.Text+"', b_authorname3='"+Authorname3Box.Text+"', b_price='"+PriceBox.Text+"', b_noofbooks='"+NumbersofbookBox.Text+"', b_deptname='"+DeptnameBox.Text+"', b_publishername='"+PublisherBox.Text+"', b_edition='"+EditionBox.Text+"', b_shelfno='"+ShelfnoBox.Text+"' where b_id='"+BookidnoComboBox.SelectedValue + "'");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Ur data is updated");
                connection.Close();
                Reset();
            }
            

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          
        }

        private void Reset()
        {
            BookisbnnoBox.Text = "";
            BooknameBox.Text = "";
            Authorname1Box.Text = "";
            Authorname2Box.Text = "";
            Authorname3Box.Text = "";
            PriceBox.Text = "";
            NumbersofbookBox.Text = "";
            DeptnameBox.Text = "";
            PublisherBox.Text = "";
            EditionBox.Text = "";
            ShelfnoBox.Text = "";

        }
    }
}
