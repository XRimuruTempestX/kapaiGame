using Fantasy;
using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Database;
using Fantasy.Entitas;
using Fantasy.Helper;
using Fantasy.Network;
using Fantasy.ToolData;

namespace Hotfix.Authentication;

public enum LockType
{
    None,
    Register,
    Login,
    Logout,
}

public static class AuthenticationComponentSystem
{

    public static async FTask<(uint errorCode, Account account)> CreateAccount(this AuthenticationComponent self,string account, string password)
    {

        if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
        {
            Log.Debug("账号密码有空！！！");
            return (ErrorCode.RegisterAccountOrPasswordErrorCode, null);
        }

        var database = self.Scene.World.Database;

        if (database != null)
        {
            using (await self.Scene.CoroutineLockComponent.Wait((long)LockType.Register, 1))
            {
                var isExist = await database.Exist<Account>(a => a.account == account);
                if (!isExist)
                {
                    Account user = Entity.Create<Account>(self.Scene);
                    user.account = account;

                    string encryptedPassword = self.Scene.GetComponent<EncryptHelperComponent>().Encryption(password);
                    
                    user.password = encryptedPassword;
                    user.createTime = TimeHelper.Now;

                    await database.Save(user);

                    return (ErrorCode.Success, user);
                }
            }
        }

        return (ErrorCode.ExitAccount, null);
    }

    public static async FTask<(uint errorCode, PlayerSession playerSession)> LoginAccount(this AuthenticationComponent self, string account, string password,Session _session)
    {
        if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
        {
            Log.Debug("账号密码有空！！！");
            return (ErrorCode.RegisterAccountOrPasswordErrorCode,null);
        }
        EncryptHelperComponent encryptHelper = self.Scene.GetComponent<EncryptHelperComponent>();
        //验证账号密码
        PlayerSession userSession = null;
        IDatabase database = self.Scene.World.Database;
        int hashCode = account.GetHashCode();


        using (await self.Scene.CoroutineLockComponent.Wait((long)LockType.Login, 1))
        {
            //如果当前存在缓存中 则证明已经在线 需要发送踢掉信息
            if (self._cachedAccounts.ContainsKey(hashCode))
            {
                userSession = self._cachedAccounts[hashCode];
                if (userSession != null)
                {
                    bool result =  encryptHelper.Decryption(password, userSession.passWord);
                    if (result)
                    {
                        //执行登录，提到上一个账号
                        self._cachedAccounts.Remove(hashCode);
                        return (ErrorCode.LoginAccountAlreadyExistErrorCode, userSession);
                    }
                    else
                    {
                        //密码错误
                        return (ErrorCode.LoginPasswordErrorCode,null);
                    }
                }
            }

            Account userAccount = await database.First<Account>(q => q.account == account);
            if (userAccount != null)
            {
                Log.Debug("--->>>>>   ");
                Log.Debug(userAccount.password);
                bool result2 =  encryptHelper.Decryption(password, userAccount.password);

                if (result2)
                {
                    userSession = Entity.Create<PlayerSession>(self.Scene);
                    userSession.account = account;
                    userSession.passWord = userAccount.password;
                    userSession._session = _session;
                    self._cachedAccounts.Add(hashCode, userSession);
                    return (ErrorCode.Success, userSession);
                }
            }
        
            return (ErrorCode.LoginAccountNotExistErrorCode,null);
        }
        
    }
    
}