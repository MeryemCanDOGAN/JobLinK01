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
    public partial class frmSignup : Form
    {

        public string email { get; set; }
        public string password { get; set; }
        public string userType { get; set; }

        UserController userControl;
        EmpProfileController empProfileControl;


        public frmSignup()
        {
            InitializeComponent();
            userControl = new UserController();
            empProfileControl = new EmpProfileController();
        }

        private void siticoneHtmlLabel7_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            siticoneTextBox1.Text = "";
            siticoneTextBox2.Text = "";
            siticoneTextBox3.Text = "";
            siticoneComboBox1.Text = "";
            siticoneCheckBox1.Checked = false;
            siticoneTextBox1.Focus();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if(siticoneTextBox1.Text == "" || siticoneTextBox2.Text == "" || siticoneTextBox3.Text == "" || siticoneComboBox1.Text == "")
            {
                MessageBox.Show("Lütfen Eksik Alanları Doldurun.");
            }
            else
            {
                if(siticoneTextBox2.Text != siticoneTextBox3.Text)
                {
                    MessageBox.Show("Girdiğiniz şifreler uyumsuz.");
                }
                else
                {
                    if (userControl.read(siticoneTextBox1.Text).email != "")
                    {
                        siticoneTextBox1.Text = "";
                        siticoneTextBox2.Text = "";
                        siticoneTextBox3.Text = "";
                        siticoneComboBox1.Text = "";
                        siticoneCheckBox1.Checked = false;
                        siticoneTextBox1.Focus();
                        MessageBox.Show("Bu mail adresi zaten kayıtlı..");
                    }
                    else
                    {
                        email = siticoneTextBox1.Text;
                        password = siticoneTextBox2.Text;
                        userType = siticoneComboBox1.Text;

                        User user = new User(email, password, userType);
                        userControl.add(user);
                        WhoIsLogin.userID = userControl.getID(user);
                        if (userType == "İş Arayan")
                        {
                            empProfileControl.add(new EmpProfile(userControl.getID(user), "", "", DateTime.Now.ToString("MM/dd/yyyy"), "Türkiye", 1, "", "", ""));
                            new frmEmpScreen().Show();
                            this.Hide();
                        }
                        else
                        {
                            new frmCompScreen().Show();
                            this.Hide();
                        }
                    }
                    
                }
            }
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {
            siticoneComboBox1.Items.Add("İş Arayan");
            siticoneComboBox1.Items.Add("İş Veren");
        }
    }
}
