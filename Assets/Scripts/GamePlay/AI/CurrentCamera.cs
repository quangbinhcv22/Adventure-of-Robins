using System;
using Cinemachine;
using UnityEngine;

namespace GamePlay.AI
{
    public class CurrentCamera : MonoBehaviour
    {
        public static CurrentCamera Instance;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        

        private void Awake()
        {
            Instance = this;
        }

        public void FollowTarget(Transform target)
        {
            virtualCamera.Follow = target;
        }
    }
}
