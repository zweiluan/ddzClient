using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace MyGame
{
    [AddComponentMenu("Agent")]
    public class AgentComponent  : GameFrameworkComponent
    {
        [ShowInInspector]
        private List<BaseAgent> agents;
        private int num=0;

        public BaseAgent GetAgentByID(int id)
        {
            foreach (var agent in agents)
            {
                if (agent.ID==id)
                {
                    return agent;
                }
            }

            return null;
        }
        protected override void Awake()
        {
            base.Awake();
            agents=new List<BaseAgent>();
        }

        public int RegisterAgent(BaseAgent agent)
        {
            agents.Add(agent);
            return ++num;
        }

        public bool RemoveAgent(BaseAgent agent)
        {
            return agents.Remove(agent); 
        }
        public void Update()
        {
            foreach (var agent in agents)
            {
                foreach (var component in agent._components)
                {
                    component.Update();
                }
            }
        }
    }
}