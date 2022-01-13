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
    public partial class frmEmpScreen : Form
    {
        public frmEmpScreen()
        {
            InitializeComponent();
        }

        private void siticoneButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneButton1.Checked) { uC_Emp_Home1.BringToFront(); }

        }

        private void siticoneButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneButton2.Checked) { uC_Emp_Profile1.BringToFront(); }
        }

        private void siticoneButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneButton3.Checked) { uC_Emp_FindJob1.BringToFront(); }
        }

        private void siticoneButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneButton4.Checked) { uC_Emp_CV1.BringToFront(); }
        }

        private void siticoneButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneButton5.Checked) { uC_Emp_App1.BringToFront(); }
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {

        }

        private void uC_Emp_Profile1_Load(object sender, EventArgs e)
        {
            
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneControlBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
