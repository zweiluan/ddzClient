namespace MyGame
{
    public class SignInPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.signin.Tag;
    }
}