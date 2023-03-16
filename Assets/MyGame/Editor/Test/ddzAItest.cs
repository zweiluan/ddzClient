using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sirenix.Utilities;
using ai=MyGame.ddzAI;
namespace MyGame
{
    public class ddzAItest
    {
        private Card[] allcards;
        private List<Card> cards;
        private List<CardGroup> ls;

        [SetUp]
        public void SetUp()
        {
            allcards = DdzUtility.CreatCards();
            cards = allcards.ToList();
            ls = new List<CardGroup>();
            
        }

        [Test]
        public void GetHuoJianTest1()
        {
            ai.GetHuoJian(ls,cards);
            Assert.AreEqual(cards.Count,52);
            Assert.AreEqual(ls.Count,1);
            Assert.AreEqual(ls[0].type,CardGroupType.huojian);
            Assert.AreEqual(ls[0].cards[0].id>52,true);
            Assert.AreEqual(ls[0].cards[1].id>52,true);
            Assert.AreEqual(ls[0].cards.Length,2);
            // Assert.AreEqual(ls[0].cards);
        }
        [Test]
        public void GetHuoJianTest2()
        {
            cards.Remove(cards.Find(c => c.id == 53));
            ai.GetHuoJian(ls,cards);
            Assert.AreEqual(cards.Count,53);
            Assert.AreEqual(ls.Count,0);
        }
        [Test]
        public void GetZhaDanTest1()
        {
            ai.GetZhaDan(ls,cards);
            Assert.AreEqual(cards.Count,2);
            Assert.AreEqual(ls.Count,13);
            foreach (var cg in ls)
            {
                Assert.AreEqual(cg.type,CardGroupType.zhadan);
                Assert.AreEqual(cg.cards.Length==4,true);
                Assert.AreEqual(cg.cards[0].Level==cg.cards[1].Level,true);
                Assert.AreEqual(cg.cards[0].Level==cg.cards[2].Level,true);
                Assert.AreEqual(cg.cards[0].Level==cg.cards[3].Level,true);
                
                Assert.AreEqual(cg.cards[0].id==cg.cards[1].id,false);
                Assert.AreEqual(cg.cards[0].id==cg.cards[2].id,false);
                Assert.AreEqual(cg.cards[0].id==cg.cards[3].id,false);
                
                Assert.AreEqual(cg.cards[1].id==cg.cards[2].id,false);
                Assert.AreEqual(cg.cards[1].id==cg.cards[3].id,false);
                Assert.AreEqual(cg.cards[2].id==cg.cards[3].id,false);
            }
        }
        [Test]
        public void GetZhaDanTest2()
        {
            cards.Remove(cards.Find(c => c.id == 12));
            ai.GetZhaDan(ls,cards);
            Assert.AreEqual(cards.Count,5);
            Assert.AreEqual(ls.Count,12);
            foreach (var cg in ls)
            {
                Assert.AreEqual(cg.type,CardGroupType.zhadan);
                Assert.AreEqual(cg.cards.Length==4,true);
                Assert.AreEqual(cg.cards[0].Level==cg.cards[1].Level,true);
                Assert.AreEqual(cg.cards[0].Level==cg.cards[2].Level,true);
                Assert.AreEqual(cg.cards[0].Level==cg.cards[3].Level,true);
                
                Assert.AreEqual(cg.cards[0].id==cg.cards[1].id,false);
                Assert.AreEqual(cg.cards[0].id==cg.cards[2].id,false);
                Assert.AreEqual(cg.cards[0].id==cg.cards[3].id,false);
                
                Assert.AreEqual(cg.cards[1].id==cg.cards[2].id,false);
                Assert.AreEqual(cg.cards[1].id==cg.cards[3].id,false);
                Assert.AreEqual(cg.cards[2].id==cg.cards[3].id,false);
            }
        }
        [Test]
        public void GetSanShunTest1()
        {
            cards.Remove(cards.Find(c => c.id == 12));
            cards.Remove(cards.Find(c => c.id == 25));
            //345678910j q ka
            ai.GetSanShun(ls,cards);
            //6+2+9+2
            Assert.AreEqual(cards.Count,6+2+9+2);
            Assert.AreEqual(ls.Count,2);
            Assert.AreEqual(ls[0].type,CardGroupType.sanshun);
            //3*9
            Assert.AreEqual(ls[0].cards.Length,27);
            Assert.AreEqual(ls[0].cards.First().Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[0].cards.Last().Level,(int)CardLevel.cj);
            Assert.AreEqual(ls[1].cards.Length,6);
            Assert.AreEqual(ls[1].cards.First().Level,(int)CardLevel.ck);
            Assert.AreEqual(ls[1].cards.Last().Level,(int)CardLevel.ca);
        }
        [Test]
        public void GetSanShunTest2()
        {
            // cards.Remove(cards.Find(c => c.id == 12));
            ai.GetSanShun(ls,cards);
            //6+12
            Assert.AreEqual(cards.Count,18);
            Assert.AreEqual(ls.Count,1);
            Assert.AreEqual(ls[0].type,CardGroupType.sanshun);
            //3*12
            Assert.AreEqual(ls[0].cards.Length,36);
            Assert.AreEqual(ls[0].cards[0].Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[0].cards[35].Level,(int)CardLevel.ca);
        }
        [Test]
        public void GetShuangShunTest1()
        {
            ai.GetShuangShun(ls,cards);
            
            Assert.AreEqual(cards.Count,6);
            Assert.AreEqual(ls.Count,2);
            Assert.AreEqual(ls[0].type,CardGroupType.shuangshun);
            //2*12
            Assert.AreEqual(ls[0].cards.Length,24);
            Assert.AreEqual(ls[0].cards[0].Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[0].cards[23].Level,(int)CardLevel.ca);
            
            Assert.AreEqual(ls[1].type==CardGroupType.shuangshun,true);
            //2*12
            Assert.AreEqual(ls[1].cards.Length,24);
            Assert.AreEqual(ls[1].cards[0].Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[1].cards[23].Level,(int)CardLevel.ca);
        }
        [Test]
        public void GetShuangShunTest2()
        {
            //qqj
            cards.Remove(cards.Find(c => c.id == 12));
            cards.Remove(cards.Find(c => c.id == 25));
            cards.Remove(cards.Find(c => c.id == 37));
            ai.GetShuangShun(ls,cards);
            //345678910j=>9 qka 6
            Assert.AreEqual(cards.Count,6+4+1);
            Assert.AreEqual(ls.Count,2);

            Assert.AreEqual(ls[0].type,CardGroupType.shuangshun);
            //2*12
            Assert.AreEqual(ls[0].cards.Length,24);
            Assert.AreEqual(ls[0].cards.First().Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[0].cards.Last().Level,(int)CardLevel.ca);
            
            Assert.AreEqual(ls[1].type==CardGroupType.shuangshun,true);
            //2*12
            Assert.AreEqual(ls[1].cards.Length,16);
            Assert.AreEqual(ls[1].cards.First().Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[1].cards.Last().Level,(int)CardLevel.c10);
        }

        [Test]
        public void GetDanShunTest1()
        {
            //345 789 jqka
            cards.Remove(cards.Find(c => c.id == 6));
            cards.Remove(cards.Find(c => c.id == 10));
            ai.GetDanShun(ls,cards);
            Assert.AreEqual(cards.Count,6+12-2);
            Assert.AreEqual(ls.Count,3);
            Assert.AreEqual(ls[0].type,CardGroupType.danshun);
            //1*12
            Assert.AreEqual(ls[0].cards.Length,12);
            Assert.AreEqual(ls[0].cards[0].Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[0].cards[11].Level,(int)CardLevel.ca);
        }
        [Test]
        public void GetDanShunTest2()
        {
            ai.GetDanShun(ls,cards);
            Assert.AreEqual(cards.Count,6);
            Assert.AreEqual(ls.Count,4);
            Assert.AreEqual(ls[0].type,CardGroupType.danshun);
            //1*12
            Assert.AreEqual(ls[0].cards.Length,12);
            Assert.AreEqual(ls[0].cards[0].Level,(int)CardLevel.c3);
            Assert.AreEqual(ls[0].cards[11].Level,(int)CardLevel.ca);
        }
        [Test]
        public void GetDanShunTest3()
        {
            cards = new List<Card>()
            {
                new Card(3),
                new Card(4+13),
                new Card(5),
                new Card(6+39),
                new Card(7+26),
                new Card(8+26),
                new Card(9),
                new Card(10+13),
            };
            ai.GetDanShun(ls,cards);
            Assert.AreEqual(cards.Count,0);
            Assert.AreEqual(ls.Count,1);
            Assert.AreEqual(ls.First().type,CardGroupType.danshun);
            //1*12
            Assert.AreEqual(ls.First().cards.Length,8);
            Assert.AreEqual(ls.First().cards.First().Level,(int)CardLevel.c3);
            Assert.AreEqual(ls.First().cards.Last().Level,(int)CardLevel.c10);
        }
        [Test]
        public void GetSanTest1()
        {
            ai.GetSan(ls,cards);
            Assert.AreEqual(cards.Count,15);
            Assert.AreEqual(ls.Count,13);
            
            foreach (var cg in ls)
            {
                Assert.AreEqual(cg.type,CardGroupType.sanzhang);
                Assert.AreEqual(cg.cards[0].Level, cg.cards[1].Level);
                Assert.AreEqual(cg.cards[0].Level, cg.cards[2].Level);
                Assert.AreEqual(cg.cards[1].Level, cg.cards[2].Level);
            }
        }
        [Test]
        public void GetSanTest2()
        {
            ai.GetSan(ls,cards);
            Assert.AreEqual(cards.Count,15);
            Assert.AreEqual(ls.Count,13);
            
            foreach (var cg in ls)
            {
                Assert.AreEqual(cg.type,CardGroupType.sanzhang);
                Assert.AreEqual(cg.cards[0].Level, cg.cards[1].Level);
                Assert.AreEqual(cg.cards[0].Level, cg.cards[2].Level);
                Assert.AreEqual(cg.cards[1].Level, cg.cards[2].Level);
            }
        }

        [Test]
        public void Get2Test1()
        {
            ai.Get2(ls,cards);
            Assert.AreEqual(cards.Count,2);
            Assert.AreEqual(ls.Count,26);
        }

        [Test]
        public void Get2Test2()
        {
            ai.Get2(ls,cards);
            Assert.AreEqual(cards.Count,2);
            Assert.AreEqual(ls.Count,26);
        }
        [Test]
        public void Get1Test1()
        {
            ai.Get1(ls,cards);
            Assert.AreEqual(cards.Count,0);
            Assert.AreEqual(ls.Count,54);
        }
        [Test]
        public void Get1Test2()
        {
            ai.Get1(ls,cards);
            Assert.AreEqual(cards.Count,0);
            Assert.AreEqual(ls.Count,54);
        }
    }
}