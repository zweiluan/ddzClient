using System;
using UnityEngine;

namespace MyGame
{
    public class Card : IComparable<Card>
    {
        public int Level => DdzUtility.GetLevel(id);
        public int Display => DdzUtility.GetDisplay(id);
        public readonly int id;
        [HideInInspector]
        public SuitType Suit => DdzUtility.GetSuit(id);
        public Card(int id)
        {
            this.id = id;
        }
        
        public int CompareTo(Card other)
        {
            if (this.Level==other.Level)
            {
                if (this.Suit>other.Suit)
                {
                    return 1;
                }

                if (this.Suit<other.Suit)
                {
                    return -1;
                }
                return 0;
            }
        
            if (this.Level>other.Level)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

    }
}