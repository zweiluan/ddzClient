using System.Linq;
using NUnit.Framework;


namespace MyGame
{
    public class DDZrulesTest
    {
        [Test]
        public void GetSuitTest()
        {
            Assert.IsTrue(true);
            Assert.AreEqual(DdzUtility.GetSuit(31), SuitType.Club);
            Assert.AreEqual(DdzUtility.GetSuit(54), SuitType.Joker);
        }
        [Test]
        public void GetDisplayTest()
        {
            Assert.AreEqual(DdzUtility.GetDisplay(53), 14);
            Assert.AreEqual(DdzUtility.GetDisplay(54), 15);
            Assert.AreEqual(DdzUtility.GetDisplay(13), 13);
        }
        [Test]
        public void GetLevelTest()
        {
            Assert.AreEqual(DdzUtility.GetLevel(54),17);
            Assert.AreEqual(DdzUtility.GetLevel(53),16);
            Assert.AreEqual(DdzUtility.GetLevel(1),14);
            Assert.AreEqual(DdzUtility.GetLevel(2),15);
        }
        [Test]
        public void GetAllCardsTest()
        {

        }
        [Test]
        public void IsSanDaiYiTest()
        {
            Assert.IsTrue(DdzUtility.IsSanDaiYi(new []
            {
                new Card(1),
                new Card(1),
                new Card(2),
                new Card(1),
            }));
            Assert.IsFalse(DdzUtility.IsSanDaiYi(new []
            {
                new Card(1),
                new Card(3),
                new Card(2),
                new Card(1),
            }));
            Assert.IsFalse(DdzUtility.IsSanDaiYi(new []
            {
                new Card(1),
                new Card(1),
                new Card(2),
                new Card(2),
            }));
            Assert.IsTrue(DdzUtility.IsSanDaiYi(new []
            {
                new Card(2),
                new Card(2),
                new Card(2),
                new Card(1),
            }));
        }
        [Test]
        public void SortTest()
        {
            Card card1=new Card(1);//A
            Card card2=new Card(2);
            Card card3=new Card(3);
            Card card54=new Card(54);//大王
            Card card53=new Card(53);//小王
            Card card27=new Card(27);
            Card card28=new Card(28);
            Card card29 = new Card(29);//3
            Card card31=new Card(31); //5
            Assert.AreEqual(DdzUtility.Sort(new Card[]{card1,card2,card3}),new Card[]{card3,card1,card2});
            Assert.AreEqual(DdzUtility.Sort(new Card[]{card1,card2,card3,card3}),new Card[]{card3 ,card3,card1,card2});
            Assert.AreEqual(DdzUtility.Sort(new Card[]{card2,card1,card2,card3}),new Card[]{card3,card1,card2,card2});
            Assert.AreEqual(DdzUtility.Sort(new Card[]{card1,card2,card1,card3}),new Card[]{card3,card1,card1,card2});
            Assert.AreEqual(DdzUtility.Sort(new Card[]{card1,card2,card3,card31,card53,card54,card27,card28,card29}),new Card[]{card3,card29,card31,card1,card27,card2,card28,card53,card54});
            
        }
        [Test]
        public void String2CardTest()
        {
            string st = "1,2,3,4,5,6,7,11,34,39";
            Card[] cards = DdzUtility.StringToCards(st);
            Assert.AreEqual(cards.Length,10);
            Assert.AreEqual(cards.First().id,1);
            Assert.AreEqual(cards.Last().id,39);
        }
        [Test]
        public void Card2StringTest()
        {
            string st = "1,2,3,4,5,6,7,11,34,39,";

            Card[] card1 = new[]
            {
                new Card(1),
                new Card(2),
                new Card(3),
                new Card(4),
                new Card(5),
                new Card(6),
                new Card(7),
                new Card(11),
                new Card(34),
                new Card(39),
            };
            string s = DdzUtility.CardsToString(card1);
            Assert.AreEqual(s,st);

        }
    }
}