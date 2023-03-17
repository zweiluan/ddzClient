namespace MyGame
{
    public class RegisterPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.register.Tag;
    }
}