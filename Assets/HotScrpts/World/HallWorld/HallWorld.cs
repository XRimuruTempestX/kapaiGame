using Cysharp.Threading.Tasks;
using HotScrpts.Tools;
using UnityEngine;
using XLHFramework.GCFrameWork.World;

namespace HallWorld
{
	public class HallWorld : World
	{
		public override void OnCreate()
		{
			ConfigCenter.Instance.LoadCharacterConfigData().Forget();
		}

		public override void OnDestroy()
		{

		}
	}
}
