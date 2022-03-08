using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace SandBox.Scripts
{
    public class CharacterSkillActivate : MonoBehaviour
    {
        [SerializeField] private Transform wayPoints;
        [SerializeField] private ObjectRotator objectRotator;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float skill2Force;
        [SerializeField] private float duration;
        
        public void ActivateSkill1()
        {
            StartCoroutine(SkillActive(objectRotator.gameObject));
        }
            
        public void ActivateSkill2()
        {
            var jumpVelocity = rigidbody2D.velocity;
            jumpVelocity.x = skill2Force;

            rigidbody2D.velocity = jumpVelocity;
        }
        
        public void ActivateSkill3()
        {
            var skill3 = Instantiate(objectRotator.gameObject,wayPoints);
            skill3.transform.DOScale(3f, 1f);
            StartCoroutine(SkillActive(skill3));
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
