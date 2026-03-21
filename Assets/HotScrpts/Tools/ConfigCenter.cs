using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HotScrpts.ConfigData;
using Newtonsoft.Json;
using UnityEngine;
using XAsset.Runtime;
using XAsset.Tools;

namespace HotScrpts.Tools
{
    public class ConfigCenter : Singleton<ConfigCenter>
    {
    
        public List<CharacterConfig> heroConfigList = new List<CharacterConfig>();

        public async UniTask LoadCharacterConfigData()
        {
            string path = "Assets/GameData/GameConfig/tbherodatacfg.json";

            TextAsset json = await XAssetFrameWork.Instance.LoadAssetAsync<TextAsset>(path);
            
            heroConfigList = JsonConvert.DeserializeObject<List<CharacterConfig>>(json.text);
        }

        /// <summary>
        /// 获取英雄配置数据
        /// </summary>
        /// <returns></returns>
        public List<CharacterConfig> GetCharacterConfigList()
        {
            return heroConfigList;
        }

        /// <summary>
        /// 通过英雄ID获取
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        public CharacterConfig GetCharacterForCharacterIdList(int heroId)
        {
            return heroConfigList.Find(q=> q.id == heroId);
        }
    
    }
}
