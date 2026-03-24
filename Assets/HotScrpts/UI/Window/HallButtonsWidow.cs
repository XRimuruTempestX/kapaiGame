using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;


public enum HallButtonType
{
    MAINCITY,
    HEROS,
    PVE,
}

public partial class HallButtonsWidow
{

    public HallButtonType state = HallButtonType.MAINCITY;
    
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
        RefButtonState(HallButtonType.MAINCITY).Forget();
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
        RefButtonState(HallButtonType.MAINCITY).Forget();
    }

    private void OnBtn_HerosClick(Button btn)
    {
        Debug.Log("Btn_Heros Clicked");
        RefButtonState(HallButtonType.HEROS).Forget();
    }

    private void OnBtn_BackPackClick(Button btn)
    {
        Debug.Log("Btn_BackPack Clicked");
    }

    private void OnBtn_PVELevelClick(Button btn)
    {
        Debug.Log("Btn_PVELevel Clicked");
        RefButtonState(HallButtonType.PVE).Forget();
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

    public async UniTask RefButtonState(HallButtonType btnType = HallButtonType.MAINCITY)
    {
        switch (btnType)
        {
            case HallButtonType.MAINCITY:
                if (state != HallButtonType.MAINCITY)
                {
                    await UIManager.Instance.OpenWindowAsync<HallWindow>();
                }

                if (state == HallButtonType.HEROS)
                {
                    UIManager.Instance.CloseWindow<HeroListWindow>().Forget();
                    _view.Btn_Heros.transform.Find("btnSelect").transform.localScale = Vector3.zero;
                }
                
                if (state == HallButtonType.PVE)
                {
                    UIManager.Instance.CloseWindow<LevelWindow>().Forget();
                    _view.Btn_PVELevel.transform.Find("btnSelect").transform.localScale = Vector3.zero;
                }
                
                state = HallButtonType.MAINCITY;
                _view.Btn_MainCity.transform.Find("btnSelect").transform.localScale = Vector3.one;
                break;
            case HallButtonType.HEROS:
                if (state != HallButtonType.HEROS)
                {
                    await UIManager.Instance.OpenWindowAsync<HeroListWindow>();
                }

                if (state == HallButtonType.MAINCITY)
                {
                    UIManager.Instance.CloseWindow<HallWindow>().Forget();
                    _view.Btn_MainCity.transform.Find("btnSelect").transform.localScale = Vector3.zero;
                }
                
                if (state == HallButtonType.PVE)
                {
                    UIManager.Instance.CloseWindow<LevelWindow>().Forget();
                    _view.Btn_PVELevel.transform.Find("btnSelect").transform.localScale = Vector3.zero;
                }
                
                state = HallButtonType.HEROS;
                _view.Btn_Heros.transform.Find("btnSelect").transform.localScale = Vector3.one;
                break;
            case HallButtonType.PVE:

                if (state != HallButtonType.PVE)
                {
                    await UIManager.Instance.OpenWindowAsync<LevelWindow>();
                }
                
                if (state == HallButtonType.MAINCITY)
                {
                    UIManager.Instance.CloseWindow<HallWindow>().Forget();
                    _view.Btn_MainCity.transform.Find("btnSelect").transform.localScale = Vector3.zero;
                }
                if (state == HallButtonType.HEROS)
                {
                    UIManager.Instance.CloseWindow<HeroListWindow>().Forget();
                    _view.Btn_Heros.transform.Find("btnSelect").transform.localScale = Vector3.zero;
                }
                
                state = HallButtonType.PVE;
                _view.Btn_PVELevel.transform.Find("btnSelect").transform.localScale = Vector3.one;
                
                break;
        }
    }

}
