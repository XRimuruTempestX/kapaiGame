using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using HallWorld;
using HotScrpts.UI;

public partial class HeroListWindow
{
    
    private List<GameObject> heroItems = new List<GameObject>();
    
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
        heroItems.Clear();
        await RefreshUI();
    }

    public override async UniTask OnClose()
    {
        for (int i = 0; i < heroItems.Count; i++)
        {
            GameObject.Destroy(heroItems[i]);
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

    public async UniTask RefreshUI()
    {

        for (int i = 0; i < UserDataData.userData.heroList.Count; i++)
        {
            GameObject heroItem = GameObject.Instantiate(_view.heroItemPrefab, _view.content, true);
            heroItems.Add(heroItem);
            heroItem.SetActive(true);
            CarItem carItem = heroItem.GetComponent<CarItem>();
            await carItem.InitData(UserDataData.userData.heroList[i]);
        }
        
    }
    
}
