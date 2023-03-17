using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MyGame
{
    /// <summary>
    /// 核心打牌逻辑,基于回调
    /// </summary>
    public abstract class DdzComponent : AgentBaseComponent
    {
        [ShowInInspector]
        public PlayerUIData UIData { get; set; }
        public string Name => UIData?.Name;
        [ShowInInspector]
        protected Card[] bottomCards => game?.bottomCards;

        public int MasterValue { get; set; }
        public int index { get; set; }
        protected SingleGameComponent game;
        protected SingleRoomComponent room;
        //持有手牌
        public List<Card> handleCards
        {
            get => UIData.CardHoldMsg.StringToCards().ToList();
            set => UIData.CardHoldMsg = value.ToArray().CardsToString();
        }
        //抢地主
        public abstract void ReqMaster(Action<string> callback);
        //打牌
        public abstract void Play(Action<string> callback);
        
        //重置
        public virtual void Begin(Card[] cards,SingleGameComponent _game)
        {
            MasterValue = -1;
            this.game = _game;
            handleCards = cards.ToList();
        }
        public virtual void Begin(SingleGameComponent _game,PlayerUIData playerData)
        {
            MasterValue = -1;
            this.game = _game;
            UIData = playerData;
            Debug.Log($"{playerData.Name}初始化");
        }

        public virtual void RemoveCards(Card[] cards)
        {
            foreach (var card in cards)
            {
                handleCards.Remove(card);
            }
        }
        public override void Init()
        {
            base.Init();
            room = Agent.GetComponent<SingleRoomComponent>();
        }
        public abstract void ShowCards();
    }
    
}