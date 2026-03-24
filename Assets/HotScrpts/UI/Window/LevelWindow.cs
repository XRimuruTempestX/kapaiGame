using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using HotScrpts.Tools;

public partial class LevelWindow
{
    #region 生命周期

    public override async UniTask PlayOpenAnimation()
    {
        await base.PlayOpenAnimation();
    }

    public override async UniTask PlayCloseAnimation()
    {
        await base.PlayCloseAnimation();
    }

    public override async UniTask OnOpen(params object[] args)
    {
        await base.OnOpen(args);
    }

    public override async UniTask OnClose()
    {
        await base.OnClose();
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    #endregion

    // Add your logic here

    private void OnBtn_Level1Click(Button btn)
    {
        Debug.Log("Btn_Level1 Clicked");
        SelectLevel(0).Forget();
    }

    private void OnBtn_Level2Click(Button btn)
    {
        Debug.Log("Btn_Level2 Clicked");
        SelectLevel(1).Forget();

    }

    private void OnBtn_Level3Click(Button btn)
    {
        Debug.Log("Btn_Level3 Clicked");
        SelectLevel(2).Forget();
    }

    private void OnBtn_Level4Click(Button btn)
    {
        Debug.Log("Btn_Level4 Clicked");
        SelectLevel(3).Forget();
    }

    private void OnBtn_Level5Click(Button btn)
    {
        Debug.Log("Btn_Level5 Clicked");
        SelectLevel(4).Forget();
    }

    private void OnBtn_Level6Click(Button btn)
    {
        Debug.Log("Btn_Level6 Clicked");
        SelectLevel(5).Forget();
    }


    private async UniTask SelectLevel(int leveIndex)
    {

        await UIManager.Instance.OpenWindowAsync<LevelDisplayWindow>(ConfigCenter.Instance.GetLevelConfigList()[leveIndex]);

    }

}
