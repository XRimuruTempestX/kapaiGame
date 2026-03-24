using System.Collections.Generic;
using UnityEngine;
using XLHFramework.GCFrameWork.Base;

namespace HallWorld
{

	public class SeatHero
	{
		public int state;
		public int heroId;
	}
	
	public class ChoosFormationData : IDataBehaviour
	{
		
		public Dictionary<int,SeatHero> _SeatDic = new Dictionary<int,SeatHero>();
		
		public void OnCreate()
		{
			_SeatDic.Add(0,new  SeatHero(){state=0,heroId=0});
			_SeatDic.Add(1,new  SeatHero(){state=0,heroId=0});
			_SeatDic.Add(2,new  SeatHero(){state=0,heroId=0});
			_SeatDic.Add(3,new  SeatHero(){state=0,heroId=0});
			_SeatDic.Add(4,new  SeatHero(){state=0,heroId=0});
		}



		

		public void OnDestroy()
		{

		}
	}
}
