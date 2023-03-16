using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    public class PushPacketHandler : PacketRequestHanderBase
    {
        public override void Handle(object sender, Packet packet)
        {
            var req = (packet as S2CPacketBase).requestObj as push.request;
            var channel = sender as INetworkChannel;
            Debug.Log($"{channel.Name} push: {req.text}");
        }

        protected override int tag => S2CProtocol.push.Tag;
    }
}