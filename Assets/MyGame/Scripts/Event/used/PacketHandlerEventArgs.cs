using GameFramework;
using GameFramework.Event;
using GameFramework.Network;
using Sproto;
using UnityEngine;


namespace MyGame
{
    /// <summary>
    /// 接受到handler
    /// </summary>
    public class PacketHandlerEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PacketHandlerEventArgs).GetHashCode();

        // public SprotoPacket packet { get; private set; }
        public PacketHandlerEventArgs()
        {
            requestObj = null;
            responseObj = null;
        }

        public SprotoTypeBase requestObj { get; private set; }
        public SprotoTypeBase responseObj { get; private set; }
        public static PacketHandlerEventArgs Create(SprotoPacket packet)
        {
            PacketHandlerEventArgs e = ReferencePool.Acquire<PacketHandlerEventArgs>();
            // e.packet = packet;
            e.requestObj = packet.requestObj;
            e.responseObj = packet.responseObj;
            return e;
        }
        
        public override void Clear()
        {
            requestObj = null;
            responseObj = null;
        }

        public override int Id => EventId;
    }
}