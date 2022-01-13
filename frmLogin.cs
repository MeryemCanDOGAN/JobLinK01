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
    public partial class frmLogin : Form
    {
        UserController userControl;

        public string email { get; set; }
        public string password { get; set; }
        public string userType { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            userControl = new UserController();
        }

        private void siticoneHtmlLabel7_Click(object sender, EventArgs e)
        {
            new frmSignup().Show();
            this.Hide();
           
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            siticoneTextBox1.Text = "";
            siticoneTextBox2.Text = "";
            siticoneCheckBox1.Checked = false;
            siticoneTextBox1.Focus();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (siticoneTextBox1.Text == "" || siticoneTextBox2.Text == "")
            {
                MessageBox.Show("Lütfen Eksik Alanları Doldurun.");
            }
            else
            {
                User user = userControl.read(siticoneTextBox1.Text);
                if (user.email != "")
                {
                    WhoIsLogin.userID = userControl.getID(user);
                    if(user.userType == "İş Arayan")
                    {
                        new frmEmpScreen().Show();
                        this.Hide();
                    }
                    else
                    {
                        new frmCompScreen().Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Bulunamadı...");
                }
            }
        }
    }
}
