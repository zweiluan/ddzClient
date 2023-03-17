namespace MyGame
{
    public class OnLeaveRoomPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.onleaveroom.Tag;
    }
}