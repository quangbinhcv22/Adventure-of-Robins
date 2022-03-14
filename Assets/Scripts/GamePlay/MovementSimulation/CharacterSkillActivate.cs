using System.Collections;
using DG.Tweening;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.MovementSimulation
{
    public class CharacterSkillActivate : MonoBehaviour
    {
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Character character;
        [SerializeField] private SkillName name;
        
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float skillForce;
        [SerializeField] private float objectSize;
        [SerializeField] private float objectSizeDuration;

        public void ActivateSkill1(string characterID,SkillName skillName)
        {
            if (skillName != SkillName.Skill1) return;
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.RotateSword, wayPoints[0].position, wayPoints[0].rotation);
                    
                    StartCoroutine(SkillDuration(newObjectPooler,3f));
                    break;
                }
                case CharacterID.RobinHood:
                {
                    character.Info.Damage.Current += 100;
                    break;
                }
            }

        }
            
        public void ActivateSkill2(string characterID,SkillName skillName)
        {
            if (skillName != SkillName.Skill2) return;
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    var jumpVelocity = rigidbody2D.velocity;
                    jumpVelocity.x = skillForce;

                    rigidbody2D.velocity = jumpVelocity;
                    break;
                }
                case CharacterID.RobinHood:
                {
                    for (int i = 0; i < wayPoints.Length; i++)
                    {
                        var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.Arrow, wayPoints[i].position, wayPoints[i].rotation);
                        newObjectPooler.GetComponent<Arrow>().ShootArrow();

                        StartCoroutine(SkillDuration(newObjectPooler,3f));
                    }
                    break;
                }
            }
            
        }
        
        public void ActivateSkill3(string characterID,SkillName skillName)
        {
            if (skillName != SkillName.Skill3) return;
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.BigSword, wayPoints[1].position, wayPoints[1].rotation);
                    newObjectPooler.transform.DOScale(objectSize, objectSizeDuration);
                    newObjectPooler.transform.DOBlendableMoveBy(new Vector3(7f, 4f, 0), 1f);
                    newObjectPooler.transform.DORotate(new Vector3(0,0,-90), 1f);
                    
                    StartCoroutine(SkillDuration(newObjectPooler,3f));
                    break;
                }
                case CharacterID.RobinHood:
                {
                    var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.BigArrow, wayPoints[1].position, wayPoints[1].rotation);
                    newObjectPooler.transform.DOScale(objectSize, objectSizeDuration);
                    newObjectPooler.GetComponent<Arrow>().ShootArrow();
                    
                    StartCoroutine(SkillDuration(newObjectPooler,3f));
                    break;
                }
            }
        }

        private IEnumerator SkillDuration(GameObject gameObject,float duration)
        {
            yield return new WaitForSeconds(duration);
            gameObject.SetActive(false);
        }
    }
}
