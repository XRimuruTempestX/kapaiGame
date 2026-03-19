using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class LoginWindow : XUIBase
{
    private LoginWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<LoginWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[LoginWindow] Missing LoginWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_StartGame, OnBtn_StartGameClick);
        AddButtonListener(_view.Btn_SelectServer, OnBtn_SelectServerClick);
        AddButtonListener(_view.Btn_Agreement, OnBtn_AgreementClick);
        AddButtonListener(_view.Btn_Notice, OnBtn_NoticeClick);
        AddButtonListener(_view.Btn_ChangeAccount, OnBtn_ChangeAccountClick);
        AddButtonListener(_view.Btn_Service, OnBtn_ServiceClick);
        AddButtonListener(_view.Btn_AgreementArr, OnBtn_AgreementArrClick);
        AddInputFieldListener(_view.Input_Account, OnInput_AccountChanged);
        AddInputFieldListener(_view.Input_Password, OnInput_PasswordChanged);
    }
}
