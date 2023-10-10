using System.Security.Cryptography;
using System.Text;
using Web_Client.DTOs;

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
                        var propertyValue = (string)property.GetValue(credentials);

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

    public PasswordVaultDto DecryptVault(PasswordVaultDto vault, string username, string password)
    {
        if (vault != null || vault.EncryptedVault.Any())
        {
            foreach (var credentials in vault.EncryptedVault)
            {
                var encryptedCredential = new DecryptedCredentialsDto();

                foreach (var property in typeof(DecryptedCredentialsDto).GetProperties())
                {
                    var encryptedProp = (byte[])property.GetValue(credentials);

                    if(encryptedProp != null)
                    {
                        var salt = RetrieveSalt(encryptedProp);
                        var secretKey = DeriveSecterKey(username, password, salt);

                        var decryptedPropertyByteArr = DecryptProperty(encryptedProp, secretKey);

                        string decryptedProperty = Encoding.UTF8.GetString(decryptedPropertyByteArr);
                        var propertyName = property.Name;
                        typeof(HashedCredentialsDto).GetProperty(propertyName)?.SetValue(encryptedCredential, decryptedProperty);
                    }
                }
                vault.DecryptedVault?.Append(encryptedCredential);
            }
            return vault;
        }
        else
        {
            return new PasswordVaultDto();
        }
    }

    public static byte[] RetrieveSalt(byte[] property)
    {
        byte[] salt = property.Take(100).ToArray();
        return salt;
    }

    public static byte[] DeriveSecterKey(string username, string password, byte[] salt)
    {
        var secretKey = VaultKeyGenerator.GenerateVaultKey(username, password, salt);
        return secretKey;
    }

    public static byte[] EncryptProperty(string plainText, byte[] key, byte[] salt)
    {
        using var aes = new AesGcm(key);

        var nonce = RandomNumberGenerator.GetBytes(AesGcm.NonceByteSizes.MaxSize);
        var bytesText = Encoding.UTF8.GetBytes(plainText);
        var cipher = new byte[bytesText.Length];
        var tag = new byte[AesGcm.TagByteSizes.MaxSize];

        aes.Encrypt(nonce: nonce, plaintext: bytesText, ciphertext: cipher, tag: tag);

        var encryptedProp = ConcatCypher(salt, nonce, tag, cipher);
        return encryptedProp;
    }

    public static byte[] DecryptProperty(byte[] encryptedProp, byte[] key)
    {
        using var aes = new AesGcm(key);

        var nonce = encryptedProp.Skip(100).Take(12).ToArray();
        var tag = encryptedProp.Skip(112).Take(16).ToArray();
        var textToDecrypt = encryptedProp.Skip(128).ToArray();
        var decryptedProp = new byte[textToDecrypt.Length];

        aes.Decrypt(nonce: nonce, ciphertext: textToDecrypt, tag: tag, plaintext: decryptedProp);

        return decryptedProp;
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
