using GameFramework.Procedure;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;

namespace MyGame.Lanuch
{
    public  class ProcedureCheckVersion : ProcedureBase
    {
        
        private bool m_CheckVersionComplete = false;
        private bool m_NeedUpdateVersion = false;
        // private VersionInfo m_VersionInfo = null;
        //
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("检查版本信息");
            ChangeState<ProcedureInitResources>(procedureOwner);
        }
    }
}