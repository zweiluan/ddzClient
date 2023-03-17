namespace MyGame
{
    public class GetRoomInfoPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.getroominfo.Tag;
    }
}