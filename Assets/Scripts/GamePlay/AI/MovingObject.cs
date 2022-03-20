using System;
using DG.Tweening;
using GamePlay.Enum;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.AI
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private ObjectName objectName;
        [SerializeField] private MovingObjectSide movingObjectSide;
        [SerializeField] private Transform endPoint;
        [SerializeField] private float duration;

        public ObjectName ObjectName=> objectName;
        void Start()
        {
            Moving();
        }

        private void Moving()
        {
            switch (movingObjectSide)
            {
                case MovingObjectSide.LeftRight:
                    switch (ObjectName)
                    {
                        case ObjectName.Saw:
                            transform.DOMove(new Vector3(endPoint.position.x, transform.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.Mace:
                            transform.DOMove(new Vector3(endPoint.position.x, transform.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.SpringMovingPlatform:
                            transform.DOMove(new Vector3(endPoint.position.x, transform.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.AutumnMovingPlatForm:
                            transform.DOMove(new Vector3(endPoint.position.x, transform.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.WinterMovingPlatForm:
                            transform.DOMove(new Vector3(endPoint.position.x, transform.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                    }
                    break;
                case MovingObjectSide.UpDown:
                    switch (ObjectName)
                    {
                        case ObjectName.Saw:
                            transform.DOMove(new Vector3(transform.position.x, endPoint.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.Mace:
                            transform.DOMove(new Vector3(transform.position.x, endPoint.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.SpringMovingPlatform:
                            transform.DOMove(new Vector3(transform.position.x, endPoint.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.AutumnMovingPlatForm:
                            transform.DOMove(new Vector3(transform.position.x, endPoint.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                        case ObjectName.WinterMovingPlatForm:
                            transform.DOMove(new Vector3(transform.position.x, endPoint.position.y, 0), duration)
                                .SetLoops(-1, LoopType.Yoyo);
                            break;
                    }
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            var characterTarget = collision2D.transform.GetComponent<Character.Character>();
            if (!characterTarget || characterTarget.Info.heroID == HeroID.Monster) return;

            characterTarget.Info.Health.Current -= 100;
        }
    }
}
