using GameFramework.Event;

namespace MyGame
{
    public class OnGameOverEventArgs  : GameEventArgs
    {
        public static readonly int EventId = typeof(OnGameOverEventArgs).GetHashCode();
        public override void Clear()
        {
            
        }

        public override int Id => EventId;
    }
}