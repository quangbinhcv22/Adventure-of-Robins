using GamePlay.AI;
using GamePlay.Enum;
using UnityEngine;

namespace GamePlay.Character
{
    public class CharacterMovingPlatformSetParent : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collider2D)
        {
            var target = collider2D.gameObject.GetComponent<MovingObject>();
            if (!target) return;
            if (target.ObjectName == ObjectName.SpringMovingPlatform 
                || target.ObjectName == ObjectName.AutumnMovingPlatForm 
                || target.ObjectName == ObjectName.WinterMovingPlatForm) transform.SetParent(target.transform);
        }
        
        private void OnCollisionExit2D(Collision2D collider2D)
        {
            var target = collider2D.gameObject.GetComponent<MovingObject>();
            if (!target) return;
            if (target.ObjectName == ObjectName.SpringMovingPlatform 
                || target.ObjectName == ObjectName.AutumnMovingPlatForm 
                || target.ObjectName == ObjectName.WinterMovingPlatForm) transform.SetParent(null);
        }
    }
}

