using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XUIFramework;
using Cysharp.Threading.Tasks;

public partial class HallWindow : XUIBase
{
    private HallWindowComponent _view;

    protected override void OnInit()
    {
        base.OnInit();
        _view = GameObject.GetComponent<HallWindowComponent>();
        if (_view == null)
        {
            Debug.LogError($"[HallWindow] Missing HallWindowComponent on {Name}");
            return;
        }

        // Auto Bind Listeners
        AddButtonListener(_view.Btn_Recruit, OnBtn_RecruitClick);
        AddButtonListener(_view.Btn_Xianqu, OnBtn_XianquClick);
        AddButtonListener(_view.Btn_DailyTask, OnBtn_DailyTaskClick);
        AddButtonListener(_view.Btn_Friend, OnBtn_FriendClick);
        AddButtonListener(_view.Btn_Mail, OnBtn_MailClick);
        AddButtonListener(_view.Btn_Rank, OnBtn_RankClick);
        AddButtonListener(_view.Btn_Gold, OnBtn_GoldClick);
    }
}
