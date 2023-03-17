namespace MyGame
{
    public class OnRequestMasterPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.onrequestmaster.Tag;
    }
}