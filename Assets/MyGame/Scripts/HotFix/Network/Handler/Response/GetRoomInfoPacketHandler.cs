using C2SSprotoType;
using GameFramework.Network;
using UnityEngine;
namespace MyGame
{
    public class GetRoomInfoPacketHandler : PacketResponseHandlerBase
    {
        public override void Handle(object sender, Packet packet)
        {
            throw new System.NotImplementedException();
        }

        protected override int tag => C2SProtocol.getroominfo.Tag;
    }
}