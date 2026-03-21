using Fantasy;
using Fantasy.Async;
using UnityEngine;
using XLHFramework.GCFrameWork.Base;

namespace HallWorld
{
	public class LoginMessage : IMsgBehaviour
	{
		public void OnCreate()
		{

		}

		/// <summary>
		/// 发送注册请求
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public async FTask<A2C_RegisterAccountResponse> SendRegisterAccount(string username, string password)
		{
			return await Runtime.Session.C2A_RegisterAccountRequest(account:username, passWord : password);
		}
		
		/// <summary>
		/// 发送登录请求
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public async FTask<A2C_LoginResponse> SendLogin(string username, string password)
		{
			return await Runtime.Session.C2A_LoginRequest(account:username, passWprd : password);
		}

		public async FTask<Gate2C_UserDataResponse> GetUserData(string account)
		{
			return await Runtime.Session.C2Gate_LoginRequest(account:account);
		}

		public void OnDestroy()
		{

		}
	}
}
