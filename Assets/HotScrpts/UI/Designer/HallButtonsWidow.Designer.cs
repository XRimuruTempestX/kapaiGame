using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class HallButtonsWidow : XUIBase
{
    private HallButtonsWidowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<HallButtonsWidowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[HallButtonsWidow] Missing HallButtonsWidowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_MainCity, OnBtn_MainCityClick);
        AddButtonListener(_view.Btn_Heros, OnBtn_HerosClick);
        AddButtonListener(_view.Btn_BackPack, OnBtn_BackPackClick);
        AddButtonListener(_view.Btn_PVELevel, OnBtn_PVELevelClick);
        AddButtonListener(_view.Btn_Carbon, OnBtn_CarbonClick);
        AddButtonListener(_view.Btn_TradeUnion, OnBtn_TradeUnionClick);
        AddButtonListener(_view.Btn_ForeignAid, OnBtn_ForeignAidClick);
        AddButtonListener(_view.Btn_Chat, OnBtn_ChatClick);
    }
}
