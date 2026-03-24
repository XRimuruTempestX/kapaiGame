using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using HallWorld;
using HotScrpts.ConfigData;
using HotScrpts.Tools;
using HotScrpts.UI;
using XAsset.Config;
using XAsset.Runtime;

public partial class ChoosFormationWindow
{

    private GameObject map3;
    private GameObject _3DBattleRoot;
    
    private List<GameObject> heroList = new List<GameObject>();
    
    /// <summary>
    /// 场景敌人
    /// </summary>
    private List<GameObject> enemyObjList = new List<GameObject>();

    private List<int> enemyIdList = new List<int>();
    
    
    private List<GameObject> heroObjectList = new List<GameObject>();
    
    
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
        enemyIdList = args[0] as List<int>;
        await UIManager.Instance.CloseWindow<LevelWindow>();
        await UIManager.Instance.CloseWindow<LevelDisplayWindow>();
        await InitData();
    }

    public override async UniTask OnClose()
    {
        for (int i = 0; i < heroList.Count; i++)
        {
            GameObject.Destroy(heroList[i]);
        }

        for (int i = 0; i < enemyObjList.Count; i++)
        {
            XAssetFrameWork.Instance.ReleaseGameObject(enemyObjList[i]);
        }
        
        for (int i = 0; i < heroObjectList.Count; i++)
        {
            XAssetFrameWork.Instance.ReleaseGameObject(heroObjectList[i]);
        }
        
        
        await base.OnClose();
        _3DBattleRoot.SetActive(false);
        map3.SetActive(false);
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        XAssetFrameWork.Instance.ReleaseGameObject(_3DBattleRoot);
        XAssetFrameWork.Instance.ReleaseGameObject(map3);
    }

    #endregion

    // Add your logic here

    private void OnBtn_StartFightClick(Button btn)
    {
        Debug.Log("Btn_StartFight Clicked");
    }

    private void OnBtn_CloseClick(Button btn)
    {
        Debug.Log("Btn_Close Clicked");
        UIManager.Instance.CloseWindow<ChoosFormationWindow>().Forget();
        XAssetFrameWork.Instance.ReleaseGameObject(_3DBattleRoot);
        XAssetFrameWork.Instance.ReleaseGameObject(map3);
        UIManager.Instance.OpenWindowAsync<HallWindow>().Forget();
        UIManager.Instance.OpenWindowAsync<HallButtonsWidow>().Forget();
    }


    private async UniTask InitData()
    {
        if (map3 == null)
        {
            map3 = await XAssetFrameWork.Instance.InstantiateAsync("Assets/GameData/HallWorld/Prefabs/Battle/Map3.prefab");
        }

        if (_3DBattleRoot == null)
        {
            _3DBattleRoot = await XAssetFrameWork.Instance.InstantiateAsync("Assets/GameData/HallWorld/Prefabs/Battle/3DBattleRoot.prefab");
        }
        for (int i = 0; i < UserDataData.userData.heroList.Count; i++)
        {
            GameObject heroItem = GameObject.Instantiate(_view.goBattleHeroItem,_view.content.transform,false);
            heroList.Add(heroItem);
            await heroItem.GetComponent<GoBattleHeroItem>().Init(ConfigCenter.Instance.GetCharacterForCharacterIdList(UserDataData.userData.heroList[i]));
        }
        
        //创建敌人
        BattleRoot3D battleRoot3D = _3DBattleRoot.GetComponent<BattleRoot3D>();
        for (int i = 0; i < enemyIdList.Count; i++)
        {
            CharacterConfig enenyConfig = ConfigCenter.Instance.GetCharacterForCharacterIdList(enemyIdList[i]);
            GameObject enemyObj = await XAssetFrameWork.Instance.InstantiateAsync($"Assets/GameData/HallWorld/Prefabs/BattleRoles/role_{enenyConfig.name}.prefab",battleRoot3D.rightSeatTransArr[i]);
            enemyObjList.Add(enemyObj);
        }
        
    }

    public async UniTask SetHeroSeat(int seatId, CharacterConfig heroConfig)
    {
        BattleRoot3D battleRoot3D = _3DBattleRoot.GetComponent<BattleRoot3D>();
        
        GameObject heroObj = await XAssetFrameWork.Instance.InstantiateAsync($"Assets/GameData/HallWorld/Prefabs/BattleRoles/role_{heroConfig.name}.prefab",battleRoot3D.leftSeatTransArr[seatId]);
        heroObjectList.Add(heroObj);
        heroObj.name = heroConfig.name;
    }

    public void DownHeroSeat(int seatId,string _name)
    {
        BattleRoot3D battleRoot3D = _3DBattleRoot.GetComponent<BattleRoot3D>();
        GameObject heroObj = null;
        for (int j = 0; j < battleRoot3D.leftSeatTransArr[seatId].childCount; j++)
        {
            if (battleRoot3D.leftSeatTransArr[seatId].transform.GetChild(j).name == _name)
            {
                heroObj = battleRoot3D.leftSeatTransArr[seatId].transform.GetChild(j).gameObject;
                break;
            }
        }

        if (heroObj != null)
        {
            heroObjectList.Remove(heroObj);
            XAssetFrameWork.Instance.ReleaseGameObject(heroObj);
        }
    }

}
