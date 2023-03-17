using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirenix.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;


namespace MyGame
{
    public static class DdzUtility
    {
        private static  Card[] allCards;

        //全局单例亨元
        public static Card[] AllCards
        {
            get
            {
                if (allCards==null)
                {
                    allCards = CreatCards();
                }

                return allCards;
            }
            
        }

        public static Card GetCardById(int id)
        {
            // Debug.Log(id);
            return AllCards.ToList().Find(c=>c.id==id);
        }
        private static readonly Dictionary<int, string> cardDisplay=new Dictionary<int, string>()
        {
            
            {1,"A"},
            {2,"2"},
            {3,"3"},
            {4,"4"},
            {5,"5"},
            {6,"6"},
            {7,"7"},
            {8,"8"},
            {9,"9"},
            {10,"10"},
            {11,"J"},
            {12,"Q"},
            {13,"K"},

            {15,"<color=red>J\nO\nK\nE\nR</color>"},
            {14,"<color=black>J\nO\nK\nE\nR</color>"},
        };

        #region 数据获得
        public static string GetDisplaySt(int id)
        {
            
            return cardDisplay[id];
        }
        /// <summary>
        /// 获得花色
        /// </summary>
        /// <param name="id">序号</param>
        /// <returns>花色</returns>
        public static SuitType GetSuit(int id)
        {
            //13、26、39、52+2
            if (id<=13)
            {
                return SuitType.Diamond;
            }
            else if(id<=26)
            {
                return SuitType.Heart;
            }
            else if(id<=39)
            {
                return SuitType.Club;
            }
            else if(id<=52)
            {
                return SuitType.Spade;
            }
            else
            {
                return SuitType.Joker;
            }
            
        }
        /// <summary>
        /// 获得牌号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetDisplay(int id)
        {
            //345678910jqkA2
            if (id<=52)
            {
                return id % 13==0?13:id % 13;
            }
            else
            {
                return id - 39;
            }

        }

        public static Card[] StringToCards(this string st,string separator=",")
        {
            string[] lst = st.Split(separator);
            List<int> lint = new List<int>();
            lst.ForEach(s =>
            {
                int i;
                if (int.TryParse(s,out i))
                {
                    lint.Add(i);
                }
            });
            Card[] cards = new Card[lint.Count];
            for (int i = 0; i < lint.Count; i++)
            {
                cards[i] = GetCardById(lint[i]);
            }
            return cards;
        }

        public static string CardsToString(this Card[] cards,string separator=",")
        {
            StringBuilder st = new StringBuilder();
            foreach (var card in cards)
            {
                st.Append(card.id.ToString());
                st.Append(separator);
            }

            return st.ToString();
        }
        /// <summary>
        /// 卡pain的级别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetLevel(int id)
        {
            int display = GetDisplay(id);
            if (display<=2)
            {
                return display + 13;
            }else if (display<=13)
            {
                return display;
            }
            else
            {
                return display + 2;
            }
        }
        //如果要实现规则配表的话，可能会比较麻烦
        public static CardType GetCardType(Card[] cards)
        {
            Card[] _cards = Sort(cards);
            if (cards.Length==1)
            {
                return CardType.dan;
            }else if (cards.Length==2)
            {
                if (IsWangZha(cards))
                {
                    return CardType.wangzha;
                }

                if (IsDuizi(cards))
                {
                    return CardType.duizi;
                }
            }
            else if (cards.Length==4)
            {
                if (IsZha(cards))
                {
                    return CardType.zha;
                }

                if (IsSanDaiYi(cards))
                {
                    return CardType.sandaiyi;
                }
            }else
            {
                if (IsShunzi(cards))
                {
                    return CardType.shunzi;
                }

                if (IsLiandui(cards))
                {
                    return CardType.liandui;
                }
            }
            
            return CardType.nil;
        }

        #endregion

        #region 基础函数
        public static Card[] CreatCards()
        {
            List<Card> cards=new List<Card>();
            for (int i = 0; i < 54; i++)
            {
                cards.Add(new Card(i+1));
            }

            return cards.ToArray();
        }

        public static void Sort(ref Card[] cards)
        {
            cards.Sort();
        }

        public static Card[] Shuffle(this Card[] cards)
        {
            var cs = cards.Clone() as Card[];
            for (int i = 0; i < cs.Length; i++)
            {
                int x = Random.Range(0, cs.Length);
                (cs[i], cs[x]) = (cs[x], cs[i]);
            }

            return cs;
        }
        public static Card[] Sort(Card[] cards)
        {
            Card[] _cards = cards;
            Sort(ref _cards);
            return _cards;
        }
        

        #endregion


        #region 牌型判断

        public static bool IsLegal(CardGroup cards, CardGroup bottomCards)
        {
            if (cards.type==CardGroupType.huojian)
            {
                return true;
            }

            if (cards.type==CardGroupType.zhadan)
            {
                if (bottomCards.type>cards.type)
                {
                    return true;
                }
            }
            else
            {
                if (bottomCards.type==cards.type&&bottomCards.max<cards.max)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsLegal(CardGroup cards, Card[] bottomCards)
        {
            var l = ddzAI.Split(bottomCards);
            if (bottomCards==null||bottomCards.Length==0)
            {
                return true;
            }
            return IsLegal(cards, l.First());
        }
        public static bool IsLegal(Card[] cards,Card[] bottomCards)
        {
            if (cards==null||cards.Length==0)
            {
                return false;
            }
            var l1 = ddzAI.Split(cards);
            if (l1.Count != 1)
            {
                return false;
            }
            if (bottomCards==null||bottomCards.Length==0)
            {
                return true;
            }
            var l2 = ddzAI.Split(bottomCards);
            
            return IsLegal(l1.First(), l2.First());
        }
        public static bool IsDan(Card[] cards)
        {
            if (cards.Length==1)
            {
                return true;
            }
            return false;
        }
        public static bool IsDuizi(Card[] cards)
        {
            if (cards.Length==2)
            {

                if (cards[0].Display == cards[1].Display && cards[0].Suit!=SuitType.Joker)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsWangZha(Card[] cards)
        {
            if (cards.Length==2)
            {
                foreach (var card in cards)
                {
                    if (card.Suit != SuitType.Joker)
                    {
                        return false;
                    }
                }

                return true;
            }
            
            return false;
        }
        
        public static bool IsZha(Card[] cards)
        {
            if (cards.Length==4)
            {
                int display = cards[0].Display;
                foreach (var card in cards)
                {
                    if (card.Display!=display)
                    {
                        return false;
                    }
                }

                return true;
            }
            return false;
        }
        
        public static bool IsShunzi(Card[] cards)
        {
            if (cards.Length>=5)
            {
                
            }
            return false;
        }
        
        public static bool IsLiandui(Card[] cards)
        {
            if (cards.Length>=6)
            {
                
            }
            return false;
        }
        public static bool IsSanDaiYi(Card[] cards)
        {
            if (cards.Length==4)
            {
                Card c1=cards[0];
                Card c2=null;
                int n1=0;
                int n2=0;
                foreach (var card in cards)
                {
                    if (card.Display==c1.Display)
                    {
                        n1++;
                        continue;
                    }
                    else 
                    {
                        if (c2==null)
                        {
                            c2 = card;
                            n2 ++;
                            continue;
                        }
                        else
                        {
                            if (card.Display==c2.Display)
                            {
                                n2 ++;
                                continue;
                            }
                            else//第三种花色
                            {
                                return false;
                            }
                        }
                    }

                }

                if (n1==3||n2==3)
                {
                    return true;
                }
            }
            return false;
        }
        

        #endregion
        
        
    }

    public enum SuitType
    {
        /// <summary>
        /// 方块
        /// </summary>
        Diamond=1,
        /// <summary>
        /// 红心
        /// </summary>
        Heart=2,
        /// <summary>
        /// 梅花
        /// </summary>
        Club=3,
        /// <summary>
        /// 黑桃
        /// </summary>
        Spade=4,
        /// <summary>
        /// 王
        /// </summary>
        Joker=5,
        Null=6,
        
    }

    public enum CardLevel
    {
        c3=3,
        c4=4,
        c5=5,
        c6=6,
        c7=7,
        c8=8,
        c9=9,
        c10=10,
        cj=11,
        cq=12,
        ck=13,
        ca=14,
        c2=15,
        cjokerl=16,
        cjoker=17,
    }
   
    public enum CardType
    {
        dan=1,
        duizi=2,
        wangzha=3,
        zha=4,
        shunzi=5,
        sandaiyi=7,
        liandui=8,
        nil=9
    }
}