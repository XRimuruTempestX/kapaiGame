using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Fantasy.ToolData;
using Hotfix.Gate.Component;
using Hotfix.Gate.System;
using Newtonsoft.Json;

namespace Hotfix.Gate.Handle;

public class C2Gate_GachaCarRequestHandle : MessageRPC<Fantasy.C2Gate_GachaCarRequest, Gate2C_GachaCarResponse>
{
    protected override async FTask Run(Session session, Fantasy.C2Gate_GachaCarRequest request, Gate2C_GachaCarResponse response, Action reply)
    {
        
        CharacterDataComponent characterDataComponent = session.Scene.GetComponent<CharacterDataComponent>();
        
        UserDataComponent userDataComponent = session.Scene.GetComponent<UserDataComponent>();
        var userData =  userDataComponent.GetUserdata(request.account);
        var result = characterDataComponent.GachaCar(request.gachaCarCount, userData);
        if (result.Item1)
        {
            userDataComponent.GainHero(userData,result.Item2);
            response.getHeroList = result.Item2;
            response.userData = new UserPlayerData();
            response.userData.account =  userData.account;
            response.userData.diamond = userData.diamond;
            response.userData.coin = userData.coin;
            response.userData.heroList = userData.heroList;
            await userDataComponent.SaveUserData(userData);
            string jsonMessage = JsonConvert.SerializeObject(result.Item2, Formatting.Indented);
            Log.Debug("抽卡完成----》》》》 "  + jsonMessage);
        }
        else
        {
            response.ErrorCode = ErrorCode.GachaFailedErrorCode;
        }
        await FTask.CompletedTask;
    }
}