namespace MyGame
{
    public class OnPlayPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.onplay.Tag;
    }
}