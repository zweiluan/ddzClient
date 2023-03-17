using C2SSprotoType;
using GameFramework.Event;
using GameFramework.Network;
using UnityEngine;

namespace MyGame
{
    public abstract class BaseSprotoPacketHandler : PacketHandlerBase
    {
        public override void Handle(object sender, Packet packet)
        {
            var p = packet as SprotoPacket;
            GameEntry.Event.Fire(this,PacketHandlerEventArgs.Create(p));
            if (Id==1)
            {
                // PacketHandlerEventArgs e = ;
                // //response
                Debug.Log($"受到消息，type 为 {p.responseObj.GetType()}");
                // if (e.packet.responseObj is signin.response r)
                // {
                //     // Debug.Log(r.ok);
                //     
                // }
            }
            else
            {
                //requese
                if (p.tag==S2CProtocol.heartbeat.Tag)
                {
                    Debug.Log($"心跳");
                }
                
            }

           

            
        }
    }
}