using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyGame
{
    public class AIComponent : DdzComponent
    {
        protected bool reqM;

        IEnumerator Cb(Action action)
        {
            yield return new WaitForSeconds(1);
            action();
        }
        public override void ReqMaster(Action<string> callback)
        {
            Action ac;
            if (reqM)
            {
                if (handleCards.FindAll(c=>c.Level>(int)CardLevel.ca).Count>2)
                {
                    ac=()=>
                        callback($"机器人{Name}抢地主|3");
                }
                else
                {
                    reqM = false;
                     ac=()=>
                         callback($"机器人{Name}不抢地主|0");
                }
            }
            else
            {
                ac=()=>
                    callback($"机器人{Name}不抢地主|0");
            }

            // GameEntry.Base.StartCoroutine(Cb(ac));
            ac();
        }

        public override void Begin(Card[] cards,SingleGameComponent _game)
        {
            base.Begin(cards,_game);
            reqM = true;
            Debug.Log($"机器人{Agent.ID},获得手牌为{cards.CardsToString()}");
        }

        public override void Begin(SingleGameComponent _game, PlayerUIData playerData)
        {
            base.Begin(_game, playerData);
            reqM = true;
            Debug.Log($"机器人{playerData.Name},获得手牌为{playerData.CardHoldMsg}");
        }

        public override void Play(Action<string> callback)
        {

            Debug.Log(handleCards.ToArray().CardsToString());
            var ls = ddzAI.Split(handleCards.ToArray());
            if (game.bottomCards==null)
            {
                callback($"机器人出牌|{ls.Last().cards.CardsToString()}");
            }
            else
            {
                var bcards = ddzAI.Split(game.bottomCards.ToArray()).First();
                Debug.Log($"底牌类型是{bcards.type}");
                //给出底牌答案

                var cs = ls.Find(c =>
                {
                    if (c.type==CardGroupType.huojian)
                    {
                        return true;
                    }
                    if (c.type == CardGroupType.zhadan)
                    {
                        if (bcards.type == CardGroupType.zhadan)
                        {
                            if (bcards.max<c.max)
                            {
                                return true;
                            }
                        }
                        else if (bcards.type==CardGroupType.huojian)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    if (c.type == bcards.type && c.max > bcards.max)
                    {
                        if (c.cards.Length==bcards.cards.Length)
                        {
                            return true;
                        }
                    }
                    return false;
                });
                if (cs==null)
                {
                    callback($"机器人出牌|pass");
                }
                else
                {
                    callback($"机器人出牌|{cs.cards.CardsToString()}");
                }
            }
            //解析底牌信息
            
            // Action ac=()=> 
                
            // GameEntry.Base.StartCoroutine(Cb(ac));
        }

        
        public override void ShowCards()
        {
            //只展示剩余手牌数量
            
        }
    }
}