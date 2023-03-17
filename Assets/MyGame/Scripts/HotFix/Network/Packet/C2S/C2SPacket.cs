using System;
using System.Reflection;
using S2CSprotoType;
using UnityEngine;

namespace MyGame
{
    public abstract class C2SPacketBase : PacketBase
    {
        public virtual bool NeedResponese { 
            get
            {
            Type type = Assembly.GetExecutingAssembly()
                .GetType("C2SSprotoType." + this.GetType().Name.ToLower().Replace("packet", "") + "+response");
            // Debug.Log(this.GetType().Name.ToLower().Replace("packet", ""));
            if (type != null)
            {
                return true;
            }

            return false;
        }}

        public override int Id => 10000 + tag;
        public override PacketType PacketType => PacketType.ClientToServer;
    }





}