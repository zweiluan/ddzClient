using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class CardShow : MonoBehaviour
    {
        // [ReadOnly]
        public bool _haveLayoutGroup;
        [HideIf("_haveLayoutGroup")]
        public int offset;
        [HideIf("_haveLayoutGroup")]
        public float rootoffset;
        public CardUnit prefab;
        public Sprite[] suitSprite=new Sprite[5];
        // [Range(1,20)]
        // public int cardNum=13;
        [ReadOnly]
        public List<CardUnit> onSelectingCards;
        [HideInInspector]
        public bool CanSelect=false;

        [ReadOnly]
        /// <summary>
        /// 持有的卡
        /// </summary>
        private CardUnit[] cards;

        private Card[] cacheCards;
        [ReadOnly]
        private Stack<CardUnit> cardpool;

        public string GetSelectedCards()
        {
            List<Card> cs = new List<Card>();
            cards.ToList().ForEach(c =>
            {
                if (c.Selected)
                {
                    cs.Add(c.cacheCard);
                }
            });
            return cs.ToArray().CardsToString();
        }

        public void SetSelectedCards(string st)
        {
            var cs = st.StringToCards();
            cs.ToList().ForEach(c =>
            {
                cards.ToList().ForEach(cu =>
                {
                    if (cu.cacheCard.id==c.id)
                    {
                        cu.SetSelect();
                    }
                });
                
            });
        }
        public void Awake()
        {
            cardpool = new Stack<CardUnit>();
            onSelectingCards = new List<CardUnit>();
            _haveLayoutGroup = !(transform.GetComponent<LayoutGroup>() is null);
        }

        CardUnit GetCard()
        {
            CardUnit cardUnit;
            cardpool ??= new Stack<CardUnit>();
            if (cardpool.Count>0)
            {
                // var go =cardpool.Pop();
                cardUnit= cardpool.Pop();
            }
            else
            {
                cardUnit = Instantiate(prefab, transform);
                
                // go.AddComponent<CardUnit>();
                
            }
            cardUnit.Clear();
            return cardUnit;
        }
        void ReleaseCard(CardUnit go)
        {
            go.gameObject.SetActive(false);
            cardpool.Push(go);
        }

        public void SetCards(string st)
        {
            var cards = DdzUtility.StringToCards(st);
            OnShow(cards);
        }
        /// <summary>
        /// 可以建立一个对象池，避免重复生成
        /// 输入是一个已经经过排序的卡组
        /// </summary>
        public void OnShow(Card[] cardLs)
        {
            Clear();
            var cs= cardLs.ToList();
            cs.Sort();
            cs.Reverse();
            cacheCards = cs.ToArray();
            cards = new CardUnit[cacheCards.Length];
            for (int i = 0; i < cardLs.Length; i++)
            {
                cards[i] = GetCard();
                cards[i].gameObject.name = $"card_{cacheCards[i].id}";
                cards[i].SetCard(suitSprite[(int)cacheCards[i].Suit-1],cacheCards[i]);
                
                cards[i].Selectable = !_haveLayoutGroup;

            }
            foreach (var go in cards)
            {
                go.gameObject.SetActive(true);
                go.transform.SetAsLastSibling();
                go.cs = this;
            }
            if (!_haveLayoutGroup)
            {
                Vector3 bpos;
                if (cardLs.Length<15)
                {
                    float mid;
                
                    if (cardLs.Length%2==0)
                    {
                        mid = cardLs.Length / 2 - 0.5f;
                        bpos = transform.position + Vector3.left * mid*offset;
                
                    }
                    else
                    {
                        mid = (cardLs.Length+1) / 2-0.5f;
                        bpos = transform.position + Vector3.left * (mid-0.5f)*offset;
                    }
                }
                else if (cardLs.Length<17)
                {
                    bpos = transform.position + Vector3.left * 6.5f*offset;
                }else
                {
                    bpos = transform.position + (Vector3.right * rootoffset+ Vector3.left * cardLs.Length) * offset;
                }
                foreach (var go in cards)
                {
                    go.transform.position = bpos;
                    bpos += Vector3.right * offset;
                }
            }
        }
        [Button]
        void Show(int num)
        {
            var cs = new List<Card>();
            for (int i = 0; i < num; i++)
            {
                cs.Add(new Card(i+1));
            }

            OnShow(cs.ToArray());
        }
        [Button]
        void AddCard(int id)
        {
            var cs = new List<Card>();
            if (cacheCards!=null)
            {
                cs.AddRange(cacheCards);
            }
            cs.Add(new Card(id));
            OnShow(cs.ToArray());
        }
        public void Clear()
        {
            if (cards!=null)
            {
                foreach (var go in cards)
                {
                    ReleaseCard(go);
                }
            }

            cacheCards = null;
            cards = null;
        }
        [Button]
        void ClearPool()
        {
            Clear();
            // if (cardpool==null)
            // {
            //     return;
            // }
            foreach (var go in cardpool)
            {
                DestroyImmediate(go.gameObject);
            }
            cardpool.Clear();
        }

        // private void OnValidate()
        // {
        //     OnShow();
        // }
    }
}