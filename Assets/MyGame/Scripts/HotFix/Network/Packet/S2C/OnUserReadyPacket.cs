namespace MyGame
{
    public class OnUserReadyPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.onuserready.Tag;
    }
}