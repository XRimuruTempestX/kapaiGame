using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using HotScrpts.Tools;
using XAsset.Runtime;

public partial class GetHeroWindow
{
    
    private List<int> curGetHeroList = new List<int>();
    private int currIndex = 0;

    private GameObject lihuiObj;
    
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
        curGetHeroList.Clear();
        currIndex = 0;
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

    public void AddNextClickBtnListener(Button btn)
    {
        Next().Forget();
    }

    private async UniTask Next()
    {
        if (curGetHeroList.Count <= currIndex)
        {
            await UIManager.Instance.OpenWindowAsync<TenRecruitWindow>(curGetHeroList);
            await UniTask.Delay(100);
            UIManager.Instance.DestroyWindow<GetHeroWindow>();
            return;
        }

        (lihuiObj.transform as RectTransform).DOKill();
        _view.uiAnimator.SetBool("play",true);
        (lihuiObj.transform as RectTransform).DOAnchorPosX(-2000, 0.3f);
        await UniTask.Delay(400);
        XAssetFrameWork.Instance.ReleaseGameObject(lihuiObj);
        _view.uiAnimator.SetBool("play",false);
        await PlayAnimation();
    }

    public void SetGainHeroList(List<int> heroList)
    {
        this.curGetHeroList = heroList;
        PlayAnimation().Forget();
    }

    private async UniTask PlayAnimation()
    {
        if (curGetHeroList.Count <= currIndex)
        {
            return;
        }
        lihuiObj = await XAssetFrameWork.Instance.InstantiateAsync($"Assets/GameData/HallWorld/Prefabs/Portrait2D/lihui_{ConfigCenter.Instance.GetCharacterForCharacterIdList(curGetHeroList[currIndex]).name}.prefab");
        Vector3 scale = lihuiObj.transform.localScale;
        lihuiObj.transform.SetParent(_view.Go_PortraitParent.transform);
        lihuiObj.transform.localPosition = Vector3.zero;
        lihuiObj.transform.localScale = scale;
        currIndex++;
    }
    
}
