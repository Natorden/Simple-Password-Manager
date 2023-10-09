
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client.crypto;

internal class VaultCrypto : IVaultCrypto
{
    private string _username;
    private string _password;
    private PasswordVaultDto _encryptedVault;
    private PasswordVaultDto _decryptedVault;
    private VaultKeyGenerator _vaultKeyGenerator;

    public PasswordVaultDto EncryptVault(PasswordVaultDto vault, string username, string password)
    {
        throw new NotImplementedException();
    }
}
