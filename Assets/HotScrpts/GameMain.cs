using UnityEngine;
using XAsset.Runtime;
using XLHFramework.GCFrameWork.World;
using XLHFrameWork.XAsset.Config;
using XUIFramework;

public class GameMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
       await XAssetFrameWork.Instance.InitlizateResAsync(BundleModuleEnum.GameArt.ToString());
       UIManager.Instance.OnInit();
       WorldManager.CreateWorld<HallWorld.HallWorld>();
       await UIManager.Instance.OpenWindowAsync<LoginWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
