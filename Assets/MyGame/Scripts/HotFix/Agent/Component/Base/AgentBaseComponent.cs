using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace MyGame
{
    public abstract class AgentBaseComponent
    {
        [HideInInspector]
        public BaseAgent Agent;

        public virtual void Start(){}
        public virtual void Init(){}

        public virtual void Update(){}

        public virtual void Destroy(){}
    }
}