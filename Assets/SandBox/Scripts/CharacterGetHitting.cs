using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterGetHitting : MonoBehaviour
    {
        public ObjectName objectName;

        public CharacterGetHitting(ObjectName characterID)
        {
            this.objectName = characterID;
        }
    }
}
