using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    public class OnGameStartPacketHandler : PacketRequestHanderBase
    {
        protected override int tag => S2CProtocol.ongamestart.Tag;
        public override void Handle(object sender, Packet packet)
        {
            var req = (packet as S2CPacketBase).requestObj as ongamestart.request;
            var channel = sender as INetworkChannel;
            Debug.Log($"{channel.Name} ongamestart :{req.excards},{req.master}");
        }
    }
}