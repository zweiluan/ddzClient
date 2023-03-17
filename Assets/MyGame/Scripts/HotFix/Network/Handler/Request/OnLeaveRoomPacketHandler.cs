using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    // public class OnLeaveRoomPacketHandler : PacketRequestHanderBase
    // {
    //     protected override int tag => S2CProtocol.onleaveroom.Tag;
    //     public override void Handle(object sender, Packet packet)
    //     {
    //         var req = (packet as S2CPacketBase).requestObj as onleaveroom.request;
    //         var channel = sender as INetworkChannel;
    //         Debug.Log($"{channel.Name} onleaveroom,{req.index},{req.userid}");
    //     }
    // }
}