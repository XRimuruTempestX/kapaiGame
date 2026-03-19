using System;
using Fantasy;
using Fantasy.Async;
using JetBrains.Annotations;

namespace HotScrpts.NetWork
{
    public class NetWorkManager
    {
        private static NetWorkManager _instance;

        public static NetWorkManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NetWorkManager();
                }

                return _instance;
            }
        }

        private Action onConnectComplete;
        private Action onConnectFail;
        private Action onConnectDisconnect;

        public async FTask ConnectToServerAsync(string remoteIP,
            int remotePort,
            FantasyRuntime.NetworkProtocolType protocol,
            bool isHttps = false,
            int connectTimeout = 5000,
            bool enableHeartbeat = true,
            int heartbeatInterval = 2000,
            int heartbeatTimeOutInterval = 30000,
            int maxPingSamples = 5000,
            [CanBeNull] Action onConnectComplete = null,
            [CanBeNull] Action onConnectFail = null,
            [CanBeNull] Action onConnectDisconnect = null)
        {
            this.onConnectComplete = onConnectComplete;
            this.onConnectFail = onConnectFail;
            this.onConnectDisconnect = onConnectDisconnect;

            try
            {
                // 使用 Runtime.Connect() 静态方法连接服务器
                // 自动完成 Fantasy 框架初始化 + Scene 创建 + 网络连接
                var session = await Runtime.Connect(
                    remoteIP: remoteIP,
                    remotePort: remotePort,
                    protocol: protocol,
                    isHttps: isHttps,
                    connectTimeout: connectTimeout,
                    enableHeartbeat: enableHeartbeat,
                    heartbeatInterval: heartbeatInterval,
                    heartbeatTimeOut: heartbeatTimeOutInterval,
                    heartbeatTimeOutInterval: maxPingSamples,
                    maxPingSamples: 4,
                    onConnectComplete: OnConnectComplete,
                    onConnectFail: OnConnectFail,
                    onConnectDisconnect: OnConnectDisconnect
                );

            }
            catch (System.Exception ex)
            {
                Log.Error($"连接失败: {ex.Message}");
            }
        }

        private void OnConnectComplete()
        {
            Log.Info("连接成功回调");
            this.onConnectComplete?.Invoke();
        }

        private void OnConnectFail()
        {
            Log.Error("连接失败回调");
            this.onConnectFail?.Invoke();
        }

        private void OnConnectDisconnect()
        {
            Log.Warning("连接断开回调");
            this.onConnectDisconnect?.Invoke();
        }

        public void OnRelease()
        {
            Runtime.OnDestroy();
        }
    }
}