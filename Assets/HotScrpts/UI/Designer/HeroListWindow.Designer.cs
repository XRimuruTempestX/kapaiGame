using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class HeroListWindow : XUIBase
{
    private HeroListWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<HeroListWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[HeroListWindow] Missing HeroListWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
    }
}
