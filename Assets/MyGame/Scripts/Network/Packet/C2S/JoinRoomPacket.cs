

using System;
using System.Reflection;
using C2SSprotoType;

namespace MyGame
{
    public class JoinRoomPacket : C2SPacketBase
    {
        protected override int tag => C2SProtocol.joinroom.Tag;
    }
}