using Cysharp.Threading.Tasks;
using Fantasy.Async;
using Newtonsoft.Json;
using UnityEngine;
using XLHFramework.GCFrameWork.Base;
using XUIFramework;

namespace HallWorld
{
	public class GachaCarLogic : ILogicBehaviour
	{
		
		private GachaCarMessage carMessage;
		
		public void OnCreate()
		{
			carMessage = HallWorld.GetExitsMsgMgr<GachaCarMessage>();
		}

		public async FTask SendCachaLogic(int count)
		{

			if (UserDataData.userData.diamond < 100 * count)
			{
				Debuger.LogRed($"砖石不足 {100 * count}");
				return;
			}
			
			var response = await carMessage.SendGachaCarMessage(UserDataData.userData.account, count);
			if (response.ErrorCode == 0)
			{
				//显示对应的UI
				string jsonMessage = JsonConvert.SerializeObject(response.userData);
				Debuger.LogRed(jsonMessage);
				GetHeroWindow heroWindow =  await UIManager.Instance.OpenWindowAsync<GetHeroWindow>();
				await UIManager.Instance.CloseWindow<RecruitWindow>();
				heroWindow.SetGainHeroList(response.getHeroList);
			}
			else
			{
				Debuger.LogRed("抽卡失败---->>> 金币不足");
			}
		}

		public void OnDestroy()
		{

		}
	}
}
