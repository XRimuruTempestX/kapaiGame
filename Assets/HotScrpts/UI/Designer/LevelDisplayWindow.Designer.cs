using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class LevelDisplayWindow : XUIBase
{
    private LevelDisplayWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<LevelDisplayWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[LevelDisplayWindow] Missing LevelDisplayWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_Fight, OnBtn_FightClick);
        AddButtonListener(_view.Btn_RePlay, OnBtn_RePlayClick);
        AddButtonListener(_view.Btn_Close, OnBtn_CloseClick);
    }
}
