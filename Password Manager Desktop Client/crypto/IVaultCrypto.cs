using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client.crypto
{
    public interface IVaultCrypto
    {
        public PasswordVaultDto EncryptVault(PasswordVaultDto vault);
    }
}
