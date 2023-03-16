namespace MyGame
{
    public abstract class S2CPacketBase : PacketBase
    {
        
        public override int Id => 20000 + tag;
        public override PacketType PacketType => PacketType.ServerToClient;
    }


}