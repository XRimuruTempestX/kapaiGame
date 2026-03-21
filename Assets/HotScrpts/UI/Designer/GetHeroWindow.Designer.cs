using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class GetHeroWindow : XUIBase
{
    private GetHeroWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<GetHeroWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[GetHeroWindow] Missing GetHeroWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.clickNextBtn,AddNextClickBtnListener);
    }
}
