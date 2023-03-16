using System.Collections.Generic;
using System.Linq;
using GameFramework;

namespace MyGame
{
    /// <summary>
    /// 核心逻辑是，将手牌拆分为多个连队组合。
    /// 对于剩下的卡牌进行分组，直到所有的分组完成，每个分组有自己权重。面对地方卡组，只有权重大于一定时，才会出，否则不出
    /// 1、炸弹  100+Max
    /// 2、顺子  10*n+Max
    /// 3、6+2  80+Max
    /// 4、3+1  3*Max
    /// 5、4+2  100+Max
    /// 6、对子  2*Max
    /// 7、对于单张牌，从大到小排 Max
    /// 出牌权重
    /// 如果牌很多，先出张数多的组合
    /// 如果只剩下一张单牌，则最后出。如果有多张单牌，优先打出小的单牌
    /// 吃牌权重
    /// 只出手里有的卡组
    /// </summary>
    public class ddzAI
    {
        /// <summary>
        /// 将手牌拆分为具有权重的卡牌分组
        /// </summary>
        public static List<CardGroup> Split(Card[] cards)
        {
            var ls = new List<CardGroup>();
            var remain = new List<Card>();
            if (cards!=null)
            {
                foreach (var card in cards)
                {
                    remain.Add(card);
                }
            }
            //剔除火箭
            GetHuoJian(ls,remain);
            //小-大
            //剔除炸弹
            GetZhaDan(ls, remain);
            //小-大
            //剔除三顺
            GetSanShun(ls,remain);
            //剔除双顺
            GetShuangShun(ls,remain);
            //剔除单顺
            GetShuangShun(ls,remain);
            GetDanShun(ls,remain);
            //小-大
            //剔除三张
            GetSan(ls,remain);
            //小-大
            Get2(ls,remain);
            //小-大
            Get1(ls,remain);
            //三顺加翅膀
            //三张加翅膀
            //炸弹加翅膀
            return ls;
        }
        //findall,性能消耗比较大，更好的办法是，全部排序后，再通过排序组去获得
        //findAll是n，排序后查询是1
        #region 牌组拆分
        public static void GetHuoJian(List<CardGroup> ls,List<Card> cards)
        {
            if (cards==null)
            {
                return ;
            }
            if (cards.Count<2)
            {
                return ;
            }
            if (cards.Exists(c=>c.id==54) && cards.Exists(c=>c.id==53))
            {
                var cs = ReferencePool.Acquire<CardGroup>();
                cs.type = CardGroupType.huojian;
                cs.cards = new Card[2];
                cs.cards[0] = cards.Find(c => c.id == 54);
                cs.cards[1]=cards.Find(c => c.id == 53);
                cs.max = cs.cards.First().Level;
                foreach (var card in cs.cards)
                {
                    cards.Remove(card);
                }
                ls.Add(cs);
 
            }

        }
        public static void GetZhaDan(List<CardGroup> ls,List<Card> cards)
        {
            if (cards==null)
            {
                return ;
            }
            if (cards.Count<4)
            {
                return ;
            }

            for (int i = (int)CardLevel.c2; i >= (int)CardLevel.c3; i--)
            {
                var l= cards.FindAll(c => c.Level == i);
                if (l.Count==4)
                {
                    var cs=ReferencePool.Acquire<CardGroup>();
                    cs.type = CardGroupType.zhadan;
                    cs.max = l.First().Level;
                    cs.cards = l.ToArray();
                    ls.Add(cs);
                    foreach (var card in l)
                    {
                        cards.Remove(card);
                    }

                }
            }

        }
        public static void GetSanShun(List<CardGroup> ls,List<Card> cards)
        {

            //
            if (cards==null)
            {
                return;
            }
            if (cards.Count<6)
            {
                return;
            }
            bool have = false;
            //34=>ka
            //=>3-13
            
            for (int i = (int)CardLevel.c3; i <= (int)CardLevel.ck; i++)
            {
                var l1= cards.FindAll(c => c.Level == i);
                if (l1.Count>=3)
                {
                    var l2 = cards.FindAll(c => c.Level == i + 1);
                    if (l2.Count>=3)
                    {
                        var l = new List<Card>();
                        for (int j = 0; j < 3; j++)
                        {
                            l.Add(l1[j]);
                            l.Add(l2[j]);
                        }
                        //尝试继续往后查询
                        int x = 2;
                        bool have1=true;
                        //如果上一个有，才查询下一个，同时查询的level应小于2的level
                        while (have1&&(i+x)<(int)CardLevel.c2)
                        {
                            have1 = false;
                            var l4 = cards.FindAll(c => c.Level == i + x);
                            if (l4.Count>=3)
                            {
                                l.Add(l4[0]);
                                l.Add(l4[1]);
                                l.Add(l4[2]);
                                have1 = true;
                            }
                            x++;
                        }
                        var cs = ReferencePool.Acquire<CardGroup>();
                        cs.type = CardGroupType.sanshun;
                        cs.cards = l.ToArray();
                        cs.max = l.Last().Level;
                        ls.Add(cs);
                        foreach (var card in cs.cards)
                        {
                            cards.Remove(card);
                        }
                        have = true;
                        break;
                    }
                }
            }

            if (have)
            {
                GetSanShun(ls,cards);

            }
        }
        public static void GetShuangShun(List<CardGroup> ls,List<Card> cards)
        {
            if (cards==null)
            {
                return;
            }
            if (cards.Count<6)
            {
                return;
            }
            //345=>qka
            //=>3-12
            bool have = false;
            for (int i = (int)CardLevel.c3; i <= (int)CardLevel.cq; i++)
            {
                var l1= cards.FindAll(c => c.Level == i);
                if (l1.Count>=2)
                {
                    var l2 = cards.FindAll(c => c.Level == i + 1);
                    var l3 = cards.FindAll(c => c.Level == i + 2);
                    if (l2.Count>=2&&l3.Count>=2)
                    {
                        var l = new List<Card>();
                        for (int j = 0; j < 2; j++)
                        {
                            l.Add(l1[j]);
                            l.Add(l2[j]);
                            l.Add(l3[j]);
                        }
                        //尝试继续往后查询
                        int x = 3;
                        bool have1=true;
                        //如果上一个有，才查询下一个，同时查询的level应小于2的level
                        while (have1&&(i+x)<(int)CardLevel.c2)
                        {
                            have1 = false;
                            var l4 = cards.FindAll(c => c.Level == i + x);
                            if (l4.Count>=2)
                            {
                                l.Add(l4[0]);
                                l.Add(l4[1]);
                                have1 = true;
                            }
                            x++;
                        }
                        
                        var cs = ReferencePool.Acquire<CardGroup>();
                        cs.type = CardGroupType.shuangshun;
                        cs.cards = l.ToArray();
                        cs.max = l.Last().Level;
                        ls.Add(cs);
                        foreach (var card in cs.cards)
                        {
                            cards.Remove(card);
                        }
                        //如果查询到，就再查询一次
                        have = true;
                        break;
                    }
                }
            }

            if (have)
            {
                GetShuangShun(ls, cards);
            }
        }
        public static void GetDanShun(List<CardGroup> ls,List<Card> cards)
        {
            
            if (cards==null)
            {
                return;
            }
            if (cards.Count<5)
            {
                return;
            }
            bool have = false;
            //34567=>10jqka
            //=>3=>10
            //12张
            for (int i = (int)CardLevel.c3; i <= (int)CardLevel.c10; i++)
            {
                var l = new List<Card>();
                for (int j = 0; j < 5; j++)
                {
                    var l1 = cards.FindAll(c => c.Level == (i + j));
                    if (l1.Count>0)
                    {
                        l.Add(l1[0]);
                        
                    }
                    else
                    {
                        //如果没有，则清空，查询下一个
                        l.Clear();
                        break; 
                    }
                    
                }
                //如果便利下来，存够了5个数，则说明，数量够了。那么就可以查询后面的
                if (l.Count==5)
                {
                    int x = 5;
                    bool have1=true;
                    //如果上一个有，才查询下一个，同时查询的level应小于2的level
                    while (have1&&(i+x)<(int)CardLevel.c2)
                    {
                        have1 = false;
                        var l4 = cards.FindAll(c => c.Level == i + x);
                        if (l4.Count>0)
                        {
                            l.Add(l4[0]);
                            have1 = true;
                        }
                        x++;
                    }
                    var cs = ReferencePool.Acquire<CardGroup>();
                    cs.type = CardGroupType.danshun;
                    cs.cards = l.ToArray();
                    cs.max = l.Last().Level;
                    ls.Add(cs);
                    foreach (var card in l)
                    {
                        cards.Remove(card);
                    }

                    have = true;
                    break;
                    //如果查询到，就再查询一次

                }
                
            }

            if (have)
            {
                GetDanShun(ls, cards);
            }
        }

        public static void GetSan(List<CardGroup> ls, List<Card> cards)
        {
            if (cards==null)
            {
                return;
            }
            if (cards.Count<3)
            {
                return;
            }
            for (int i = (int)CardLevel.c2; i >= (int)CardLevel.c3; i--)
            {
                var l= cards.FindAll(c => c.Level == i);
                if (l.Count>=3)
                {
                    var cs=ReferencePool.Acquire<CardGroup>();
                    cs.type = CardGroupType.sanzhang;
                    cs.cards = new Card[]
                    {
                        l[0],
                        l[1],
                        l[2]
                    };
                    cs.max = l.First().Level;
                    ls.Add(cs);
                    foreach (var card in cs.cards)
                    {
                        cards.Remove(card);
                    }
                }
            }
        }
        public static void Get2(List<CardGroup> ls,List<Card> cards)
        {
            bool have = false;
            if (cards==null)
            {
                return;
            }
            if (cards.Count<2)
            {
                return;
            }
            //3=>2
            for (int i = (int)CardLevel.c2; i >= (int)CardLevel.c3; i--)
            {
                var l = cards.FindAll(c => c.Level == i);
                if (l.Count>=2)
                {
                    var cs=ReferencePool.Acquire<CardGroup>();
                    cs.type = CardGroupType.duizi;
                    cs.cards = new Card[]
                    {
                        l[0],
                        l[1]
                    };
                    cs.max = l.First().Level;
                    ls.Add(cs);
                    foreach (var card in cs.cards)
                    {
                        cards.Remove(card);
                    }

                    have = true;
                }
            }

            if (have)
            {
                Get2(ls, cards);
            }
        }
        public static void Get1(List<CardGroup> ls,List<Card> cards)
        {
            if (cards==null)
            {
                return;
            }
            if (cards.Count<1)
            {
                return;
            }
            foreach (var card in cards)
            {
                var cs = ReferencePool.Acquire<CardGroup>();
                cs.type = CardGroupType.danzhang;
                cs.cards = new Card[] { card };
                cs.max = card.Level;
                ls.Add(cs);
            }
            cards.Clear();
        }
        

        #endregion

    }

    #region 申明
    public class CardGroup : IReference
    {
        public CardGroupType type;
        public int max;
        public Card[] cards;
        public void Clear()
        {
            type = CardGroupType.nil;
            cards = null;
        }
    }
    
    public enum CardGroupType
    {
        nil=0,
        huojian=1,
        zhadan=2,
        sanshun=3,
        shuangshun=4,
        danshun=5,
        sanzhang=6,
        duizi=7,
        danzhang=8,
    }
    #endregion
    


}