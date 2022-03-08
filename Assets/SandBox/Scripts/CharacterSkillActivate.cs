using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using static GameEvent.EventName;

namespace SandBox.Scripts
{
    public class CharacterSkillActivate : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private ObjectRotator objectRotator;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float skillForce;

        public void ActivateSkill1()
        {
            switch (character.ID)
            {
                case GameEvent.EventName.CharactorID.Gladiator:
                {
                    StartCoroutine(SkillActive(objectRotator.gameObject));
                    break;
                }
                case GameEvent.EventName.CharactorID.RobinHood:
                {
                    character.Damage.Current += 100;
                    break;
                }
            }
            
        }
            
        public void ActivateSkill2()
        {
            switch (character.ID)
            {
                case GameEvent.EventName.CharactorID.Gladiator:
                {
                    var jumpVelocity = rigidbody2D.velocity;
                    jumpVelocity.x = skillForce;

                    rigidbody2D.velocity = jumpVelocity;
                    break;
                }
                case GameEvent.EventName.CharactorID.RobinHood:
                {
                    for (int i = 0; i < wayPoints.Length; i++)
                    {
                        var skill2 = Instantiate(objectRotator.gameObject,wayPoints[i]);
                        ShowSkill(skill2);
                    }
                    break;
                }
            }
            
        }
        
        public void ActivateSkill3()
        {
            var skill3 = Instantiate(objectRotator.gameObject,wayPoints[1]);
            skill3.transform.DOScale(3f, 1f);
            switch (character.ID)
            {
                case GameEvent.EventName.CharactorID.Gladiator:
                {
                    StartCoroutine(SkillActive(skill3));
                    break;
                }
                case GameEvent.EventName.CharactorID.RobinHood:
                {
                    StartCoroutine(SkillActive(skill3));
                    break;
                }
            }
        }


        private IEnumerator SkillActive(GameObject skill)
        {
            ShowSkill(skill);
            yield return new WaitForSeconds(3f);
            HideSkill(skill);
        }
        private void HideSkill(GameObject skill)
        {
            skill.SetActive(false);
        }

        private void ShowSkill(GameObject skill)
        {
            skill.SetActive(true);
        }
        
    }
}
