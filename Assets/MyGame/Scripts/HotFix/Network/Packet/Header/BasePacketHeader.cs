using GameFramework;
using GameFramework.Network;
using UnityEngine.PlayerLoop;

namespace MyGame
{
    public abstract class BasePacketHeader : IPacketHeader ,IReference
    {
        public abstract int PacketLength { get; }

        public virtual void Clear()
        {
            
        }
    }
}