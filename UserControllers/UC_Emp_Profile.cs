using JobLinK2.ClassLayer;
using JobLinK2.ControllerLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobLinK2
{
    public partial class UC_Emp_Profile : UserControl
    {
        CityController cityController;
        List<City> cityList = new List<City>();
        EmpProfileController empProfileControl;
        EmpProfile empProfile;
        CityController cityControl;
        OpenFileDialog openFileDialog1;

        public int userID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birthday { get; set; }
        public string country { get; set; }
        public int cityID { get; set; }
        public string email { get; set; }
        public string descript { get; set; }
        public string profile { get; set; }

        public UC_Emp_Profile()
        {
            InitializeComponent();
            cityController = new CityController();
            empProfileControl = new EmpProfileController();
            cityControl = new CityController();
            openFileDialog1 = new OpenFileDialog();
        }

        private void UC_Emp_Profile_Load(object sender, EventArgs e)
        {
            empProfile = empProfileControl.getByUserID(WhoIsLogin.userID);

            cityList = cityController.readAll();
            siticoneTextBox4.Enabled = false;
            foreach (City city in cityList)
            {
                siticoneComboBox7.Items.Add(city.name);
            }

            siticoneTextBox1.Text = empProfile.name;
            siticoneTextBox2.Text = empProfile.surname;
            siticoneTextBox4.Text = empProfile.country;
            siticoneComboBox7.Text = cityControl.readById(empProfile.cityID).name;
            siticoneTextBox5.Text = empProfile.email;
            siticoneTextBox3.Text = empProfile.descript;
            siticoneTextBox6.Text = empProfile.birthday;
            


        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            userID = WhoIsLogin.userID;
            name = siticoneTextBox1.Text;
            surname = siticoneTextBox2.Text;
            descript = siticoneTextBox3.Text;
            country = siticoneTextBox4.Text;
            email = siticoneTextBox5.Text;
            cityID = cityControl.getId(siticoneComboBox7.Text);
            birthday = siticoneTextBox6.Text;


            empProfileControl.update(new EmpProfile(userID, name, surname, birthday, country, cityID, email, descript, "" ));
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            siticonePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            siticonePictureBox1.ImageLocation = openFileDialog1.FileName;
        }
    }
}
