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
        
        public List<LevelConfig> levelConfigList = new List<LevelConfig>();

        public async UniTask LoadConfigData()
        {
            string path = "Assets/GameData/GameConfig/tbherodatacfg.json";

            TextAsset json = await XAssetFrameWork.Instance.LoadAssetAsync<TextAsset>(path);
            
            heroConfigList = JsonConvert.DeserializeObject<List<CharacterConfig>>(json.text);

            string path2 = "Assets/GameData/GameConfig/tblevelconfig.json";
            
            TextAsset json2 = await XAssetFrameWork.Instance.LoadAssetAsync<TextAsset>(path2);
            
            levelConfigList = JsonConvert.DeserializeObject<List<LevelConfig>>(json2.text);
        }

        /// <summary>
        /// 获取英雄配置数据
        /// </summary>
        /// <returns></returns>
        public List<CharacterConfig> GetCharacterConfigList()
        {
            return heroConfigList;
        }

        public List<LevelConfig> GetLevelConfigList()
        {
            return levelConfigList;
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
