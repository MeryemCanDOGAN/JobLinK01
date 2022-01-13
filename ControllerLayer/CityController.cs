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
    internal class CityController
    {
        public SqlConnection conn { get; set; }
        public SqlCommand sqlCommand { get; set; }
        public SqlDataAdapter dataAdapter { get; set; }
        public DataTable dataTable { get; set; }
        public string name { get; set; }
        public List<City> cityList { get; set; }


        public CityController()
        {
            conn = new SqlConnection("Data Source=DESKTOP-38A6LF0;Initial Catalog=JobLinKDB;Integrated Security=True");
            sqlCommand = new SqlCommand();
            dataTable = new DataTable();
            cityList = new List<City>();
        }

        public List<City> readAll()
        {
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter("select * from Cities", conn);
                dataAdapter.Fill(dataTable);
                for (int i=0; i<dataTable.Rows.Count; i++)
                {
                    cityList.Add(new City(Convert.ToString(dataTable.Rows[i][1])));
                }
                conn.Close();
                return cityList;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public City readById(int id)
        {
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter("select Name from Cities where ID = '" + id + "'", conn);
                dataAdapter.Fill(dataTable);
                conn.Close();
                return new City(Convert.ToString(dataTable.Rows[0][0]));
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public int getId(string name)
        {
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter("select * from Cities where Name = '" + name + "'", conn);
                dataAdapter.Fill(dataTable);
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            return Convert.ToInt32(dataTable.Rows[1][1]);
        }

    }
}
