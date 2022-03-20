using GamePlay.Enum;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterStatChanging : MonoBehaviour
    {
        public ObjectName objectName;

        public CharacterStatChanging(ObjectName characterID)
        {
            this.objectName = characterID;
        }
    }
}
