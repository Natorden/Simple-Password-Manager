using System.Security.Cryptography;
using System.Text;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client.crypto;

public class VaultCrypto : IVaultCrypto
{

    public PasswordVaultDto EncryptVault(PasswordVaultDto vault, string username, string password)
    {
        if(vault != null) 
        {
            if (vault.EncryptedVault.Any())
            {
                foreach (var credentials in vault.EncryptedVault)
                {
                    //TODO Make this key 256 bytes insted of random lenght
                    var usernameKey = VaultKeyGenerator.GenerateVaultKey(username, password);

                    using var aes = new AesGcm(usernameKey);

                    var usernameNonce = RandomNumberGenerator.GetBytes(AesGcm.NonceByteSizes.MaxSize);
                    var usernameBytes = Encoding.UTF8.GetBytes(username);
                    var usernameCypher = new byte[usernameBytes.Length];
                    var usernameTag = new byte[AesGcm.TagByteSizes.MaxSize];

                    aes.Encrypt(nonce: usernameNonce, plaintext: usernameBytes, ciphertext: usernameCypher, tag: usernameTag);

                    credentials.Username = usernameNonce.Concat(usernameCypher).Concat(usernameTag).ToArray();
                }
            }
            else
            {
                return new PasswordVaultDto();
            }
        }
        else
        {
            return new PasswordVaultDto();
        }
        
    }
}
