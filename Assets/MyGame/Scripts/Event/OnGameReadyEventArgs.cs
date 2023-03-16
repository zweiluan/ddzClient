using GameFramework.Event;

namespace MyGame
{
    public class OnGameReadyEventArgs  : GameEventArgs
    {
        public static readonly int EventId = typeof(OnGameReadyEventArgs).GetHashCode();
        public override void Clear()
        {
            
        }

        public override int Id => EventId;
    }
}