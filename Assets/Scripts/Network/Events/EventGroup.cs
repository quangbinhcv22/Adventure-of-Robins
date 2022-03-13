using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(EventGroup), menuName = "Server/EventGroup")]
    public class EventGroup : ScriptableObject
    {
        public CharacterMoveEvent characterMove;
    }
}