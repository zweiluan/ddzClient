using GameFramework.Event;

namespace MyGame
{
    public class OnSignInEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(OnSignInEventArgs).GetHashCode();

        public OnSignInEventArgs()
        {
            
        }
        
        public override void Clear()
        {
            
        }

        public override int Id => EventId;
    }
}