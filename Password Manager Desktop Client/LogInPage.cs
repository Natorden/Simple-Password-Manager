
using Web_Client;

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

    private void EmailText_Changed(object sender, EventArgs e)
    {
        emailTextBox.Text = _email;
    }

    private void PasswordText_Changed(object sender, EventArgs e)
    {
        passwordTextBox.Text = _password;
    }

    private void LogInButton_Clicked(object sender, EventArgs e)
    {
        //TODO Call logIn method from webClient
    }
}
