
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client.crypto;

internal class VaultCrypto
{
    private string _username;
    private string _password;
    private PasswordVaultDto _encryptedVault;
    private PasswordVaultDto _decryptedVault;
    private VaultKeyGenerator _vaultKeyGenerator;

    public VaultCrypto(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public PasswordVaultDto EncryptVault()
    {
        //TODO 
        return new PasswordVaultDto();
    }

}
