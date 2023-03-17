using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    // public class OnPlayPacketHandler : PacketRequestHanderBase
    // {
    //     protected override int tag => S2CProtocol.onplay.Tag;
    //     public override void Handle(object sender, Packet packet)
    //     {
    //         var req = (packet as S2CPacketBase).requestObj as onplay.request;
    //         var channel = sender as INetworkChannel;
    //         Debug.Log($"{channel.Name} onplay : {req.abandon},{req.cards},{req.index},{req.next}");
    //     }
    // }
}