using Cysharp.Threading.Tasks;
using HotScrpts.ConfigData;
using HotScrpts.Tools;
using UnityEngine;
using UnityEngine.UI;
using XAsset.Runtime;

namespace HotScrpts.UI
{
    public class CarItem : MonoBehaviour
    {
        public Button cardBtn;
        public Image bg;
        public Image icom;
        public Image frame;
        public Image attribute;
        public Text levelText;
        public Image coreImg;
        public Image startImg;


        public async UniTask InitData(int heroId)
        {
            CharacterConfig heroData = ConfigCenter.Instance.GetCharacterForCharacterIdList(heroId);
            icom.sprite = await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/HeroIcon/X1_card_{heroData.name}.png");
            bg.sprite = await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/Card/Cardbg{heroData.quality}.png");
            frame.sprite = await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/Card/CardFrame{heroData.quality}.png");
            attribute.sprite = await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/Card/attribute{heroData.quality}.png");
            startImg.sprite = await XAssetFrameWork.Instance.LoadAssetAsync<Sprite>($"Assets/GameData/HallWorld/Textures/Card/start{heroData.quality}.png");
        }
        
    }
}