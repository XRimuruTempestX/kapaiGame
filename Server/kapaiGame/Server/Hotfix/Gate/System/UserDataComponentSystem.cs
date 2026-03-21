using System.Security.Cryptography.X509Certificates;
using Fantasy;
using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Database;
using Fantasy.Entitas;
using Fantasy.Network;
using Hotfix.Gate.Component;

namespace Hotfix.Gate.System;

public static class UserDataComponentSystem
{

    public static async FTask<UserData> LoginUser(this UserDataComponent self, string account, Session session)
    {
        int hash = account.GetHashCode();
        UserData userData = null;
        IDatabase database = self.Scene.World.Database;
        if (!self.userDataDic.ContainsKey(hash))
        {
            userData = await database.First<UserData>(q=> q.account == account);
            if (userData == null)
            {
                userData = Entity.Create<UserData>(self.Scene);
                userData.account = account;
                userData.coin = 0;
                userData.diamond = 99999;
                userData.heroList = new List<int>();
                userData._session = session;
                self.userDataDic.Add(hash, userData);
                await database.Save(userData);
            }
            else
            {
                userData._session = session;
                self.userDataDic.Add(hash, userData);
            }
        }
        else
        {
            userData = self.userDataDic[hash];
        }

        return userData;
    }

    public static UserData GetUserdata(this UserDataComponent self, string account)
    {
        return self.userDataDic[account.GetHashCode()];
    }

    public static void GainHero(this UserDataComponent self,UserData userData, List<int> heroList)
    {

        for (int i = 0; i < heroList.Count; i++)
        {
            if (!userData.heroList.Contains(heroList[i]))
            {
                userData.heroList.Add(heroList[i]);
            }
        }
        
    }

    public static async FTask SaveUserData(this UserDataComponent self, UserData userData)
    {
        IDatabase database = self.Scene.World.Database;
        await database.Save(userData);
    }
    
}