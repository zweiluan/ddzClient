using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyGame
{
    //两种变化，一种是点击，一种是拖动
    public class CardUnit : MonoBehaviour,
        IPointerEnterHandler,
        IPointerClickHandler,
        IDragHandler,
        IBeginDragHandler,IEndDragHandler
    {
        public bool Selectable=false;
        public Image suits;
        public Image suitb;
        public Image bg;
        public TextMeshProUGUI text;
        public RectTransform root;
        //=======================================
        public bool Selected;
        [ShowInInspector]
        private CardState _state = CardState.Release;
        public CardShow cs;
        public Card cacheCard;
        [ShowInInspector]
        bool CanSelect
        {
            get
            {
                if (cs==null)
                {
                    return false;
                }
                else
                {
                    return cs.CanSelect;
                }
            }
            set
            {
                if (cs!=null)
                {
                    cs.CanSelect = value;
                }
            }
        }
        
        private List<CardUnit> _selectingList;
        private List<CardUnit> selectingList
        {
            get
            {
                if (_selectingList==null)
                {
                    if (cs==null)
                    {
                        _selectingList
                            = new List<CardUnit>();
                    }
                    else
                    {
                        _selectingList = cs.onSelectingCards;
                    }
                }
                

                return _selectingList;
            }
        }
        
            // => cs.onSelectingCards;
        private CardState State
        {
            get => _state;
            set
            {
                if(!Selectable) return;
                _state = value;
                OnSelect();
            }
        }
        private void OnSelect()
        {
            if (!CanSelect)
            {
                return;
            }
            // bg.color = _state==CardState.Selecting ? Color.gray : Color.white;
            if (_state==CardState.Selecting)
            {
                bg.color = Color.gray;
                selectingList.Add(this);
            }
            else
            {

                SetSelect();
            }
            
        }

        public void SetSelect()
        {
            
            bg.color = Color.white;
            Selected = !Selected;
            if (Selected)
            {

                root.DOAnchorPos3D(Vector3.up * 40, 0.2f);
                // DOMove(transform.position+ Vector3.up * 10, 0.2f);
                // position += Vector3.up * 50;
            }
            else
            {
                root.DOAnchorPos3D(Vector3.zero, 0.2f);
                // root.anchoredPosition3D.DOMove(0, 0.2f);
                // += Vector3.down * 50;
            }
        }
        public void SetCard(Sprite suit,Card card)
        {
            cacheCard = card;
            
            text.text = DdzUtility.GetDisplaySt(cacheCard.Display);
            if (suits!=null)
            {
                
                if (cacheCard.id>=53)
                {
                    suits.enabled = false;
                }
                else
                {
                    suits.enabled = true;
                    suits.sprite = suit;
                }
            }
            if (suitb!=null)
            {
                suitb.sprite = suit;
                if (cacheCard.id==53)
                {
                    suitb.color=Color.gray;
                }
            }
            
            if (cacheCard.Suit==SuitType.Diamond||cacheCard.Suit==SuitType.Heart||cacheCard.id==53)
            {
                text.color=Color.red;
            }
            else
            {
                text.color=Color.black;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Debug.Log("OnPointerEnter");
            if(!Selectable) return;
            // if (eventData.button!=PointerEventData.InputButton.Left)
            // {
            //     return;
            // }
            //第一次进入，被选中,处于正在选择的状态
            if (CanSelect)
            {
                // Debug.Log($"{gameObject.name} 处于选择中");
                State = CardState.Selecting;
                
            }
            
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            // Debug.Log("OnPointerClick");
            if(!Selectable) return;
            // Debug.Log($"{gameObject.name} 被点击");
            // if (eventData.button!=PointerEventData.InputButton.Left)
            // {
            //     return;
            // }

            if (State==CardState.Selecting)
            {
                return;
            }
            SetSelect();
        }


        public void OnDrag(PointerEventData eventData)
        {
            // throw new System.NotImplementedException();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!Selectable) return;
            CanSelect = true;
            State = CardState.Selecting;
            // Debug.Log($"{gameObject.name}开始拓转");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!Selectable) return;
            // if (eventData.button!=PointerEventData.InputButton.Left)
            // {
            //     return;
            // }
            foreach (var c in selectingList)
            {
                c.State = CardState.Release;
                // Debug.Log($"{c.gameObject.name} 释放");
            }
            // Debug.Log($"{gameObject.name} 结束拖拽");
            selectingList.Clear();
            CanSelect = false;
        }

        public void Clear()
        {
            State = CardState.Release;
            cs = null;
            Selected = false;
            cacheCard = null;
            root.transform.position = transform.position;
        }
        
    }

    public enum CardState
    {
        Release,
        Selecting,
        // Selected,
    }
}