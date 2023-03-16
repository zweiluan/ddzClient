using GameFramework.Network;
using UnityEngine;

namespace MyGame
{
    public abstract class PacketRequestHanderBase : PacketHandlerBase
    {
        protected abstract int tag { get; }
        public override int Id => 20000+tag;
    }

}