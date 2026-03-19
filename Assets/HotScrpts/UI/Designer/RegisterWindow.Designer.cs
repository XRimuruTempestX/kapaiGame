using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class RegisterWindow : XUIBase
{
    private RegisterWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<RegisterWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[RegisterWindow] Missing RegisterWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_Register, OnBtn_RegisterClick);
        AddButtonListener(_view.Btn_Back, OnBtn_BackClick);
        AddInputFieldListener(_view.Input_Account, OnInput_AccountChanged);
        AddInputFieldListener(_view.Input_Password, OnInput_PasswordChanged);
    }
}
