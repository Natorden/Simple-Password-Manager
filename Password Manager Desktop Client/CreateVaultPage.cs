using Password_Manager_Desktop_Client.crypto;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class CreateVaultPage : UserControl
{
    private IWebClient _client;
    private Guid _userId;
    private string _username;
    private string _password;
    private PasswordVaultDto? _decriptedVault;
    private IVaultCrypto _vaultCryptoHelper;

    public CreateVaultPage(IWebClient client, IVaultCrypto vaultCryptoHelper, Guid userId, string username, string password)
    {
        _client = client;
        _userId = userId;
        _username = username;
        _password = password;
        _vaultCryptoHelper = vaultCryptoHelper;
        InitializeComponent();
    }

    private async void CreateVaultPage_Load(object sender, EventArgs e)
    {
        var encryptedVault = await _client.GetAsync(_userId);
        var decryptedVault = DecryptVault(encryptedVault);
        _decriptedVault = decryptedVault;
    }

    private void AddNewPassword_Click(object sender, EventArgs e)
    {
        //TODO call crypto helper 
        //TODO update vault 
    }

    private void LogOut_Button_Click(object sender, EventArgs e)
    {
        //TODO log out user
    }

    private PasswordVaultDto DecryptVault(PasswordVaultDto vault)
    {
        //TODO call crypto helper
        return vault;
    }
}
