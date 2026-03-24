using System;
using System.Collections.Generic;

namespace HotScrpts.ConfigData
{
    [Serializable]
    public class LevelConfig
    {
        public int levelID;                 // 关卡ID
        public string levelName;            // 关卡名称
        public int chapterID;               // 所属章节
        public int levelType;               // 关卡类型（0=普通）

        public List<int> UnlockCondition;   // 解锁条件（前置关卡ID）
        public List<int> enemys;            // 敌人ID列表

        public int rewards;                 // 奖励（后续建议改结构）
    }
}