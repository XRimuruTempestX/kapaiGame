using Cysharp.Threading.Tasks;
using HallWorld;
using HotScrpts.ConfigData;
using UnityEngine;
using UnityEngine.UI;
using XAsset.Runtime;
using XUIFramework;

namespace HotScrpts.UI
{
    public class GoBattleHeroItem : MonoBehaviour
    {
        private CharacterConfig characterConfig;

        public Button selectIcon;
        public Image heroIcon;

        public Image attribute;
        public Text lv;
        public Image star;
        public GameObject choosed;
        private bool selected;

        public string name;
        
        private ChoosFormationLogic choosFormationLogic;
        

        public async UniTask Init(CharacterConfig config)
        {
            gameObject.SetActive(true);
            selected = false;
            characterConfig = config;
            heroIcon.sprite =
                await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>(
                    $"Assets/GameData/HallWorld/Textures/HeroHead/X1_icon_{characterConfig.name}.png");
            attribute.sprite =  await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>(
                $"Assets/GameData/HallWorld/Textures/Common/X1_tongyong_zhenying_0{characterConfig.type}.png");
            star.sprite = await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>(
                $"Assets/GameData/HallWorld/Textures/Card/start{characterConfig.quality}.png");
            
            selectIcon.onClick.AddListener(async () =>
            {
                await AddSelectBtn();
            });
            name = characterConfig.name;
            choosFormationLogic = HallWorld.HallWorld.GetExitsLogicCtrl<ChoosFormationLogic>();
        }

        private async UniTask AddSelectBtn()
        {
            if (selected)
            {
                choosed.transform.localScale = Vector3.zero;
                selected =  false;
                int result = choosFormationLogic.DownSeat(characterConfig.id); 
                UIManager.Instance.GetWindow<ChoosFormationWindow>().DownHeroSeat(result, characterConfig.name);
            }
            else
            {
                
                int result = choosFormationLogic.SetHeroSeat(characterConfig.id);
                if (result != -1)
                {
                    selected = true;
                    choosed.transform.localScale = Vector3.one;
                    await UIManager.Instance.GetWindow<ChoosFormationWindow>().SetHeroSeat(result, characterConfig);
                }
                else
                {
                    Debuger.LogRed("位置已经满了  无法再加入队伍");
                }

            }
        }
    }
}