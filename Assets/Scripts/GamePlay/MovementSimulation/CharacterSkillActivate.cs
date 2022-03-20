using System;
using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using GamePlay.Enum;
using GamePlay.Object;
using Other;
using SandBox.Scripts;
using UnityEditorInternal;
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
                    transform.DOMove(new Vector3((transform.position.x + 4f * (int)character.Info.side),transform.position.y,transform.position.z),1f);
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
                    
                    newObjectPooler.transform.position = character.transform.position;
                    newObjectPooler.transform.rotation = Quaternion.Euler(0, 180 * (int)character.Info.side,0);
                    
                    newObjectPooler.transform.DOScale(objectSize, objectSizeDuration);
                    newObjectPooler.transform.DOBlendableMoveBy(new Vector3(10f* (int)character.Info.side, 4f, 0), 1f);
                    newObjectPooler.transform.DORotate(new Vector3(0, 0, -90), 1f);

                    var hideObject = objectPooler.HideObject(newObjectPooler, 3f);
                    StartCoroutine(hideObject);
                    break;
                }
                case HeroID.RobinHood:
                {
                    var newObjectPooler = objectPooler.GetPooledObject(ObjectName.BigArrow);
                    newObjectPooler.transform.SetParent(transform);
                    
                    newObjectPooler.transform.position = character.transform.position;
                    newObjectPooler.transform.rotation = character.transform.rotation;
                    
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