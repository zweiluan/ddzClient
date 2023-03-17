using GameFramework.Event;

namespace MyGame
{
    /// <summary>
    /// 玩家
    /// </summary>
    public class OnPlayEventArgs  : GameEventArgs
    {
        public static readonly int EventId = typeof(OnPlayEventArgs).GetHashCode();
        public override void Clear()
        {
            
        }

        public override int Id => EventId;
    }
}