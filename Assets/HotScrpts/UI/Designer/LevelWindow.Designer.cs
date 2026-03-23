using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class LevelWindow : XUIBase
{
    private LevelWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<LevelWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[LevelWindow] Missing LevelWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_Level1, OnBtn_Level1Click);
        AddButtonListener(_view.Btn_Level2, OnBtn_Level2Click);
        AddButtonListener(_view.Btn_Level3, OnBtn_Level3Click);
        AddButtonListener(_view.Btn_Level4, OnBtn_Level4Click);
        AddButtonListener(_view.Btn_Level5, OnBtn_Level5Click);
        AddButtonListener(_view.Btn_Level6, OnBtn_Level6Click);
    }
}
