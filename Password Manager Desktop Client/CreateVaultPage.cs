using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Web_Client;

namespace Password_Manager_Desktop_Client;

public partial class CreateVaultPage : UserControl
{
    private IWebClient _client;
    public CreateVaultPage(IWebClient client)
    {
        _client = client;
        InitializeComponent();
    }

    private void CreateVaultPage_Load(object sender, EventArgs e)
    {

    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
