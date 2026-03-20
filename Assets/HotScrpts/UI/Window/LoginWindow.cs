using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;
using HallWorld;

public partial class LoginWindow
{

    private string account;
    private string password;
    
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


    private void OnBtn_StartGameClick(Button btn)
    {
        Debug.Log("Btn_StartGame Clicked");
        HallWorld.HallWorld.GetExitsLogicCtrl<LoginLogic>().Login(account, password).Coroutine();
    }


    private void OnBtn_SelectServerClick(Button btn)
    {
        Debug.Log("Btn_SelectServer Clicked");
    }


    private void OnBtn_AgreementClick(Button btn)
    {
        Debug.Log("Btn_Agreement Clicked");
    }


    private void OnBtn_NoticeClick(Button btn)
    {
        Debug.Log("Btn_Notice Clicked");
    }


    private void OnBtn_ChangeAccountClick(Button btn)
    {
        Debug.Log("Btn_ChangeAccount Clicked");
        UIManager.Instance.OpenWindowAsync<RegisterWindow>();
        UIManager.Instance.CloseWindow<LoginWindow>();
    }


    private void OnBtn_ServiceClick(Button btn)
    {
        Debug.Log("Btn_Service Clicked");
    }


    private void OnBtn_AgreementArrClick(Button btn)
    {
        Debug.Log("Btn_AgreementArr Clicked");
    }


    private void OnInput_AccountChanged(InputField input, string text)
    {
        account = text;
    }


    private void OnInput_PasswordChanged(InputField input, string text)
    {
        password = text;
    }
}