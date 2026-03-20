using Fantasy;
using Fantasy.Async;
using HotScrpts.NetWork;
using UnityEngine;
using XAsset.Runtime;
using XLHFramework.GCFrameWork.Base;
using XUIFramework;

namespace HallWorld
{
	public class LoginLogic : ILogicBehaviour
	{
		
		
		private LoginMessage loginMessage;
		
		public void OnCreate()
		{
			loginMessage = HallWorld.GetExitsMsgMgr<LoginMessage>();
		}
		
		/// <summary>
		/// 注册
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
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
					A2C_RegisterAccountResponse response = await loginMessage.SendRegisterAccount(username, password);
					if (response.ErrorCode == 0)
					{
						Debuger.LogGreen($"注册成功 userId = {response.userId}  account = {response.account}  password = {response.passWord}");
						Runtime.Session.Dispose();
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

		public async FTask Login(string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				Debuger.LogError("账号密码不能为空！！！！");
				return;
			}
			
			NetWorkManager.Instance.ConnectToServerAsync("127.0.0.1", 20001, FantasyRuntime.NetworkProtocolType.KCP, onConnectComplete:
				async () =>
				{
					A2C_LoginResponse response = await loginMessage.SendLogin(username, password);
					if (response.ErrorCode == 0)
					{
						Debuger.LogGreen("登录成功！");
						Runtime.Session.Dispose();
						//连接Gate服务器
						ConnetGateServer(response.gateIp,response.gatePor);
						return;
					}
			
					Debuger.LogError("登录失败！！ ===》》》》" + response.ErrorCode);
				}, onConnectFail: () =>
				{
					Debuger.LogError("鉴权服务器链接失败");
				},onConnectDisconnect: () =>
				{
					Debuger.LogError("鉴权服务器断开链接");
				});
			
			await FTask.CompletedTask;
			
		}

		private async FTask ConnetGateServer(string gateIp, int gatePort)
		{
			NetWorkManager.Instance.ConnectToServerAsync(gateIp, gatePort, FantasyRuntime.NetworkProtocolType.KCP,onConnectComplete:
				async () =>
				{
					Debuger.LogError("Gate服务器链接成功");
					UIManager.Instance.DestroyAllWindows();
					XAssetFrameWork.Instance.ReleaseAllAssets(false);
					//弹出大厅
					await UIManager.Instance.OpenWindowAsync<HallWindow>();
					await UIManager.Instance.OpenWindowAsync<HallButtonsWidow>();
				},onConnectDisconnect: () =>
				{
					Debuger.LogError("Gate服务器断开链接");
				},onConnectFail: () =>
				{
					Debuger.LogError("Gate服务器链接失败");
				});
		}

		public void OnDestroy()
		{

		}
	}
}
