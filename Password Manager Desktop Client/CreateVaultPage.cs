using Password_Manager_Desktop_Client.crypto;
using Web_Client;
using Web_Client.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Password_Manager_Desktop_Client;

public partial class CreateVaultPage : UserControl
{
    private string _username;
    private string _password;
    private IWebClient _client;
    private Guid _userId;
    private PasswordVaultDto? _vault;
    private IVaultCrypto _vaultCryptoService;
    private Form1 _parent;
    private List<DecryptedCredentialsDto>? _decryptedCredentialsDtos = new List<DecryptedCredentialsDto>();
    private List<HashedCredentialsDto>? _encryptedCredentialsDtos = new List<HashedCredentialsDto>();

    public CreateVaultPage(IWebClient client, IVaultCrypto vaultCryptoService, Guid userId, string username, string password, Form1 parent)
    {
        _client = client;
        _userId = userId;
        _username = username;
        _password = password;
        _vaultCryptoService = vaultCryptoService;
        _parent = parent;
        InitializeComponent();
    }

    private async void CreateVaultPage_Load(object sender, EventArgs e)
    {
        //var encryptedVault = await _client.GetAsync(_userId);
        //var decryptedVault = DecryptVault(encryptedVault);
        //_decriptedVault = decryptedVault;
    }

    private void AddNewPassword_Click(object sender, EventArgs e)
    {
        var addCredentialsPage = new AddCredentials(parentUserControl: this);
        _parent.Controls.Add(addCredentialsPage);
        addCredentialsPage.BringToFront();
    }

    public void AddCredentialsToDto(DecryptedCredentialsDto credentials)
    {
        _decryptedCredentialsDtos.Add(credentials);
        _ = _parent.ShowSucess("Credentials added to list!");
    }

    private void LogOut_Button_Click(object sender, EventArgs e)
    {
        //TODO log out user
    }

    private void Encrypt_Click(object sender, EventArgs e)
    {
        PasswordVaultDto vault = new PasswordVaultDto()
        {
            //TODO change after api and db works
            OwnerGuid = Guid.NewGuid(),
            EncryptedVault = _encryptedCredentialsDtos,
            DecryptedVault = _decryptedCredentialsDtos
        };

        var encrypted = _vaultCryptoService.EncryptVault(vault, _username, _password);
        _vault = encrypted;
        _vault.DecryptedVault = new List<DecryptedCredentialsDto>();
    }

    private void Decrypt_Click(object sender, EventArgs e)
    {
        var decrypted = _vaultCryptoService.DecryptVault(_vault, _username, _password);
        _vault = decrypted;
    }
}
