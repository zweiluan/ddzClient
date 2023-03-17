namespace MyGame
{
    public class HeartBeatPacket : S2CPacketBase
    {
        protected override int tag => S2CProtocol.heartbeat.Tag;
    }
}