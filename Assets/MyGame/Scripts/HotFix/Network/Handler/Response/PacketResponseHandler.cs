using C2SSprotoType;
using GameFramework.Network;
using UnityEngine;

namespace MyGame
{
    public abstract class PacketResponseHandlerBase : PacketHandlerBase
    {
        protected abstract int tag { get; }
    
        public override int Id => 10000+tag;
    }
    
}