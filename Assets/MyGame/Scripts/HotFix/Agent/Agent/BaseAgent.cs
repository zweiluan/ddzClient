using System;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public class BaseAgent
    {
        private int id;
        [ShowInInspector]
        public List<AgentBaseComponent> _components;
        [ShowInInspector]
        public int ID => id;
        
        public BaseAgent()
        {
           id= GameEntry.Agent.RegisterAgent(this);
           _components = new List<AgentBaseComponent>();
        }

        public void Destory()
        {
            GameEntry.Agent.RemoveAgent(this);
            _components.RemoveAll(c =>
            {
                c.Destroy();
                return true;
            });
            _components = null;
        }
        protected internal T AddComponent<T>() where T : AgentBaseComponent
        {
            T component=Activator.CreateInstance<T>();
            component.Agent = this;
            component.Init();
            component.Start();
            _components.Add(component);
            return component;
        }
        protected internal AgentBaseComponent AddComponent(string componentName)
        {
            Type type = GetType().Assembly.GetType($"{this.GetType().Namespace}.{componentName}");
            if (type==null)
            {
                Log.Info($"未正常获得组件名称{componentName}");
            }
            AgentBaseComponent component = (AgentBaseComponent)Activator.CreateInstance(type);
            component.Agent = this;
            component.Init();
            component.Start();
            _components.Add(component);
            return component;
        }
        protected internal void RemoveComponent<T>() where T : AgentBaseComponent
        {
            if (_components.Count<1)
            {
                return;
            }
            
            _components.RemoveAll((component) =>
            {
                if (component.GetType() == typeof(T))
                {
                    component.Destroy();
                    return true;
                }
            
                return false;
            });
        }
        protected internal void RemoveComponent(string componentName) 
        {

            if (_components.Count<1)
            {
                return;
            }
            Type type = Assembly.GetExecutingAssembly().GetType($"{this.GetType().Namespace}.{componentName}");
            _components.RemoveAll((component) =>
            {
                if (component.GetType() == type)
                {
                    component.Destroy();
                    return true;
                }
                return false;
            });
        }

        protected internal T GetComponent<T>() where T : AgentBaseComponent
        {
            return (T)_components.Find(c => c.GetType() == typeof(T)||c.GetType().BaseType==typeof(T));
        }
    }
}