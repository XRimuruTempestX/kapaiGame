using Fantasy;
using Fantasy.Async;
using UnityEngine;
using XLHFramework.GCFrameWork.Base;

namespace HallWorld
{
	public class GachaCarMessage : IMsgBehaviour
	{
		public void OnCreate()
		{

		}


		public async FTask<Gate2C_GachaCarResponse> SendGachaCarMessage(string account,int gachaCount)
		{
			return await Runtime.Session.C2Gate_GachaCarRequest(account, gachaCount);
		}

		public void OnDestroy()
		{

		}
	}
}
