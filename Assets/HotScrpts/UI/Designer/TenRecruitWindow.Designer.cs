using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class TenRecruitWindow : XUIBase
{
    private TenRecruitWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<TenRecruitWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[TenRecruitWindow] Missing TenRecruitWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_Retrun, OnBtn_RetrunClick);
    }
}
