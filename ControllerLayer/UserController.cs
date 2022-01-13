using JobLinK2.ClassLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobLinK2.ControllerLayer
{
    internal class UserController
    {
        public SqlConnection conn { get; set; }
        public SqlCommand sqlCommand { get; set; }
        public SqlDataAdapter dataAdapter { get; set; }
        public DataTable dataTable { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userType { get; set; }

        public UserController()
        {
            conn = new SqlConnection("Data Source=DESKTOP-38A6LF0;Initial Catalog=JobLinKDB;Integrated Security=True");
            sqlCommand = new SqlCommand();
            dataTable = new DataTable();
        }
        public void add(User user)
        {
            try
            {
                conn.Open();
                sqlCommand = new SqlCommand("insert into Users values(@Email, @Password, @UserType)", conn);
                sqlCommand.Parameters.AddWithValue("@Email", user.email);
                sqlCommand.Parameters.AddWithValue("@Password", user.password);
                sqlCommand.Parameters.AddWithValue("@UserType", user.userType);
                sqlCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public User read(string email)
        {
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter("select * from Users where Email = '" + email + "'", conn);
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count == 0)
                {
                    conn.Close();
                    return new User(email = "", password = "", userType = "");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            email = Convert.ToString(dataTable.Rows[0][1]);
            password = Convert.ToString(dataTable.Rows[0][2]);
            userType = Convert.ToString(dataTable.Rows[0][3]);
            
            return new User(email, password, userType);
        }

        public int getID(User user)
        {
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter("select ID from Users where Email = '" + user.email + "'", conn);
                dataAdapter.Fill(dataTable);
                conn.Close();
                return Convert.ToInt32(dataTable.Rows[0][0]);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
    }
}
