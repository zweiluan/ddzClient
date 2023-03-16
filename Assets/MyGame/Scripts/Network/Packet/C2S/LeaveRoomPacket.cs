namespace MyGame
{
    public class LeaveRoomPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.leaveroom.Tag;
    }
}