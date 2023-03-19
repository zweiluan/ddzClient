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
                ChangeState<ProcedureCheckResource>(procedureOwner);
            }
            //不进行更新资源，资源更新部分由launch部分完成。这个部分直接负责资源初始化
            // else
            // {
            //     ChangeState<ProcedureInitResource>(procedureOwner);
            // }
        }
    }
}

