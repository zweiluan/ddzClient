using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace MyGame
{
    public class RoomParams
    {
        public RoomParams()
        {
            Index1 = new PlayerUIData();
            Index2 = new PlayerUIData();
            Index3 = new PlayerUIData();
            Index = new[] { Index1, Index2, Index3 };
            ExtraCard = "1,1,1";
        }

        public PlayerUIData[] Index;
        public PlayerUIData Index1
        {
            get;
            set;
        }
        public PlayerUIData Index2
        {
            get;
            set;
        }
        public PlayerUIData Index3
        {
            get;
            set;
        }

        public string ExtraCard
        {
            get;
            set;
        }
    }

    public class PlayerUIData
    {
        public PlayerUIData()
        {
            CardHoldMsg = "1,2,3,4,5,6";
            CardShowMsg = "1,2,3,4,5,6";
            Name = "Name";
            Score = 999;
            IsPeasant = true;
            TipMsg = "";
        }

        [ShowInInspector]
        public string TipMsg
        {
            get;
            set;
        }
        [ShowInInspector]
        /// <summary>
        /// 出牌信息
        /// </summary>
        public string CardShowMsg
        {
            get;
            set;
        } 
        [ShowInInspector]
        /// <summary>
        /// 持有手牌的信息
        /// </summary>
        public string CardHoldMsg
        {
            get;
            set;
        } 
        [ShowInInspector]
        /// <summary>
        /// 玩家名字
        /// </summary>
        public string Name
        {
            get;
            set;
        } 
        [ShowInInspector]
        /// <summary>
        /// 玩家分数
        /// </summary>
        public int Score
        {
            get;
            set;
        }
        [ShowInInspector]
        public bool IsPeasant
        {
            get;
            set;
        }
    }
}