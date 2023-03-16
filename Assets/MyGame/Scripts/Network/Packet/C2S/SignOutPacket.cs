namespace MyGame
{
    public class SignOutPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.signout.Tag;
    }
}