using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class ChoosFormationWindow : XUIBase
{
    private ChoosFormationWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<ChoosFormationWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[ChoosFormationWindow] Missing ChoosFormationWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_StartFight, OnBtn_StartFightClick);
        AddButtonListener(_view.Btn_Close, OnBtn_CloseClick);
    }
}
