using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using UnityEngine;
using GameEntry = MyGame.Launch.GameEntry;

namespace MyGame.Launch
{
    public class ProcedureSplash : ProcedureBase
    {
        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            // if (GameEntry.Resource.ResourceMode == ResourceMode.Updatable)
            {
                Debug.Log("过度动画");
                if (GameEntry.Base.EditorResourceMode)
                {
                    // 编辑器模式
                    ChangeState<ProcedurePreload>(procedureOwner);
                }
                else if (GameEntry.Resource.ResourceMode == ResourceMode.Package)
                {
                    // 单机模式
                    ChangeState<ProcedureInitResources>(procedureOwner);
                }
                else
                {
                    // 可更新模式
                    ChangeState<ProcedureCheckVersion>(procedureOwner);
                }
            }
        }
    }
}