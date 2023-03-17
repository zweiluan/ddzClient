namespace MyGame
{
    public class OnGameStartPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.ongamestart.Tag;
    }
}