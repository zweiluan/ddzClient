using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    // public class OnUserReadyPacketHandler : PacketRequestHanderBase
    // {
    //     protected override int tag => S2CProtocol.onuserready.Tag;
    //     public override void Handle(object sender, Packet packet)
    //     {
    //         var req = (packet as S2CPacketBase).requestObj as onuserready.request;
    //         var channel = sender as INetworkChannel;
    //         Debug.Log($"{channel.Name} onuserready : {req.index},{req.userid}");
    //         GameEntry.Room.GetRoom(channel.Name).players[req.index-1].IsReady = true;
    //     }
    // }
}