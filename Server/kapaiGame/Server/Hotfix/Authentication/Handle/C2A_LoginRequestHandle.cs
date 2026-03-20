using Fantasy;
using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Fantasy.Platform.Net;
using Fantasy.ToolData;

namespace Hotfix.Authentication.Handle;

public class C2A_LoginRequestHandle : MessageRPC<C2A_LoginRequest, A2C_LoginResponse>
{
    protected override async FTask Run(Session session, C2A_LoginRequest request, A2C_LoginResponse response, Action reply)
    {

        AuthenticationComponent authComponent = session.Scene.GetComponent<AuthenticationComponent>();
        var result = await authComponent.LoginAccount(request.account,request.passWprd,session);

        string gateIp = "127.0.0.1";
        int gatePor = SceneConfigData.Instance.GetSceneBySceneType(SceneType.Gate)[0].OuterPort;
        
        if (result.errorCode == ErrorCode.Success)
        {
            response.gateIp = gateIp;
            response.gatePor =  gatePor;
            response.ErrorCode = ErrorCode.Success;
            
            Log.Debug($"登录成功 : account {request.account}");
        }
        else if (result.errorCode == ErrorCode.LoginAccountAlreadyExistErrorCode)
        {
            result.playerSession._session.Send(new A2C_KickOut()
            {
                reason = 1,
                message = "被踢下线"
            });
            result.playerSession._session.Dispose();
            response.ErrorCode = ErrorCode.LoginAccountAlreadyExistErrorCode;
        }
        else
        {
            response.ErrorCode = result.errorCode;
        }
        
        await FTask.CompletedTask;
    }
}