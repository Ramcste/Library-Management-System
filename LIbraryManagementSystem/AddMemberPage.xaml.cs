using System;
using System.Data.SqlClient;
using System.Windows;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AddMemberPage.xaml
    /// </summary>
    public partial class AddMemberPage
    {
        public AddMemberPage()
        {

            InitializeComponent();
            Loadinfo();

            Dateexpiry.Text=DateTime.Now.Date.AddYears(1).ToString();
            loadCardno();
        }

        private void loadCardno()
        {

            string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True"; 

            String query = string.Format("select Upper(m_cardno)  from member");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int sid = int.Parse(reader[0].ToString());
                    MemberidnoTextBox.Text = (sid + 1).ToString();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavememberButton_Click(object sender, RoutedEventArgs e)
        {
            Member member=new Member();

            member.Id = int.Parse(MemberidnoTextBox.Text);
            member.Name = MembernameTextBox.Text;
            member.Address = MemberaddressTextBox.Text;
            member.MobileNo = MemberphonenumberTextBox.Text;
            member.Department = DeptnameComboBox.Text;
            member.Rollno =RollnoTextBox.Text;
            member.DateExpiry = Dateexpiry.Text;
            member.Session = SessionTextBox.Text;

            string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True"; 

            String query= string.Format("insert into member values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",member.Id,member.Name,member.Address,member.MobileNo,member.Department,member.Rollno,member.DateExpiry,member.Session);
             
            SqlConnection connection=new SqlConnection(ConnectionString);
   
            try
            {
               connection.Open();
               SqlCommand cmd=new SqlCommand(query,connection);
               cmd.ExecuteNonQuery();
               MessageBox.Show("Data is inserted Successfully!!");
             connection.Close();
                ClearBoxes();
            }
               catch(Exception ex)
              {

                MessageBox.Show(ex.Message);
              
               }
         }

        private void ClearBoxes()
        {
            MembernameTextBox.Text = "";
            MemberaddressTextBox.Text = "";
            MemberphonenumberTextBox.Text ="";
            DeptnameComboBox.Text = "";
            RollnoTextBox.Text = "";
            Dateexpiry.Text = "";
            SessionTextBox.Text = "";
        }



        private void Loadinfo()
        {
            string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True"; 

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

                }
}