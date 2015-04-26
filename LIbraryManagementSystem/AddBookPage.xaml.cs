using System;
using System.Data.SqlClient;
using System.Windows;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AddBookPage.xaml
    /// </summary>
    public partial class AddBookPage 
    {
        public AddBookPage()
        {
            InitializeComponent();
            LoadDeptname();
            LoadBookId();
        }

        private void LoadBookId()
        {
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select Upper(b_id) from book");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int sid = int.Parse(reader[0].ToString());
                    BookidnoTextBox.Text=(sid+1).ToString();

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
                    DeptnameComboBox.Items.Add(sname);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void SavebookButton_Click(object sender, RoutedEventArgs e)
        {
              var  book = new Book();

            book.Id = int.Parse(BookidnoTextBox.Text);
            book.Isbno = BookisbnnoTextBox.Text;
            book.Name = BooknameTextBox.Text;
            book.Authorname1 = Authorname1TextBox.Text;
            book.Authorname2 = Authorname2TextBox.Text;
            book.Authorname3 = Authorname3TextBox.Text;
            book.Price = int.Parse(PriceTextBox.Text);
            book.Noofbooks = int.Parse(NumbersofbookTextBox.Text);
            book.Deptname = DeptnameComboBox.Text;
            book.Edition = EditionTextBox.Text;
            book.Publishername = PublisherTextBox.Text;
            book.Shelfno = ShelfnoBox.Text;



            string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf; Integrated Security = True";

            String query = string.Format("insert into book values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",book.Id,book.Isbno,book.Name,book.Authorname1,book.Authorname2,book.Authorname3,book.Price,book.Noofbooks,book.Deptname,book.Publishername,book.Edition,book.Shelfno);

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data is inserted Successfully!!");
                Reset();
                connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

}


        private void Reset()
        {
            BookisbnnoTextBox.Text = "";
            BooknameTextBox.Text = "";
            Authorname1TextBox.Text = "";
            Authorname2TextBox.Text = "";
            Authorname3TextBox.Text = "";
            PriceTextBox.Text = "";
            NumbersofbookTextBox.Text = "";
            DeptnameComboBox.Text = "";
            PublisherTextBox.Text = "";
            EditionTextBox.Text = "";
            ShelfnoBox.Text = "";

        }


        
    }
}
