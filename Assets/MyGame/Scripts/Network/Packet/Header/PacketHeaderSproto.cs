using GameFramework;
using GameFramework.Network;

namespace MyGame
{
    public class PacketHeaderSproto : BasePacketHeader
    {
        public int length;
        public override int PacketLength => length;
        public override void Clear()
        {
            length = 0;
        }
    }
}