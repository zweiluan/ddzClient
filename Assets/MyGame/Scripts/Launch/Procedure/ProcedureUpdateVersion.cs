﻿using GameFramework.Procedure;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameEntry= MyGame.Launch.GameEntry;

namespace MyGame.Launch
{
    public class ProcedureUpdateVersion : ProcedureBase
    {
        private bool m_UpdateVersionComplete = false;
        private UpdateVersionListCallbacks m_UpdateVersionListCallbacks = null;
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);

            m_UpdateVersionListCallbacks = new UpdateVersionListCallbacks(OnUpdateVersionListSuccess, OnUpdateVersionListFailure);
        }
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_UpdateVersionComplete = false;

            GameEntry.Resource.UpdateVersionList(procedureOwner.GetData<VarInt32>("VersionListLength"), procedureOwner.GetData<VarInt32>("VersionListHashCode"), procedureOwner.GetData<VarInt32>("VersionListCompressedLength"), procedureOwner.GetData<VarInt32>("VersionListCompressedHashCode"),
                m_UpdateVersionListCallbacks);
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_UpdateVersionComplete)
            {
                return;
            }

            ChangeState<ProcedureVerifyResources>(procedureOwner);
        }
        
        
        
        
        private void OnUpdateVersionListSuccess(string downloadPath, string downloadUri)
        {
            m_UpdateVersionComplete = true;
            Log.Info("Update version list from '{0}' success.", downloadUri);
        }

        private void OnUpdateVersionListFailure(string downloadUri, string errorMessage)
        {
            Log.Warning("Update version list from '{0}' failure, error message is '{1}'.", downloadUri, errorMessage);
        }
    }
}