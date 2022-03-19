using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace SandBox.Scripts
{
    public class PopUpText : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;

        public void SetUp(float damageValue)
        {
            text.SetText(damageValue.ToString());
        }
        
    }
}