using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    public class OnGameReadyPacketHandler : PacketRequestHanderBase
    {
        protected override int tag => S2CProtocol.ongameready.Tag;
        public override void Handle(object sender, Packet packet)
        {
            var req = (packet as S2CPacketBase).requestObj as ongameready.request;
            var channel = sender as INetworkChannel;
            Debug.Log($"{channel.Name} ongameready: {req.cards},{req.first}");
            // if (GameEntry.Room.CheckIndexIsSelf(channel.Name,(int)(req.first)))
            // {
            //     int x = Random.Range(0, 10);
            //     if (x>0)
            //     {
            //         channel.Send(PacketFactory.CreatRequestMaster("3"));
            //     }
            //     else
            //     {
            //         channel.Send(PacketFactory.CreatRequestMaster("0")); 
            //     }
            //     
            // }
        }
    }
}