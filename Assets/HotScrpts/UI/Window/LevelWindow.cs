using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

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
    }

    private void OnBtn_Level2Click(Button btn)
    {
        Debug.Log("Btn_Level2 Clicked");
    }

    private void OnBtn_Level3Click(Button btn)
    {
        Debug.Log("Btn_Level3 Clicked");
    }

    private void OnBtn_Level4Click(Button btn)
    {
        Debug.Log("Btn_Level4 Clicked");
    }

    private void OnBtn_Level5Click(Button btn)
    {
        Debug.Log("Btn_Level5 Clicked");
    }

    private void OnBtn_Level6Click(Button btn)
    {
        Debug.Log("Btn_Level6 Clicked");
    }

}
