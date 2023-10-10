using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;
using Web_Client.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Password_Manager_Desktop_Client.crypto;

public class VaultCrypto : IVaultCrypto
{

    public PasswordVaultDto EncryptVault(PasswordVaultDto vault, string username, string password)
    {
            if (vault != null || vault.DecryptedVault.Any())
            {
                foreach (var credentials in vault.DecryptedVault)
                {
                var encryptedCredential = new HashedCredentialsDto();

                    foreach (var property in typeof(DecryptedCredentialsDto).GetProperties())
                    {
                        var salt = GenerateSalt();

                        var secretKey = DeriveSecterKey(username, password, salt);

                        var propertyValue = property.GetValue(credentials).ToString();

                        if(propertyValue != null)
                        {
                        var encryptedProperty = EncryptProperty(propertyValue, secretKey, salt);
                        
                        var propertyName = property.Name;

                        typeof(HashedCredentialsDto).GetProperty(propertyName)?.SetValue(encryptedCredential, encryptedProperty);
                        }
                    }
                vault.EncryptedVault?.Append(encryptedCredential);
                }
                return vault;
            }
            else
            {
                return new PasswordVaultDto();
            }
    }

    public static byte[] DeriveSecterKey(string username, string password, byte[] salt)
    {
        var secretKey = VaultKeyGenerator.GenerateVaultKey(username, password, salt);
        return secretKey;
    }

    public static byte[] EncryptProperty(string plainText, byte[] key, byte[] salt)
    {
        using var aes = new AesGcm(key);

        var usernameNonce = RandomNumberGenerator.GetBytes(AesGcm.NonceByteSizes.MaxSize);
        var usernameBytes = Encoding.UTF8.GetBytes(plainText);
        var usernameCipher = new byte[usernameBytes.Length];
        var usernameTag = new byte[AesGcm.TagByteSizes.MaxSize];

        aes.Encrypt(nonce: usernameNonce, plaintext: usernameBytes, ciphertext: usernameCipher, tag: usernameTag);

        var encryptedProp = ConcatCypher(salt, usernameNonce, usernameTag, usernameCipher);
        return encryptedProp;
    }

    public static byte[] GenerateSalt()
    {
        var buffer = new byte[100];
        RNGCryptoServiceProvider rng = new();
        rng.GetBytes(buffer);

        return buffer;
    }

    public static byte[] ConcatCypher(byte[] salt, byte[] nonce, byte[] tag, byte[] cypher)
    {
        return salt.Concat(nonce).Concat(tag).Concat(cypher).ToArray();
    }
}
