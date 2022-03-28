using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management.Forms
{
    public partial class frm_UserLogin : Form
    {
        public frm_UserLogin()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_UserRegister frm = new frm_UserRegister();
            frm.Show();
        }
    }
}
