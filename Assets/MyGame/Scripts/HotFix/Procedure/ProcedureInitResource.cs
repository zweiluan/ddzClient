﻿using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public class ProcedureInitResource : ProcedureBase
    {
        private bool m_InitResourcesComplete = false;
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Resource.InitResources(OnInitResourcesComplete);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_InitResourcesComplete)
            {
                ChangeState<ProcedurePreload>(procedureOwner);
            }
        }
        private void OnInitResourcesComplete()
        {
            m_InitResourcesComplete = true;
            Log.Info("Init resources complete.");
        }
    }
}