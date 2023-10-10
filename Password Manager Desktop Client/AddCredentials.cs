using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager_Desktop_Client
{
    public partial class AddCredentials : UserControl
    {
        private string _username;
        private string _password;
        private string _cr_sitename;
        private string _cr_username;
        private string _cr_password;

        public AddCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            InitializeComponent();
        }

        private void siteName_TextChanged(object sender, EventArgs e)
        {

        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {

        }
    }
}
