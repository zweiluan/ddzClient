using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    public class OnGameOverPacketHandler : PacketRequestHanderBase
    {
        protected override int tag => S2CProtocol.ongameover.Tag;
        public override void Handle(object sender, Packet packet)
        {
            var req = (packet as S2CPacketBase).requestObj as ongameover.request;
            var channel = sender as INetworkChannel;
            Debug.Log($"{channel.Name}:ongameover : {req.masterwin},{req.p1score},{req.p2score},{req.p3score}");
        }
    }
}