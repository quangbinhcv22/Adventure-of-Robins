using DG.Tweening;
using GamePlay.Enum;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterSkillActivate : MonoBehaviour
    {
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Character character;
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private float objectSize;
        [SerializeField] private float objectSizeDuration;

        public void ActivateSkill1()
        {
            var newObjectPooler = objectPooler.GetPooledObject(ObjectName.RotateSword);
            newObjectPooler.transform.SetParent(transform);

            var hideObject = objectPooler.HideObject(newObjectPooler, 3f);
            StartCoroutine(hideObject);
        }

        public void ActivateSkill2()
        {
            transform.DOMove(
                new Vector3((transform.position.x + 4f * (int) character.Info.side), transform.position.y,
                    transform.position.z), 1f);
        }

        public void ActivateSkill3()
        {
            var newObjectPooler = objectPooler.GetPooledObject(ObjectName.BigSword);
            newObjectPooler.transform.SetParent(transform);

            newObjectPooler.transform.position = character.transform.position;
            newObjectPooler.transform.rotation = Quaternion.Euler(0, 180 * (int) character.Info.side, 0);

            newObjectPooler.transform.DOScale(objectSize, objectSizeDuration);
            newObjectPooler.transform.DOBlendableMoveBy(new Vector3(10f * (int) character.Info.side, 4f, 0), 1f);
            newObjectPooler.transform.DORotate(new Vector3(0, 0, -90), 1f);

            var hideObject = objectPooler.HideObject(newObjectPooler, 3f);
            StartCoroutine(hideObject);
        }
    }
}