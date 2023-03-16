using System;
using Sirenix.OdinInspector;

namespace MyGame.Room
{
    [Serializable]
    public class Room
    {
        public RoomState _state = RoomState.Null;
        [ShowInInspector]
        public PlayerInfo[] players { get; set; }
        [ShowInInspector]
        public int MyIndex { get; set; }
    }
    [Serializable]
    public class PlayerInfo
    {
        public string userid;
        public bool IsReady;
        public override string ToString()
        {
            return $"id:{userid},ready:{IsReady}";
        }
    }
    public enum RoomState
    {
        Null,
        Ready,
        Master,
        Play,
        Over,
    }
}