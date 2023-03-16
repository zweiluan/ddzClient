using GameFramework.Fsm;
using GameFramework.Procedure;

namespace MyGame
{
    public class ProcedureJoinRoom : ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            //所有的登录连接都尝试发送登录请求
            // foreach (var vk in GameEntry.Room.GetChannels())
            // {
            //     vk.Value.Send(PacketFactory.CreatPacket<JoinRoomPacket>());
            // }
        }
    }
}