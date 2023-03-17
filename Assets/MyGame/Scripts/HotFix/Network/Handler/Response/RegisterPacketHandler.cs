using C2SSprotoType;
using GameFramework.Network;
using UnityEngine;
namespace MyGame
{
    public class RegisterPacketHandler  : PacketResponseHandlerBase
    {
        public override void Handle(object sender, Packet packet)
        {
            var p = packet as PacketBase;
            
            var responseObj = p.responseObj as register.response;

            var channel = sender as INetworkChannel;
            
            Debug.Log($"{channel.Name} 注册：{responseObj.ok}");
        }

        protected override int tag => C2SProtocol.register.Tag;
    }
}