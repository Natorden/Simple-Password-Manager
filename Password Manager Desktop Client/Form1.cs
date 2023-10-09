namespace Password_Manager_Desktop_Client;

public partial class Form1 : Form
{
    private static string _email;
    private static string _password;

    public Form1()
    {
        InitializeComponent();
    }

    private void logInBtn_Click(object sender, EventArgs e)
    {
        //TODO call webClient logIn and pass parameters
    }

    private void passwordInput_Changed(object sender, EventArgs e)
    {
        this.passwordInput.Text = _password;
    }

    private void emailInput_Changed(object sender, EventArgs e)
    {
        this.emailInput.Text = _email;
    }
}
