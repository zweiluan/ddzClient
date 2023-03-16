namespace MyGame
{
    public class PingPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.ping.Tag;
    }
}