using Fantasy;
using Fantasy.Async;
using HotScrpts.NetWork;
using UnityEngine;
using XLHFramework.GCFrameWork.Base;

namespace HallWorld
{
	public class LoginLogic : ILogicBehaviour
	{
		
		
		private LoginMessage loginMessage;
		
		public void OnCreate()
		{
			loginMessage = HallWorld.GetExitsMsgMgr<LoginMessage>();
		}

		public async FTask RegisterAccount(string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				Debuger.LogError("账号密码不能为空！！！！");
				return;
			}
			
			//链接鉴权服务器
			NetWorkManager.Instance.ConnectToServerAsync("127.0.0.1", 20001, FantasyRuntime.NetworkProtocolType.KCP, onConnectComplete:
				async () =>
				{
					A2C_RegisterAccountResponse response = await loginMessage.RegisterAccount(username, password);
					if (response.ErrorCode == 0)
					{
						Debuger.LogGreen($"注册成功 userId = {response.userId}  account = {response.account}  password = {response.passWord}");
						return;
					}
			
					Debuger.LogError("注册失败！！ ===》》》》" + response.ErrorCode);
				}, onConnectFail: () =>
				{
					Debuger.LogError("鉴权服务器链接失败");
				},onConnectDisconnect: () =>
				{
					Debuger.LogError("鉴权服务器断开链接");
				});
			
			await FTask.CompletedTask;
		}

		public void OnDestroy()
		{

		}
	}
}
