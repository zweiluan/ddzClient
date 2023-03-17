using GameFramework.Network;
using Sproto;

namespace MyGame
{
    public abstract class SprotoPacket : Packet
    {
        public int tag;
        public SprotoTypeBase requestObj;
        public SprotoTypeBase responseObj;
        public override void Clear()
        {
            tag = 0;
            requestObj = null;
            responseObj = null;
        }
        
    }
}