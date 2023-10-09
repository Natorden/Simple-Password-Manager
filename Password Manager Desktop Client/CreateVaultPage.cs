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
    private Guid _userId;
    
    public CreateVaultPage(IWebClient client, Guid userId)
    {
        _client = client;
        _userId = userId;
        InitializeComponent();
    }

    private void CreateVaultPage_Load(object sender, EventArgs e)
    {
        var encryptedVault = _client.GetAsync(_userId);
    }

    private void AddNewPassword_Click(object sender, EventArgs e)
    {

    }

    private void LogOut_Button_Click(object sender, EventArgs e)
    {

    }
}
