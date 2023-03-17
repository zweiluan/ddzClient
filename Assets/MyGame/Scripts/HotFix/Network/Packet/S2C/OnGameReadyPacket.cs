namespace MyGame
{
    public class OnGameReadyPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.ongameready.Tag;
    }
}