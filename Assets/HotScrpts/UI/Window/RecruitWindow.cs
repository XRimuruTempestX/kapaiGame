using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using HallWorld;
using XAsset.Runtime;

public partial class RecruitWindow
{

    private GameObject chouKaScene;
    
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

    private void OnBtn_NormalClick(Button btn)
    {
        Debug.Log("Btn_Normal Clicked");
        PlayChouKaAnimation(1).Forget();
    }

    private void OnBtn_FirendClick(Button btn)
    {
        Debug.Log("Btn_Firend Clicked");
        PlayChouKaAnimation(5).Forget();
    }

    private void OnBtn_SeniorClick(Button btn)
    {
        Debug.Log("Btn_Senior Clicked");
        PlayChouKaAnimation(10).Forget();
    }

    private void OnBtn_HelpClick(Button btn)
    {
        Debug.Log("Btn_Help Clicked");
    }

    private void OnBtn_CloseClick(Button btn)
    {
        Debug.Log("Btn_Close Clicked");
        UIManager.Instance.OpenWindowAsync<HallWindow>().Forget();
        UIManager.Instance.CloseWindow<RecruitWindow>().Forget();
    }

    private void OnBtn_JumpClick(Button btn)
    {
        Debug.Log("Btn_Jump Clicked");
    }

    private async UniTask PlayChouKaAnimation(int gachaCount)
    {
        _view.Go_Mask.SetActive(true);
        await UIManager.Instance.CloseWindow<HallWindow>();
        _view.SkeletonGraphic.AnimationState.SetAnimation(0, "idle1", true);
        _view.Go_DownHorizationi.SetActive(false);
        chouKaScene = await XAssetFrameWork.Instance.InstantiateAsync("Assets/GameData/HallWorld/Effects/Recruit/ChoukaUIScene.prefab");
        await UniTask.Delay(3000);
        chouKaScene.GetComponent<Animator>().SetBool("play",true);
        
        await UniTask.Delay(3700);
        chouKaScene.GetComponent<Animator>().SetBool("play",false);
        _view.SkeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
        _view.Go_DownHorizationi.SetActive(true);
        _view.Go_Mask.SetActive(false);
        
        HallWorld.HallWorld.GetExitsLogicCtrl<GachaCarLogic>().SendCachaLogic(gachaCount).Coroutine();
    }

}
