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
    internal class EmpProfileController
    {

        public SqlConnection conn { get; set; }
        public SqlCommand sqlCommand { get; set; }
        public SqlDataAdapter dataAdapter { get; set; }
        public DataTable dataTable { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birthday { get; set; }
        public string country { get; set; }
        public int cityID { get; set; }
        public string email { get; set; }
        public string descript { get; set; }
        public string profile { get; set; }


        public EmpProfileController()
        {
            conn = new SqlConnection("Data Source=DESKTOP-38A6LF0;Initial Catalog=JobLinKDB;Integrated Security=True");
            sqlCommand = new SqlCommand();
            dataTable = new DataTable();
        }

        public void add(EmpProfile empProfile)
        {
            try
            {
                conn.Open();
                sqlCommand = new SqlCommand("insert into EmpProfiles values(@UserID, @name, @surname, @birthday, @country, @cityid, @email, @desc, @profile)", conn);
                sqlCommand.Parameters.AddWithValue("@UserID", empProfile.userID);
                sqlCommand.Parameters.AddWithValue("@name", empProfile.name);
                sqlCommand.Parameters.AddWithValue("@surname", empProfile.surname);
                sqlCommand.Parameters.AddWithValue("@birthday", empProfile.birthday);
                sqlCommand.Parameters.AddWithValue("@country", empProfile.country);
                sqlCommand.Parameters.AddWithValue("@cityid", empProfile.cityID);
                sqlCommand.Parameters.AddWithValue("@email", empProfile.email);
                sqlCommand.Parameters.AddWithValue("@desc", empProfile.descript);
                sqlCommand.Parameters.AddWithValue("@profile", empProfile.profile);
                sqlCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public EmpProfile getByUserID(int userID)
        {
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter("select * from EmpProfiles where UserID = '" + userID + "'", conn);
                dataAdapter.Fill(dataTable);
                userID = Convert.ToInt32(dataTable.Rows[0][1]);
                name = Convert.ToString(dataTable.Rows[0][2]);
                surname = Convert.ToString(dataTable.Rows[0][3]);
                birthday = Convert.ToString(dataTable.Rows[0][4]);
                country = Convert.ToString(dataTable.Rows[0][5]);
                cityID = Convert.ToInt32(dataTable.Rows[0][6]);
                email = Convert.ToString(dataTable.Rows[0][7]);
                descript = Convert.ToString(dataTable.Rows[0][8]);
                profile = Convert.ToString(dataTable.Rows[0][9]);
                conn.Close();
                return new EmpProfile(userID, name, surname, birthday, country, cityID, email, descript, profile);     
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return null;
        }

        public void update(EmpProfile empProfile)
        {
            try
            {
                conn.Open();
                sqlCommand = new SqlCommand("update EmpProfiles set Name = @name, Surname = @surname, Birthdate = @birthdate, CityID = @cityid, Email = @email, Descript = @desc, Profile = @profile    Where userID = @userid", conn);
                sqlCommand.Parameters.AddWithValue("@name", empProfile.name);
                sqlCommand.Parameters.AddWithValue("@surname", empProfile.surname);
                sqlCommand.Parameters.AddWithValue("@birthdate", empProfile.birthday);
                sqlCommand.Parameters.AddWithValue("@cityid", empProfile.cityID);
                sqlCommand.Parameters.AddWithValue("@email", empProfile.email);
                sqlCommand.Parameters.AddWithValue("@desc", empProfile.descript);
                sqlCommand.Parameters.AddWithValue("@profile", empProfile.profile);
                sqlCommand.Parameters.AddWithValue("@userid", empProfile.userID);
                sqlCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
