
using Password_Manager_Desktop_Client.crypto;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class LogInPage : UserControl
{
    private IWebClient _client;
    private string _username;
    private string _password;
    private IVaultCrypto _vaultCryptoHelper;

    public LogInPage(IWebClient client, IVaultCrypto vaultCryptoHelper)
    {
        _client = client;
        _vaultCryptoHelper = vaultCryptoHelper;
        _username = "";
        _password = "";
        InitializeComponent();
    }

    private void LogInPage_Load(object sender, EventArgs e)
    {
        
    }

    private void UsernameText_Changed(object sender, EventArgs e)
    {
        usernameTextBox.Text = _username;
    }

    private void PasswordText_Changed(object sender, EventArgs e)
    {
        passwordTextBox.Text = _password;
    }

    private async void LogInButton_Clicked(object sender, EventArgs e)
    {
        var _userDTO = createUserDTO(_username, _password);
        var userId = await _client.LoginAsync(_userDTO);

        if(userId.HasValue)
        {
            //TODO display wrong credentials error
        }
        else
        {
            //Load vault page
            CreateVaultPage createVaultPage = new CreateVaultPage(_client, _vaultCryptoHelper, userId.Value, _username, _password);
            createVaultPage.Dock = DockStyle.Fill;
        }

    }

    private UserDto createUserDTO(string username ,string password)
    {
        return new UserDto() { Username = username, Password = password};
    }
}
