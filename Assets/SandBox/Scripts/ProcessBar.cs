using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace SandBox.Scripts
{
    public class ProcessBar : MonoBehaviour
    {
        [SerializeField] private Image valueBar;

        public void UpdateView(float currentValue, float maxValue)
        {
            // handle case denominator is 0
            if (maxValue == 0)
            {
                currentValue = 0;
                maxValue = 1;
            }

            var percent = currentValue / maxValue;
            Debug.Log($"{currentValue}/{maxValue}");
            UpdateView(percent);
        }

        public void UpdateView(float percentValue)
        {
            if (valueBar) valueBar.fillAmount = percentValue;
        }
    }
}