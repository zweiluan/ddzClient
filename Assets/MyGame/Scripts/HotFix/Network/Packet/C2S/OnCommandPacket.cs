namespace MyGame
{
    public class OnCommandPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.oncommand.Tag;
    }
}