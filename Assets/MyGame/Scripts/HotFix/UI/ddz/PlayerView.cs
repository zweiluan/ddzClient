using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    //1、卡牌显示功能
    //2、牌型提示功能
    //3、名称显示
    //4、积分显示
    //5、地主或者农名
    //6、生育卡牌数量
    //7、操作倒计时
    public class PlayerView : MonoBehaviour
    {
        public CardShow cardShow;
        public CardShow cardHandle;
        public Text cardNumber;
        public Text playerName;
        public Text playerScore;
        public Image playerStatus;
        public TextMeshProUGUI tip;
        public Sprite peasant;
        public Sprite landlord;
        
        public void SetSelectedCards(string st)
        {
            if (cardHandle!=null)
            {
                cardHandle.SetSelectedCards(st);
            }
        }
        public string GetSelectedCards()
        {
            if (cardHandle!=null)
            {
                return cardHandle.GetSelectedCards();
            }

            return "invalid";
        }
        public void SetScore(int i)
        {
            if (playerScore!=null)
            {
                if (playerScore.text!=i.ToString())
                {
                    playerScore.text = i.ToString();
                }
            }
        }

        public void SetTip(string st)
        {
            if (tip!=null&&tip.text!=st)
            {
                tip.text = st;
            }
            
        }
        /// <summary>
        /// 设置名字
        /// </summary>
        public void SetName(string name)
        {
            if (playerName!=null&&playerName.text != name)
            {
                playerName.text = name;
            }
        }
        /// <summary>
        /// 设置玩家身份
        /// </summary>
        /// <param name="isPeasant"></param>
        public void SetStatus(bool isPeasant)
        {
            if (isPeasant)
            {
                if (playerStatus.sprite != peasant)
                {
                    playerStatus.sprite = peasant;
                }
                
            }
            else
            {
                if (playerStatus.sprite != landlord)
                {
                    playerStatus.sprite = landlord;
                }
                
            }
        }
        /// <summary>
        /// 设置卡牌的数量
        /// </summary>
        /// <param name="i"></param>
        private void SetCardNumber(int i)
        {
            if (cardNumber!=null&&cardNumber.text!=i.ToString())
            {
                cardNumber.text = i.ToString();
            }

        }
        /// <summary>
        /// 展示出示的出牌
        /// </summary>
        /// <param name="st"></param>
        public void ShowCard(string st)
        {
            if (cardShow!=null)
            {
                if (st.Length==null||st=="")
                {
                    cardShow.Clear(); 
                }
                var cards= DdzUtility.StringToCards(st);
                cardShow.OnShow(cards);
            }
        }

        public void SetHandleCard(string st)
        {
            var cards= DdzUtility.StringToCards(st);
            cardHandle?.OnShow(cards);
            SetCardNumber(cards.Length);
        }
        
    }
}