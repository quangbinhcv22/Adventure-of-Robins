using UnityEngine;
using UnityEngine.Serialization;

namespace SandBox.Scripts
{
    public class CharacterSkillAttacking : MonoBehaviour
    {
        public ObjectName objectName;

        public CharacterSkillAttacking(ObjectName characterID)
        {
            this.objectName = characterID;
        }
    }
}
