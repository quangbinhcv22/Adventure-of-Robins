using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;


namespace SandBox.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterInfo info;
        [SerializeField] private ObjectPooler objectPooler;
       
        public CharacterInfo Info => info;

        private void Start()
        {
            info.health.ResetCurrentByValue();
            info.damage.ResetCurrentByValue();
        }
    }
}