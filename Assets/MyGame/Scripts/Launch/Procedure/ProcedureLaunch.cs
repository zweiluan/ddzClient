using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;

namespace MyGame.Launch
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            Debug.Log("初始化");
            ChangeState<ProcedureSplash>(procedureOwner);
        }
    }
}