
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class LogInPage : UserControl
{
    private IWebClient _client;
    private static string _email;
    private static string _password;

    public LogInPage(IWebClient client)
    {
        _client = client;
        InitializeComponent();
    }

    private void LogInPage_Load(object sender, EventArgs e)
    {
        
    }

    private void UsernameText_Changed(object sender, EventArgs e)
    {
        usernameTextBox.Text = _email;
    }

    private void PasswordText_Changed(object sender, EventArgs e)
    {
        passwordTextBox.Text = _password;
    }

    private async void LogInButton_Clicked(object sender, EventArgs e)
    {
        var _userDTO = createUserDTO(_email, _password);
        var authentificate = await _client.LoginAsync(_userDTO);

        if(authentificate == null)
        {
            //TODO display wrong credentials error
        }
        else
        {
            //Load vault page
            CreateVaultPage createVaultPage = new CreateVaultPage(_client);
            createVaultPage.Dock = DockStyle.Fill;
        }

    }

    private UserDto createUserDTO(string username ,string password)
    {
        return new UserDto() { Username = username, Password = password};
    }
}
