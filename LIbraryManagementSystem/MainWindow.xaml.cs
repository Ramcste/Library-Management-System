using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
           // Dateexpiry
            //DateExpiry 
            BookexpiryDatePicker.Text = DateTime.Now.Date.AddDays(15).ToString();
            BookissuesDatePicker.Text = DateTime.Now.Date.ToString();
            TodaysDate.Text = DateTime.Now.Date.ToString();
           
            Panel.Children.Clear();
            var page = new AddMemberPage();

            Panel.Children.Add(page);

            LoadDeptName();

            LoadMemberCardno();
           
        }

        private void ControlMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ti = ControlMenu.SelectedItem as TabItem;
            if (ti != null) Title = ti.Header.ToString();
        }

        private void AddbookBoxItem_Selected(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            var page = new AddBookPage();

            Panel.Children.Add(page);

        }

        private void UupdateBookBoxItem_Selected(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            var page = new UpdateBookPage();

            Panel.Children.Add(page);

        }

        private void CalculatefineBoxItem_Selected(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            var page = new CalculateFinePage();

            Panel.Children.Add(page);

        }

        private void AddmemberBoxItem_OnSelected(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            var page = new AddMemberPage();

            Panel.Children.Add(page);

        }

        private void Add_Department_OnSelected(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            var page = new AddDepartmentPage();

            Panel.Children.Add(page);

        }


        private void LoadDeptName()
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


        private void DeptnameComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format( "select  b_id, b_name, b_authorname1, b_authorname2, b_authorname3, b_noofbooks, b_publishername, b_edition, b_shelfno from book where b_deptname='" +
                    DeptnameComboBox.SelectedItem + "'");

            SqlConnection connection = new SqlConnection(ConnectionString);
            
       

            try
            {
                connection.Open();

                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    BookCatalog.DataContext = ds.Tables[0].DefaultView; //DataGrid
                    connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Member_List_OnSelected(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            var page = new MemberListUserControl();

            Panel.Children.Add(page);
        }

        private void LoadMemberCardno()
        {

            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select m_cardno from member");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int sid = int.Parse(reader[0].ToString());
                    Membercardno.Items.Add(sid);
                    MembercardnoComboBox.Items.Add(sid);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }


        }



        private void BookIssuesButton_Click(object sender, RoutedEventArgs e)
        {

            var bookIssues = new BookIssues();

            bookIssues.MemberCardNo = int.Parse(MembercardnoComboBox.Text);
            bookIssues.DeptName = MemberdeptnameBox.Text;
            bookIssues.BookName = BooknameComboBox.Text;
            bookIssues.DateIssues = BookissuesDatePicker.Text;
            bookIssues.DateExpiry = BookexpiryDatePicker.Text;



            int totalbooks = Counttotalbooks() - 1;

            if (CheckMemberCardno()!=bookIssues.MemberCardNo)
            {

                if (totalbooks <= 0)
                {
                    MessageBox.Show("Sorry,U can't have this book because it is confiend copy.");
                }
                else
                {
                    string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

                    string query = string.Format("insert into issuesbook values('{0}','{1}','{2}','{3}','{4}')",
                        bookIssues.MemberCardNo, bookIssues.DeptName, bookIssues.BookName, bookIssues.DateIssues,
                        bookIssues.DateExpiry);

                    string query1 =
                        string.Format("update book set b_noofbooks='" + totalbooks + "' where b_name='" +
                                      BooknameComboBox.Text + "'");

                    string query2 = string.Format("insert into returnbooks values('{0}','{1}','{2}','{3}','{4}')",
                        bookIssues.MemberCardNo, bookIssues.DeptName, bookIssues.BookName, bookIssues.DateIssues,
                        bookIssues.DateExpiry);

                    SqlConnection connection = new SqlConnection(ConnectionString);

                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(query, connection);
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        SqlCommand cmd2 = new SqlCommand(query2, connection);
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Data is inserted Successfully and Book is updated!!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            else
            {
                MessageBox.Show("First, return ur last borrowed book !!");
            }

        }

        private int Counttotalbooks()
        {
            int i = 0;
            var ConnectionString = @"server=Roshani;Database=Librarymanagement.mdf;Integrated Security=true";
            String query = string.Format("select b_noofbooks from book where b_name='" + BooknameComboBox.SelectedItem + "'");
            var connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                var cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i = int.Parse(reader[0].ToString());


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return i;
        }

        private void BookIssuesCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void Membercardno_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String ConnectionString = @"server=Roshani;Database=Librarymanagement.mdf;Integrated Security=true";
            String query = string.Format("select r_deptname,r_bookname,r_dateofissue,r_dateofexpiry  from returnbooks where r_mcardno='"+Membercardno.SelectedItem+"'");
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Member has not taken any book or he has already submitted his books");
                    MemberdeptnameTextBox.Text = "";
                    BooknameTextBox.Text = "";
                    BookissuesPicker.Text = "";
                    BookexpiryPicker.Text = "";
                }
                else
                {
                    while (reader.Read())
                    {
                        string sdeptname = reader[0].ToString();
                        string sbookname = reader[1].ToString();
                        string sdateofissues = reader[2].ToString();
                        string sdateofexpiry = reader[3].ToString();

                        MemberdeptnameTextBox.Text = sdeptname;
                        BooknameTextBox.Text = sbookname;
                        BookissuesPicker.Text = sdateofissues;
                        BookexpiryPicker.Text = sdateofexpiry;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ReturnofbooksButton_Click(object sender, RoutedEventArgs e)
        {
            //int month1 = TodaysDate.DisplayDate.Month;
            //int month2 = BookexpiryPicker.DisplayDate.Month;

            //int day1 =TodaysDate.DisplayDate.Day;
            //int day2 = BookexpiryPicker.DisplayDate.Day;

            //int year1 = TodaysDate.DisplayDate.Year;
            //int year2 = BookexpiryPicker.DisplayDate.Year;

            //int diffdays = day2 - day1;

            //int diffmonths = month2 - month1;

            //int diffyear = year2 - year1;

            //if (diffdays <= 15 && diffmonths == 0 && diffyear == 0)

            DateTime todaysdate = DateTime.Today;

            DateTime expirydate = BookexpiryPicker.DisplayDate;

            TimeSpan span = todaysdate.Subtract(expirydate);
            
            if(span.TotalDays<=15)
            {

                int totalbooks = Counttotalbooks() + 1;

                string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

                string query =  string.Format("update book set b_noofbooks ='" +totalbooks+ "' where b_name ='" +BooknameTextBox.Text+"'");

                string query1= string.Format("delete  from returnbooks where r_mcardno='"+Membercardno.SelectedItem+"'");

                SqlConnection connection = new SqlConnection(ConnectionString);

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlCommand cmd1 = new SqlCommand(query1, connection);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Book is updated and cleared from returning!!");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else
            {
                MessageBox.Show("U are fined ");
            }
        }


        private int CheckMemberCardno()
        {
            int cardno=0;

            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select r_mcardno from returnbooks where r_mcardno='" + Membercardno.SelectedValue + "'");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cardno = int.Parse(reader[0].ToString());

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

            return cardno;
        }

        private void MembercardnoComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select m_deptname from member where m_cardno='" + MembercardnoComboBox.SelectedValue + "'");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sdeptname = reader[0].ToString();
                    MemberdeptnameBox.Text = sdeptname;


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void MemberdeptnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BooknameComboBox.Items.Clear();
            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("select b_name from book where b_deptname='" + MemberdeptnameBox.Text + "'");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    string sbookname = reader[0].ToString();
                    BooknameComboBox.Items.Add(sbookname);


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void DepartmentListBoxItem_OnSelected(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            var page = new DepartmentListUserControl();

            Panel.Children.Add(page);
        }

        private void UpdatememdberBoxItem_OnSelected(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            var page = new UpdateMemberUserControl();

            Panel.Children.Add(page);
        }

        private void ListofAllBooks_OnSelected(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            var page = new BookListUserControl();

            Panel.Children.Add(page);  
        }

        private void BookCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

      
    }
}

    
