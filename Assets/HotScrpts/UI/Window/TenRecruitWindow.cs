using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using HotScrpts.UI;
using XAsset.Runtime;

public partial class TenRecruitWindow
{
    
    private List<int> heroIdList = new List<int>();
    
    private List<GameObject> heroItemList = new List<GameObject>();
    
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
        heroIdList = args[0] as List<int>;
        heroItemList.Clear();
        for (int i = 0; i < _view.GetHeroCardItems.Length; i++)
        {
            _view.GetHeroCardItems[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < heroIdList.Count; i++)
        {
            _view.GetHeroCardItems[i].gameObject.SetActive(true);
        }
        await CreateHeroItem();
    }

    public override async UniTask OnClose()
    {
        for (int i = 0; i < heroItemList.Count; i++)
        {
            XAssetFrameWork.Instance.ReleaseGameObject(heroItemList[i]);
        }
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

    private void OnBtn_RetrunClick(Button btn)
    {
        Debug.Log("Btn_Retrun Clicked");
        UIManager.Instance.OpenWindowAsync<RecruitWindow>().Forget();
        UIManager.Instance.DestroyWindow<TenRecruitWindow>();
    }

    public async UniTask CreateHeroItem()
    {
        for (int i = 0; i < heroIdList.Count; i++)
        {
            GameObject heroItem = await XAssetFrameWork.Instance.InstantiateAsync("Assets/GameData/HallWorld/Prefabs/Card/CardItem.prefab");
            heroItemList.Add(heroItem);
            heroItem.transform.parent = _view.GetHeroCardItems[i].transform;
            heroItem.transform.localPosition = Vector3.zero;
            heroItem.transform.localScale = Vector3.one;
            CarItem cardItem = heroItem.GetComponent<CarItem>();
            await cardItem.InitData(heroIdList[i]);
            await UniTask.Delay(500);
        }
        
        _view.Go_Mask.gameObject.SetActive(false);
    }

}
