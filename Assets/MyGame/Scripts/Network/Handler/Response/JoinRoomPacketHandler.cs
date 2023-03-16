using C2SSprotoType;
using GameFramework.Network;
using MyGame.Room;
using UnityEngine;

namespace MyGame
{
    public class JoinRoomPacketHandler : PacketResponseHandlerBase
    {
        public override void Handle(object sender, Packet packet)
        {
            var p = packet as PacketBase;
            
            var responseObj = p.responseObj as joinroom.response;
            // Debug.Log(responseObj.info);
            string nil = "没有玩家";
            PlayerInfo user1 = new PlayerInfo()
            {
                userid =responseObj.info.HasUser1 ? responseObj.info.user1 : nil,
                IsReady=responseObj.info.HasUser1r && responseObj.info.user1r
                
            };
                
            PlayerInfo user2 = 
                new PlayerInfo()
                {
                    userid =responseObj.info.HasUser2 ? responseObj.info.user2 : nil,
                    IsReady=responseObj.info.HasUser2r && responseObj.info.user2r
                };
                
            PlayerInfo user3 = 
                new PlayerInfo()
                {
                    userid =responseObj.info.HasUser3 ? responseObj.info.user3 : nil,
                    IsReady=responseObj.info.HasUser3r && responseObj.info.user3r
                };
                
            var channel = sender as INetworkChannel;
            // Debug.Log($"{channel.Name} 登录结果：{responseObj.ok},我的座位：{responseObj.index},玩家1：{user1} ,玩家2：{user2},玩家3：{user3}");
            // GameEntry.Room.RegisterRoom(channel.Name,new Room()
            // {
            //     _state =RoomState.Null,
            //     // MyIndex = (int)responseObj.index ,
            //     players = new PlayerInfo[3]{
            //         user1,user2,user3
            //     }
            //     
            // });
            // if (responseObj.index == 3) return;
            channel.Send(PacketFactory.CreatReady("1"));
            // channel.Send(PacketFactory.CreatPacket<LeaveRoomPacket>());
        }
    
        protected override int tag => C2SProtocol.joinroom.Tag;
    }
}