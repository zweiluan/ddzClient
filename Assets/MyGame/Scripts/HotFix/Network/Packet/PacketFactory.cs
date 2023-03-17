using System;
using GameFramework;
using Unity.VisualScripting;

namespace MyGame
{
    /// <summary>
    /// 包工厂
    /// </summary>
    public static class PacketFactory
    {
        public static C2SPacketBase CreatPacket<T>() where T : PacketBase
        {
            Type type = typeof(T);
            return (C2SPacketBase)ReferencePool.Acquire(type);
        }

        public static C2SPacketBase CreatCommand(string cmd, string parameters)
        {
            var packet = ReferencePool.Acquire<OnCommandPacket>();
            packet.requestObj=new C2SSprotoType.oncommand.request() {cmd = cmd,parameters = parameters};
            return packet;
        }

        public static C2SPacketBase CreatReady(string  parameters)
        {
            return CreatCommand("ready", parameters);
        }
        public static C2SPacketBase CreatRequestMaster(string parameters)
        {
            return CreatCommand("master", parameters);
        }
        public static C2SPacketBase CreatPlay(string parameters)
        {
            return CreatCommand("play", parameters);
        }
        
        public static C2SPacketBase CreatSignIn(string account,string psw)
        {
            var packet = ReferencePool.Acquire<SignInPacket>();
            packet.requestObj=new C2SSprotoType.signin.request() {account = account,psw = psw};
            return packet;
        }
        public static C2SPacketBase CreatRegister(string account,string psw)
        {
            var packet = ReferencePool.Acquire<RegisterPacket>();
            packet.requestObj=new C2SSprotoType.register.request() {account = account,psw = psw};
            return packet;
        }
    }
}