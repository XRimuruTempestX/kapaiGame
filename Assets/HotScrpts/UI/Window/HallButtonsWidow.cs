using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class HallButtonsWidow
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

    private void OnBtn_MainCityClick(Button btn)
    {
        Debug.Log("Btn_MainCity Clicked");
    }

    private void OnBtn_HerosClick(Button btn)
    {
        Debug.Log("Btn_Heros Clicked");
    }

    private void OnBtn_BackPackClick(Button btn)
    {
        Debug.Log("Btn_BackPack Clicked");
    }

    private void OnBtn_PVELevelClick(Button btn)
    {
        Debug.Log("Btn_PVELevel Clicked");
    }

    private void OnBtn_CarbonClick(Button btn)
    {
        Debug.Log("Btn_Carbon Clicked");
    }

    private void OnBtn_TradeUnionClick(Button btn)
    {
        Debug.Log("Btn_TradeUnion Clicked");
    }

    private void OnBtn_ForeignAidClick(Button btn)
    {
        Debug.Log("Btn_ForeignAid Clicked");
    }

    private void OnBtn_ChatClick(Button btn)
    {
        Debug.Log("Btn_Chat Clicked");
    }

}
