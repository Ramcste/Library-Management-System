using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace LIbraryManagementSystem
{
    /// <summary>
    /// Interaction logic for UpdateMemberUserControl.xaml
    /// </summary>
    public partial class UpdateMemberUserControl
    {
        public UpdateMemberUserControl()
        {
            InitializeComponent();
            loadCardno();
            loadDeptname();
        }

        private void loadDeptname()
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

        private void loadCardno()
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
                    string sname = reader[0].ToString();
                    MembercarddnoComboBox.Items.Add(sname);


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void MembercarddnoComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf; Integrated Security = True";

              String query = string.Format("select m_name, m_address, m_mobileno, m_deptname, m_rollno, m_dateofexpiry, m_session from member where m_cardno='" + MembercarddnoComboBox.SelectedValue + "'");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                   SqlCommand cmd = new SqlCommand(query, connection);

                  SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sname = reader[0].ToString();
                    string saddress = reader[1].ToString();
                    string smobileno = reader[2].ToString();
                    string sdeptname = reader[3].ToString();
                    string srollno = reader[4].ToString();
                    string sdateofexpiry = reader[5].ToString();
                    string ssession = reader[6].ToString();

                    MembernameTextBox.Text = sname;
                    MemberaddressTextBox.Text = saddress;
                    MemberphonenumberTextBox.Text = smobileno;
                    DeptnameComboBox.Text = sdeptname;
                    RollnoTextBox.Text = srollno;
                    Dateexpiry.Text = sdateofexpiry;
                    SessionTextBox.Text = ssession;
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdatememberButton_OnClick(object sender, RoutedEventArgs e)
        {

            String ConnectionString = @"Server=Roshani;Database=LibraryManagement.mdf;Integrated Security=True";

            String query = string.Format("update  member  set  m_name='" +MembernameTextBox.Text + "', m_address='" + MemberaddressTextBox.Text + "', m_mobileno='" +MemberphonenumberTextBox.Text + "', m_deptname='" + DeptnameComboBox.SelectedValue + "',  m_rollno='" + RollnoTextBox.Text + "', m_dateofexpiry='" + Dateexpiry.Text + "', m_session='"+SessionTextBox.Text+"' where m_cardno='" + MembercarddnoComboBox.SelectedValue + "'");

            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Ur data is updated");
                connection.Close();
                ClearBoxes();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          

        }

        private void ClearBoxes()
        {
            MembernameTextBox.Text = "";
            MemberaddressTextBox.Text = "";
            MemberphonenumberTextBox.Text = "";
            DeptnameComboBox.Text = "";
            RollnoTextBox.Text = "";
            Dateexpiry.Text = "";
            SessionTextBox.Text = "";
        }

    }
}
