using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class RegisterWindow
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

    private void OnBtn_RegisterClick(Button btn)
    {
        Debug.Log("Btn_Register Clicked");
    }

    private void OnBtn_BackClick(Button btn)
    {
        Debug.Log("Btn_Back Clicked");
        UIManager.Instance.OpenWindowAsync<LoginWindow>();
        UIManager.Instance.CloseWindow<RegisterWindow>();
    }


    private void OnInput_AccountChanged(InputField input, string text)
    {
    }


    private void OnInput_PasswordChanged(InputField input, string text)
    {
    }
}