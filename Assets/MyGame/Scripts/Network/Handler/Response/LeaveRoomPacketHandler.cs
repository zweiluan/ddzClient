using C2SSprotoType;
using GameFramework.Network;
using UnityEngine;

namespace MyGame
{
    // public class LeaveRoomPacketHandler : PacketResponseHandlerBase
    // {
    //     public override void Handle(object sender, Packet packet)
    //     {
    //         var channel = sender as INetworkChannel;
    //         var p = packet as PacketBase;
    //         
    //         var responseObj = p.responseObj as leaveroom.response;
    //         Debug.Log($"{channel.Name} 离开房间{responseObj.ok}");
    //     }
    //
    //     protected override int tag => C2SProtocol.leaveroom.Tag;
    // }
}