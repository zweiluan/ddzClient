using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public class ProcedureMenu : ProcedureBase
    {
        public bool single;
        public bool mult;
        private int uiformid;
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            single = false;
            mult = false;
            string st = GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.MainMenu).Path;
            uiformid=GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAssetPath(st), "Default",this);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (single)
            {
                // int entityid= procedureOwner.GetData<VarInt32>("PlayerId");
                // BaseAgent agent= GameEntry.Agent.GetAgentByID(entityid);
                // agent.AddComponent<SingleRoomComponent>();
                procedureOwner.SetData<VarInt32>("GameMode",1);
                ChangeState<ProcedureMain>(procedureOwner);
                return;
            }

            if (mult)
            {
                procedureOwner.SetData<VarInt32>("GameMode",2);
                ChangeState<ProcedureMain>(procedureOwner);
                return;
            }
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            GameEntry.UI.CloseUIForm(uiformid);
            base.OnLeave(procedureOwner, isShutdown);
        }
    }
}