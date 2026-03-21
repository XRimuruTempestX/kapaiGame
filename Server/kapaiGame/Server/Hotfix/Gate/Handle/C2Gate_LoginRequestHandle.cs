using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Hotfix.Gate.Component;
using Hotfix.Gate.System;

namespace Hotfix.Gate.Handle;

public class C2Gate_LoginRequestHandle : MessageRPC<C2Gate_LoginRequest,Gate2C_UserDataResponse>
{
    protected override async FTask Run(Session session, C2Gate_LoginRequest request, Gate2C_UserDataResponse response, Action reply)
    {
        UserDataComponent userDataComponent = session.Scene.GetComponent<UserDataComponent>();
        
        UserData userdata = await userDataComponent.LoginUser(request.account,session);
        response.userdata = new UserPlayerData();
        response.userdata.account = userdata.account;
        response.userdata.coin = userdata.coin;
        response.userdata.diamond = userdata.diamond;
        response.userdata.heroList = userdata.heroList;
        
        Log.Debug($"玩家数据：{userdata.account}  coin : {userdata.coin}  diamond : {userdata.diamond}  heroList : {userdata.heroList.ToString()}");
        
        await FTask.CompletedTask;
    }
}