using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using HotScrpts.ConfigData;

public partial class LevelDisplayWindow
{
    LevelConfig leveConfig;
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
        leveConfig =  (LevelConfig)args[0];
        for (int i = 0; i < _view.enemies.Length; i++)
        {
            _view.enemies[i].InitData(leveConfig.enemys[i]);
        }
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

    private void OnBtn_FightClick(Button btn)
    {
        Debug.Log("Btn_Fight Clicked");
        //加载地图
        UIManager.Instance.OpenWindowAsync<ChoosFormationWindow>(leveConfig.enemys).Forget();
    }

    private void OnBtn_RePlayClick(Button btn)
    {
        Debug.Log("Btn_RePlay Clicked");
    }

    private void OnBtn_CloseClick(Button btn)
    {
        Debug.Log("Btn_Close Clicked");
        UIManager.Instance.CloseWindow<LevelDisplayWindow>().Forget();
    }

}
