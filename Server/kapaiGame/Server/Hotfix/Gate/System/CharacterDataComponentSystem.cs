using Fantasy;
using Fantasy.Authentication;
using Fantasy.Helper;
using Hotfix.Gate.Component;
using Newtonsoft.Json;

namespace Hotfix.Gate.System;

public static class CharacterDataComponentSystem
{

    public static void LoadCharacterConfig(this CharacterDataComponent self)
    {
        string path = @"E:\Unity_G_Project\kapai\Server\kapaiGame\Server\Hotfix\GameConfig\tbherodatacfg.json";
        if (!File.Exists(path))
        {
            Log.Debug("tbherodatacfg配置文件不存在");
            return;
        }
        
        string json = File.ReadAllText(path);

        self.characterList = JsonConvert.DeserializeObject<List<CharacterConfig>>(json);
        
    }

    public static (bool,List<int>) GachaCar(this CharacterDataComponent self, int gachaCount,UserData userData)
    {

        if (userData.diamond < gachaCount * 100)
        {
            return (false, null);
        }
        userData.diamond -= gachaCount * 100;
        
        List<int> getCar = new List<int>();

        Random random = new Random(Environment.TickCount);

        for (int i = 0; i < gachaCount; i++)
        {
            int index = random.Next(0,self.characterList.Count);
            getCar.Add(self.characterList[index].id);
        }
        
        return (true, getCar);
        
    }
    
}