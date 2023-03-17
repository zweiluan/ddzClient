using C2SSprotoType;
using GameFramework.Network;
using UnityEngine;

namespace MyGame
{
    public class SignInPacketHandler : PacketResponseHandlerBase
    {
        public override void Handle(object sender, Packet packet)
        {
            var p = packet as PacketBase;
            var responseObj = p.responseObj as signin.response;
            var channel = sender as INetworkChannel;
            Debug.Log($"{channel.Name} 登录：{responseObj.ok}");
            // channel.Send(PacketFactory.CreatPacket<JoinRoomPacket>());
            // GameEntry.Room.RegisterChannel(channel);
        }
        protected override int tag => C2SProtocol.signin.Tag;
    }
}