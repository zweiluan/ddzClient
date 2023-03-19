using System;
using System.Linq;
using UnityEngine;

namespace MyGame
{
    public class PlayerDdzComponent : DdzComponent
    {
        private int commandUIID { get; set; }
        
        public override void ReqMaster(Action<string> callback)
        {
            Debug.Log("玩家抢地主");
            var uiForm=GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Command);
            commandUIID= 
                GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path), uiForm.Group,
                // GameEntry.UI.OpenCommandUI(
                new CommandParams()
            {
                Mode = (int)CommandMode.req_master,
                UserData = this,
                Action1 = (_)=>
                {
                    callback("玩家不抢地主|0");
                    GameEntry.UI.CloseUIForm(commandUIID);
                },
                Action2= (_)=>
                {
                    callback("玩家抢地主|3");
                    GameEntry.UI.CloseUIForm(commandUIID);
                }
            });
        }

        public override void Play(Action<string> callback)
        {
            Debug.Log("玩家出牌");
            var uiForm=GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Command);

            //跟牌模式
            if (game.bottomCards==null||game.bottomCards.Length==0)
            {
                GameEntry.UI.OpenCommandUI(
                    new CommandParams()
                    {
                        Mode = (int)CommandMode.chu,
                        UserData = this,
                        Action1 = (_)=>
                        {
                            // callback($"玩家出牌|{room.GetSelectedCards()}");
                            // GameEntry.UI.CloseUIForm(GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)));
                            if (room.GetSelectedCards()!="pass")
                            {
                                callback($"玩家出牌|{room.GetSelectedCards()}");
                                GameEntry.UI.CloseUIForm(
                                    GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)));
                            }
                            else
                            {
                                Debug.Log("无效出牌");
                                GameEntry.UI.OpenDialogUIInvalid();
                            }
                            
                        },
                    });
            }
            //出牌模式
            else
            {
                GameEntry.UI.OpenCommandUI(
                    new CommandParams()
                    {
                        Mode = (int)CommandMode.gen,
                        UserData = this,
                        Action3 = (_) =>
                        {
                            if (room.GetSelectedCards()!="pass")
                            {
                                if (ddzAI.Split(room.GetSelectedCards().StringToCards()).Count!=1)
                                {
                                    GameEntry.UI.OpenDialogUIInvalid();
                                    return;
                                }
                                callback($"玩家出牌|{room.GetSelectedCards()}");
                                GameEntry.UI.CloseUIForm(
                                    GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)));
                            }
                            else
                            {
                                Debug.Log("无效出牌");
                                GameEntry.UI.OpenDialogUIInvalid();
                            }
                            
                        },
                        Action1 = (_) =>
                        {
                            callback("玩家不出|pass");
                            GameEntry.UI.CloseUIForm(
                                GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)));
                        },
                        Action2 = (_) =>
                        {
                        // callback("玩家不出|pass");
                        // GameEntry.UI.CloseUIForm(
                        // GameEntry.UI.GetUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path)));
                        Debug.Log("提示出牌");
                        Prompt();
                        }
                    });
            }
        }

        void Prompt()
        {
            Debug.Log(handleCards.ToArray().CardsToString());
            var ls = ddzAI.Split(handleCards.ToArray());
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
                        return true;
                    }
                    return false;
                });
                if (cs==null)
                {
                    Debug.Log("没有可以跟上的牌");
                    GameEntry.UI.OpenDialogUIMsg( "没有可以跟上的牌" );
                }
                else
                {
                    //将对应的牌设置为被选中
                    room.SetSelectedCardsAction(cs.cards.CardsToString());
                }
            }
        }
        public override void ShowCards()
        {
            //展示完整的卡牌UI
        }
    }
}