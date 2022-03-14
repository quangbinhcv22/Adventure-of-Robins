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

        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float skillForce;
        [SerializeField] private float objectSize;
        [SerializeField] private float objectSizeDuration;

        public void ActivateSkill1()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.RotateSword, wayPoints[0].localPosition, wayPoints[0].rotation);
                    newObjectPooler.GetComponentInParent<Character>();
                    
                    StartCoroutine(SkillDuration(newObjectPooler,3f));
                    break;
                }
                case HeroID.RobinHood:
                {
                    var characterTransform = character.transform;
                    var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.Skill2RobinHood,characterTransform.position, characterTransform.rotation);
                    var activeBuff = newObjectPooler.GetComponent<Skill2RobinHood>().ActiveBuff();
                    
                    StartCoroutine(activeBuff);
                    
                    break;
                }
            }

        }
            
        public void ActivateSkill2()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    var characterTransform = character.transform;
                    var position = characterTransform.position;
                    position = new Vector2(position.x + 2f, position.y);
                    
                    characterTransform.position = position;
                    
                    break;
                }
                case HeroID.RobinHood:
                {
                    for (int i = 0; i < wayPoints.Length; i++)
                    {
                        var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.TripleArrow, wayPoints[i].position, wayPoints[i].rotation);
                        newObjectPooler.GetComponent<Arrow>().ShootArrow();

                        StartCoroutine(SkillDuration(newObjectPooler,3f));
                    }
                    break;
                }
            }
            
        }
        
        public void ActivateSkill3()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    var newObjectPooler = objectPooler.SpawnFromPool(ObjectName.BigSword, wayPoints[1].position, wayPoints[1].rotation);
                    newObjectPooler.transform.DOScale(objectSize, objectSizeDuration);
                    newObjectPooler.transform.DOBlendableMoveBy(new Vector3(7f, 4f, 0), 1f);
                    newObjectPooler.transform.DORotate(new Vector3(0,0,-90), 1f);
                    
                    StartCoroutine(SkillDuration(newObjectPooler,3f));
                    break;
                }
                case HeroID.RobinHood:
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
