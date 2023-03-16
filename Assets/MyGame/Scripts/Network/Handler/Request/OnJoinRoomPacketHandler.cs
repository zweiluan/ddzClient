using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    // public class OnJoinRoomPacketHandler: PacketRequestHanderBase
    // {
    //     protected override int tag => S2CProtocol.onjoinroom.Tag;
    //     public override void Handle(object sender, Packet packet)
    //     {
    //         var req = (packet as S2CPacketBase).requestObj as onjoinroom.request;
    //         var channel = sender as INetworkChannel;
    //         Debug.Log($"{channel.Name} onjoinroom :{req.index},{req.userid}");
    //         if (req.userid==channel.Name)
    //         {
    //             return;//如果自己的回复先到，此时由没有注册，则跳过
    //         }
    //         GameEntry.Room.GetRoom(channel.Name).players[req.index-1].userid = req.userid;
    //     }
    // }
}