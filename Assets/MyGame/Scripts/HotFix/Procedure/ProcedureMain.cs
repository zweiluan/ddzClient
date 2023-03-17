using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public class ProcedureMain : ProcedureBase
    {
        private int uiformid;
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            BaseAgent agent=GameEntry.Agent.GetAgentByID(procedureOwner.GetData<VarInt32>("PlayerId")) ;
            if ( procedureOwner.GetData<VarInt32>("GameMode")==1)
            {
                agent.AddComponent<SingleRoomComponent>();
            }
            else
            {
                // agent.AddComponent<>();
            }

        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }
    }
}