using GameFramework.Network;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    public class OnRequestMasterPacketHandler : PacketRequestHanderBase
    {
        protected override int tag => S2CProtocol.onrequestmaster.Tag;
        public override void Handle(object sender, Packet packet)
        {
            var req = (packet as S2CPacketBase).requestObj as onrequestmaster.request;
            var channel = sender as INetworkChannel;
            Debug.Log($"{channel.Name}onrequestmaster :{req.index},{req.next},{req.rate}");
            //如果下一家是自己，则抢地主
            // if (GameEntry.Room.CheckIndexIsSelf(channel.Name,(int)(req.next)))
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