namespace MyGame
{
    public class OnJoinRoomPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.onjoinroom.Tag;
    }
}