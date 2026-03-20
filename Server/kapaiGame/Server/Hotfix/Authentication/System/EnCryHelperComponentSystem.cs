using Fantasy.Authentication;
using Hotfix.Tools;

namespace Hotfix.Authentication;

public static class EnCryHelperComponentSystem
{

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="self"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static string Encryption(this EncryptHelperComponent self, string password)
    {
        return RSAEncryptHelper.RSAEncrypt(self.publicKey, password);
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="self"></param>
    /// <param name="password"></param>
    /// <param name="encryptedPassword"></param>
    /// <returns></returns>
    public static bool Decryption(this EncryptHelperComponent self, string password, string encryptedPassword)
    {

        string dePassword = RSAEncryptHelper.RSADecrypt(self.privateKey, encryptedPassword);
        
        return string.Equals(dePassword, password);
    }
    
}