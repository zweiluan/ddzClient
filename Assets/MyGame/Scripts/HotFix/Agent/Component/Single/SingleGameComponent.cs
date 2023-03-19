using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyGame
{
    /// <summary>
    /// 玩家具备单局游戏的能力，
    /// 只负责要求玩家出牌，抢地主。通知游戏结束
    /// </summary>
    public class SingleGameComponent : AgentBaseComponent
    {
        public Card[] bottomCards;
        [ShowInInspector]
        private GameState _state;
        private Card[] _cards;
        // private BaseAgent[] _players => room.agents;
        private LinkedList<DdzComponent> _players;
        private LinkedListNode<DdzComponent> currentPlayer;
        private SingleRoomComponent room;
        /// <summary>
        /// 抢地主
        /// </summary>
        public void AskReqMaster()
        {
            currentPlayer.Value.UIData.CardShowMsg = "";
            currentPlayer.Value.UIData.TipMsg = "";
            GameEntry.Base.StartCoroutine(WaitFor1sToDo(() =>
            {
                currentPlayer.Value.ReqMaster(Play);
            }));
            // currentPlayer.Value.ReqMaster(Play);
        }
        /// <summary>
        /// 出牌的能力
        /// </summary>
        public void AskPlay()
        {
            currentPlayer.Value.UIData.CardShowMsg = "";
            currentPlayer.Value.UIData.TipMsg = "";
            room.RefreshUI();
            GameEntry.Base.StartCoroutine(WaitFor1sToDo(() =>
            {
                currentPlayer.Value.Play(Play);
            }));

        }

        void PreviousPlayer()
        {
            currentPlayer = currentPlayer.Next ?? _players.First;
            // currentPlayer = currentPlayer.Previous ?? _players.Last;
        }
        void NextPlayer()
        {
            // currentPlayer = currentPlayer.Next ?? _players.First;
            currentPlayer = currentPlayer.Previous ?? _players.Last;
        }

        public void ReStart()
        {
            _state = GameState.begin;
            int index = Random.Range(0, 3); //0-2
            currentPlayer = _players.First;
            //将当前玩家切换到第一位玩家
            for (int i = 0; i < index; i++)
            {
                NextPlayer();
            }
            //洗牌
            _cards = DdzUtility.AllCards.Shuffle();
            
            List<Card> extra =new List<Card>();
            List<Card>[] cardIndex =  {new(),new(),new() };

            //发牌
            for (int i = 0; i < _cards.Length; i++)
            {
                //三张底牌
                if (i<3)
                {
                    extra.Add(_cards[i]);
                }
                //每个玩家发牌
                else
                {
                    cardIndex[i%3].Add(_cards[i]);
                }
            }

            // room.roomData.Index[index].IsPeasant = false;
            for (int i = 0; i < room.roomData.Index.Length; i++)
            {
                cardIndex[i].Sort();
                cardIndex[i].Reverse();
                room.roomData.Index[i].CardHoldMsg=cardIndex[i].ToArray().CardsToString();
                room.roomData.Index[i].CardShowMsg = "";
                room.roomData.Index[i].Name = $"玩家{i+1}";
                room.roomData.Index[i].TipMsg = "";
                room.roomData.Index[i].IsPeasant = true;
                _players.ToList()[i].Begin(this,room.roomData.Index[i]);
            }

            room.roomData.ExtraCard = extra.ToArray().CardsToString();
            //发牌
            _state = GameState.req;
            _players.ToList().ForEach(c=>c.UIData.TipMsg="");
            bottomCards = null;
            AskReqMaster();
            room.RefreshUI();
        }
        public void Begin(SingleRoomComponent _room)
        {
            
            this.room = _room;
            _players = new LinkedList<DdzComponent>();
            _room.agents[0] = new AIAgent();
            _room.agents[0].AddComponent<AIComponent>();
            _room.agents[1] = new AIAgent();
            _room.agents[1].AddComponent<AIComponent>();
            _room.agents[2] = this.Agent;
            _room.agents[2].AddComponent<PlayerDdzComponent>();
            // foreach (var agent in _room.agents)
            for (int i = 0; i < _room.agents.Length; i++)
            {
                DdzComponent c = _room.agents[i].GetComponent<DdzComponent>();
                // Debug.Log($"组件获得成功？agent{agent.ID},{!(c==null)}");
                if (c==null)
                {
                    //todo 弹窗报错
                    return;
                }
                _players.AddLast(c);
                c.index = i;
            }
            Debug.Log("游戏开始");
            //判断头家
            ReStart();
            return;
        }

        IEnumerator  WaitFor1sToDo(Action action)
        {
            yield return new WaitForSeconds(1);
            action();
        }

        private bool HavePass = false;
        void Play(string st)
        {
            
            string msg;
            string arg;
            Debug.Log($"Gameplay 受到信息 {st} ");
            var s = st.Split("|");
            if (s.Length > 1)
            {
                msg = s[0];
                arg = s[1];
            }
            else
            {
                arg = s[0];
            }
            //判断当前状态，
            //如果是抢地主阶段
            if (_state==GameState.req)
            {
                Debug.Log("抢地主");
                int i=Int32.Parse(arg);
                //没抢过
                if (currentPlayer.Value.MasterValue == -1)
                {
                    Debug.Log($"{currentPlayer.Value.Name}抢地主{i}");
                    currentPlayer.Value.MasterValue = i;
                    currentPlayer.Value.UIData.TipMsg = currentPlayer.Value.MasterValue==0 ? "不要" : "抢地主";
                    room.RefreshUI();
                    NextPlayer();
                    if (currentPlayer.Value.MasterValue==-1)
                    {
                        Debug.Log($"{currentPlayer.Value.Name}没抢过地主，请{currentPlayer.Value.Name}抢地主");
                        AskReqMaster();
                    }//表示下一位玩家已经抢过地主了
                    else
                    {
                        Debug.Log($"{currentPlayer.Value.Name}抢过地主，判断是否能够产生地主");
                        CheckMaster();
                    }
                }
                //抢过,再抢，那么他就是地主
                else
                {
                    Debug.Log($"{currentPlayer.Value.Name}第二次抢过地主");
                    if (i!=0)
                    {
                        EnterPlayMode();
                       
                    }else
                    {
                        Debug.Log($"{currentPlayer.Value.Name}不要地主，检查是否可以产生地主");
                        currentPlayer.Value.MasterValue = i;
                        CheckMaster();
                    }
                }
            }

            else if (_state==GameState.play)
            {
                // return;
                if (arg=="pass")
                {
                    //如果有人pass，则过，说明这是第二次pass。
                    if (HavePass)
                    {
                        HavePass = false;
                        bottomCards = null;
                    }
                    else//第一次pass
                    {
                        HavePass = true;
                    }
                    // _players.ToList().ForEach(c=>c.UIData.CardShowMsg="");
                    currentPlayer.Value.UIData.CardShowMsg = "";
                    currentPlayer.Value.UIData.TipMsg = "要不起";
                    room.RefreshUI();
                    
                    // bottomCards = null;
                    NextPlayer();
                    AskPlay();
                }
                else
                {
                    HavePass = false;
                    //如果不是有效出牌
                    if (!DdzUtility.IsLegal(arg.StringToCards(),bottomCards))
                    {
                        Debug.Log("无效出牌");
                        AskPlay();
                        return;
                    }
                    bottomCards = arg.StringToCards();
                    var ls = currentPlayer.Value.UIData.CardHoldMsg.StringToCards().ToList();
                    foreach (var card in bottomCards)
                    {
                        ls.Remove(card);
                    }
                    currentPlayer.Value.handleCards = ls;
                    currentPlayer.Value.UIData.CardShowMsg = arg;
                    currentPlayer.Value.UIData.TipMsg = ddzAI.Split(arg.StringToCards()).First().type.ToString();
                    room.RefreshUI();
                    //如果合法，显示判断剩余卡牌数量是否为零。
                    if (currentPlayer.Value.handleCards.Count==0)
                    {
                        EndGame();
                    }
                    else
                    {
                        //显示UI、更新数据
                        NextPlayer();
                        AskPlay();
                    }
                }
                //如果牌型合法，则通知所有玩家
                   //如果玩家的手牌数为零，则游戏结束
                   //弹窗，继续游戏或者结束
                   //否则要求下一位玩家出牌
                //否则，重新要求玩家出牌，并通知，操作不合法
                //如果是出牌为空
                //要求上一位玩家出牌
            }
        }

        public string GetWinnerName()
        {
            StringBuilder st = new StringBuilder();
            _players.ToList().ForEach(player =>
            {
                if (player.UIData.IsPeasant==currentPlayer.Value.UIData.IsPeasant)
                {
                    st.Append($"{player.UIData.Name},");
                }
            });
            return st.ToString();
        }
        void EndGame()
        {
            bool k = currentPlayer.Value.UIData.IsPeasant;
            
            GameEntry.UI.OpenDialogUIMsg($"{GetWinnerName()}获胜");
            _state = GameState.end;
            Debug.Log("游戏结束");
            GameEntry.UI.OpenDialogUIMsg("游戏结束");
            GameEntry.Base.StartCoroutine(WaitFor1sToDo(()=>
            {
                //打开结束UI，询问玩家是否继续游戏，或者离开游戏
                GameEntry.UI.OpenCommandUI(new CommandParams()
                {
                    Mode = (int)CommandMode.end,
                    Action1 = (_) =>
                    {
#if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
#endif
                        Debug.Log("退出游戏"); 
                        Application.Quit();
                        //在子线程中无法生效？？
                        // GameEntry.UI.CloseCommandUI();
                    },
                    Action2 = (_) =>
                    {
                        GameEntry.UI.OpenDialogUIMsg("游戏重新开始");
                        ReStart();
                        GameEntry.UI.CloseCommandUI();
                    }
                });
            }));
        }

       
        void EnterPlayMode()
        {
            GameEntry.UI.OpenDialogUIMsg($"地主是{currentPlayer.Value.Name}");
            _state = GameState.play;
            List<Card> cards = currentPlayer.Value.handleCards;
            //将地主牌发给当前玩家
            cards.AddRange(room.roomData.ExtraCard.StringToCards());
            cards.Sort();
            cards.Reverse();
            currentPlayer.Value.handleCards = cards;
            //要求当前玩家出牌
            currentPlayer.Value.UIData.IsPeasant = false;
            Debug.Log($"{currentPlayer.Value.Name}要地主");
            _players.ToList().ForEach(c=>c.UIData.TipMsg="");
            room.RefreshUI();
            AskPlay();
        }
        public void CheckMaster()
        {
            Debug.Log("检查地主是否产生");
            int n = _players.ToList().FindAll(v => v.MasterValue > 0).Count;
            if (n==0)
            {
                GameEntry.UI.OpenDialogUIMsg($"无人抢地主，流局，即将重新开始");
                Debug.Log("没有人要地主，游戏重新开始");
                ReStart();
                return;
            }
            //将当前玩家设置为下一个抢到地主的玩家
            //如果只有一个玩家抢地主
            if (n==1)
            {
                Debug.Log("只有一个玩家要地主");
                
                while (currentPlayer.Value.MasterValue ==0)
                {
                    NextPlayer();
                }
                
                //进入play模式，并设置地主
                EnterPlayMode();
            }
            //如果超过一个玩家抢地主
            else
            {
                Debug.Log("不止一个玩家要地主");
                while (currentPlayer.Value.MasterValue ==0)
                {
                    NextPlayer();
                }
                AskReqMaster();
                //
            }
        }
        public override void Init()
        {
            //初始化一副卡组
            _cards = DdzUtility.AllCards.Shuffle();
        }

        public override void Update()
        {
        }

        public override void Destroy()
        {
        }
    }

    public enum GameState
    {
        begin,
        req,
        play,
        end
    }
}