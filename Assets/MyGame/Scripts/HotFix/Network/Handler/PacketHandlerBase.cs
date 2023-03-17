using GameFramework.Network;

namespace MyGame
{
    public abstract class PacketHandlerBase : IPacketHandler
    {
        public abstract void Handle(object sender, Packet packet);

        
        public abstract int Id { get; }
    }
}