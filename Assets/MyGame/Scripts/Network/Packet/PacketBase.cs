using GameFramework.Network;
using Sproto;

namespace MyGame
{
    public abstract class PacketBase : Packet
    {
        protected abstract int tag { get; }
        public SprotoTypeBase requestObj;
        public SprotoTypeBase responseObj;
        


        public override void Clear()
        {
            requestObj = null;
            responseObj = null;
        }
        public abstract PacketType PacketType
        {
            get;
        }
    }
}