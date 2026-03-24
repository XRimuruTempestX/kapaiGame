using UnityEngine;
using XLHFramework.GCFrameWork.Base;

namespace HallWorld
{
	public class ChoosFormationLogic : ILogicBehaviour
	{
		
		private ChoosFormationData choosFormationData;
		
		public void OnCreate()
		{
			choosFormationData = HallWorld.GetExitsDataMgr<ChoosFormationData>();
		}
		/// <summary>
		/// 设置位置
		/// </summary>
		/// <param name="key"></param>
		public int SetHeroSeat(int heroId)
		{
			int seatKey = -1;
			foreach (var item in choosFormationData._SeatDic)
			{
				if (item.Value.state == 0)
				{
					seatKey =  item.Key;
					break;
				}
			}

			if (seatKey != -1)
			{
				choosFormationData._SeatDic[seatKey].heroId = heroId;
				choosFormationData._SeatDic[seatKey].state = 1;
			}
			
			return seatKey;
		}

		/// <summary>
		/// 从位置上下来
		/// </summary>
		/// <param name="key"></param>
		public int DownSeat(int heroId)
		{
			int key = -1;
			foreach (var item in choosFormationData._SeatDic)
			{
				if (item.Value.heroId == heroId)
				{
					key = item.Key;
					break;
				}
			}

			if (key != -1)
			{
				choosFormationData._SeatDic[key].state = 0;
				choosFormationData._SeatDic[key].heroId = 0;
			}
			return key;
		}
		public void OnDestroy()
		{

		}
	}
}
