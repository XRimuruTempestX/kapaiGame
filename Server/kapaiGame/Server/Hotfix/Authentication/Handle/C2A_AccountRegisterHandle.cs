using Fantasy;
using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Fantasy.ToolData;

namespace Hotfix.Authentication.Handle;

public class C2A_AccountRegisterHandle : MessageRPC<C2A_RegisterAccountRequest, A2C_RegisterAccountResponse>
{
    protected override async FTask Run(Session session, C2A_RegisterAccountRequest request, A2C_RegisterAccountResponse response, Action reply)
    {

        AuthenticationComponent authComponent = session.Scene.GetComponent<AuthenticationComponent>();

        var data = await authComponent.CreateAccount(request.account,request.passWord);

        if (data.errorCode == ErrorCode.Success)
        {
            response.userId = data.account.Id;
            response.account = data.account.account;
            response.passWord = data.account.password;
            Log.Debug($"账号注册成功！ account :{response.account}  password:{data.account.password}");
        }
        else
        {
            response.ErrorCode = data.errorCode;
        } 
        
        await FTask.CompletedTask;

    }
}