using System.Collections;
using DG.Tweening;
using GamePlay.Enum;
using GamePlay.Object;
using Other;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.MovementSimulation
{
    public class CharacterSkillActivate : MonoBehaviour
    {
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Character.Character character;
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private float objectSize;
        [SerializeField] private float objectSizeDuration;

        public void ActivateSkill1()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    var newObjectPooler = objectPooler.GetPooledObject(ObjectName.RotateSword);
                    newObjectPooler.transform.SetParent(transform);

                    var hideObject = objectPooler.HideObject(newObjectPooler, 3f);
                    StartCoroutine(hideObject);
                    break;
                }
                case HeroID.RobinHood:
                {
                    var newObjectPooler = objectPooler.GetPooledObject(ObjectName.Skill2RobinHood);
                    newObjectPooler.transform.SetParent(transform);

                    var activeBuff = newObjectPooler.GetComponent<Skill2RobinHood>().ActiveBuff();
                    
                    StartCoroutine(activeBuff);
                    StartCoroutine(PopUpDamage(100));
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
                    foreach (var arrow in wayPoints)
                    {
                        var newObjectPooler = objectPooler.GetPooledObject(ObjectName.TripleArrow);
                        newObjectPooler.transform.position = arrow.position;
                        newObjectPooler.transform.rotation = arrow.rotation;
                        
                        newObjectPooler.GetComponent<Arrow>().ShootArrow(character.Info.side);
                        
                        var hideSkill = objectPooler.HideObject(newObjectPooler, 3f);
                        StartCoroutine(hideSkill);
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
                    var newObjectPooler = objectPooler.GetPooledObject(ObjectName.BigSword);
                    newObjectPooler.transform.SetParent(transform);
                    
                    newObjectPooler.transform.position = wayPoints[1].position;
                    newObjectPooler.transform.rotation = wayPoints[1].rotation;
                    
                    newObjectPooler.transform.DOScale(objectSize, objectSizeDuration);
                    newObjectPooler.transform.DOBlendableMoveBy(new Vector3(7f, 4f, 0), 1f);
                    newObjectPooler.transform.DORotate(new Vector3(0, 0, -90), 1f);

                    var hideObject = objectPooler.HideObject(newObjectPooler, 3f);
                    StartCoroutine(hideObject);
                    break;
                }
                case HeroID.RobinHood:
                {
                    var newObjectPooler = objectPooler.GetPooledObject(ObjectName.BigArrow);
                    newObjectPooler.transform.SetParent(transform);
                    
                    newObjectPooler.transform.position = wayPoints[1].position;
                    newObjectPooler.transform.rotation = wayPoints[1].rotation;
                    
                    newObjectPooler.transform.DOScale(objectSize, objectSizeDuration);
                    newObjectPooler.GetComponent<Arrow>().ShootArrow(character.Info.side);

                    var hideObject = objectPooler.HideObject(newObjectPooler, 3f);
                    StartCoroutine(hideObject);
                    break;
                }
            }
        }


        private IEnumerator PopUpDamage(float damage)
        {
            BuffDamageText(damage);
            yield return new WaitForSeconds(3f);
            DebuffDamageText(damage);
        }

        private void BuffDamageText(float damage)
        {
            var newDamageText = objectPooler.GetPooledObject(ObjectName.PopUptext);
            newDamageText.gameObject.GetComponent<PopUpText>().SetUp(damage);
            newDamageText.transform.DOMove(
                new Vector2(transform.position.x, transform.position.y + 2), 1f);
            var hideObject = objectPooler.HideObject(newDamageText, 3f);
            StartCoroutine(hideObject);
        }

        private void DebuffDamageText(float damage)
        {
            var newDamageText = objectPooler.GetPooledObject(ObjectName.PopUptext);
            newDamageText.gameObject.GetComponent<PopUpText>().SetUp(-damage);
            newDamageText.transform.DOMove(
                new Vector2(transform.position.x, transform.position.y + 2), 1f);
            var hideObject = objectPooler.HideObject(newDamageText, 3f);
            StartCoroutine(hideObject);
        }
    }
}