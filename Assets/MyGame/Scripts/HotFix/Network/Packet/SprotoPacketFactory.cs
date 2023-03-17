using GameFramework;

namespace MyGame
{
    public static class SprotoPacketFactory
    {
        public static C2SSprotoPacket CreatPacket(int tag) 
        {
            var packet= ReferencePool.Acquire<C2SSprotoPacket>();
            packet.tag = tag;
            return packet;
        }
        public static C2SSprotoPacket CreatSignIn(string account,string psw)
        {
            var packet = CreatPacket(C2SProtocol.signin.Tag);
            packet.requestObj=new C2SSprotoType.signin.request() {account = account,psw = psw};
            return packet;
        }
        public static C2SSprotoPacket CreatRegister(string account,string psw)
        {
            var packet =CreatPacket(C2SProtocol.register.Tag);
            packet.requestObj=new C2SSprotoType.register.request() {account = account,psw = psw};
            return packet;
        }

        public static C2SSprotoPacket Ping()
        {
            var packet =CreatPacket(C2SProtocol.ping.Tag);
            return packet;
        }
    }
}