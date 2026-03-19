using System;
using Fantasy;
using UnityEngine;
using UnityEngine.UI;

namespace HotScrpts.NetWork
{
    public class TestConnetct : MonoBehaviour
    {
        
        public Button connectBtn;

        private void Start()
        {
            connectBtn.onClick.AddListener(() =>
            {
                NetWorkManager.Instance.ConnectToServerAsync("127.0.0.1", 20000, FantasyRuntime.NetworkProtocolType.KCP);
            });
        }
    }
}