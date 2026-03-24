using Cysharp.Threading.Tasks;
using HotScrpts.ConfigData;
using HotScrpts.Tools;
using UnityEngine;
using UnityEngine.UI;
using XAsset.Runtime;

namespace HotScrpts.UI
{
    public class EnemyHeadItem : MonoBehaviour
    {
        public Image head;
        public Image attribute;
        public Text lv;
        public Image star;

        private CharacterConfig enmeyConfig;
        
        public async UniTask InitData(int enemyId)
        {
            enmeyConfig = ConfigCenter.Instance.GetCharacterForCharacterIdList(enemyId);
            head.sprite = await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/HeroHead/X1_icon_{enmeyConfig.name}.png");
            attribute.sprite =  await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/Common/X1_tongyong_zhenying_0{enmeyConfig.type}.png");
            lv.text = "1";
            star.sprite =  await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/Card/start{enmeyConfig.quality}.png");
        }
        
    }
}