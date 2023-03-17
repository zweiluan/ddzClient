namespace MyGame
{
    public class PushPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.push.Tag;
    }
}