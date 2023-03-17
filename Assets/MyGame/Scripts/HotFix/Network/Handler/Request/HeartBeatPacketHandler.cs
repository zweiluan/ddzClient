using GameFramework.Network;
using UnityEngine;

namespace MyGame
{
    public class HeartBeatPacketHandler : PacketRequestHanderBase
    {
        public override void Handle(object sender, Packet packet)
        {
            var channel = sender as INetworkChannel;
            Debug.Log($"{channel.Name} :heartbeat");
        }
        protected override int tag =>  S2CProtocol.heartbeat.Tag;
    }
}