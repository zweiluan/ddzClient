namespace MyGame
{
    public class OnGameOverPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.ongameover.Tag;
    }
}