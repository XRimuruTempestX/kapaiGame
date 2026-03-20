using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class HallWindow
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

    private void OnBtn_RecruitClick(Button btn)
    {
        Debug.Log("Btn_Recruit Clicked");
        
        UIManager.Instance.OpenWindowAsync<RecruitWindow>().Forget();
    }

    private void OnBtn_XianquClick(Button btn)
    {
        Debug.Log("Btn_Xianqu Clicked");
    }

    private void OnBtn_DailyTaskClick(Button btn)
    {
        Debug.Log("Btn_DailyTask Clicked");
    }

    private void OnBtn_FriendClick(Button btn)
    {
        Debug.Log("Btn_Friend Clicked");
    }

    private void OnBtn_MailClick(Button btn)
    {
        Debug.Log("Btn_Mail Clicked");
    }

    private void OnBtn_RankClick(Button btn)
    {
        Debug.Log("Btn_Rank Clicked");
    }

    private void OnBtn_GoldClick(Button btn)
    {
        Debug.Log("Btn_Gold Clicked");
    }

}
