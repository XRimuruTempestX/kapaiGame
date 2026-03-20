using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class RecruitWindow : XUIBase
{
    private RecruitWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<RecruitWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[RecruitWindow] Missing RecruitWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_Normal, OnBtn_NormalClick);
        AddButtonListener(_view.Btn_Firend, OnBtn_FirendClick);
        AddButtonListener(_view.Btn_Senior, OnBtn_SeniorClick);
        AddButtonListener(_view.Btn_Help, OnBtn_HelpClick);
        AddButtonListener(_view.Btn_Close, OnBtn_CloseClick);
        AddButtonListener(_view.Btn_Jump, OnBtn_JumpClick);
    }
}
