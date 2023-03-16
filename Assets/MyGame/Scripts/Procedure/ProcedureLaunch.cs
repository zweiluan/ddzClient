using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using UnityEngine;

namespace MyGame
{
    public  class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (GameEntry.Base.EditorResourceMode)
            {
                ChangeState<ProcedurePreload>(procedureOwner);
            }
            else if (GameEntry.Resource.ResourceMode==ResourceMode.Package)
            {
                ChangeState<ProcedureInitResource>(procedureOwner);
            }else
            {
                ChangeState<ProcedureUpdataResource>(procedureOwner);
            }
            
        }
    }
}

