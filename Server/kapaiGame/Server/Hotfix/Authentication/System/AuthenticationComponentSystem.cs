using Fantasy;
using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Entitas;
using Fantasy.Helper;
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
    
}