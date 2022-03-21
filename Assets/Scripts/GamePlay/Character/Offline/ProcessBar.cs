using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Character.Offline
{
    public class ProcessBar : MonoBehaviour
    {
        [SerializeField] public ProcessBarName processBarName;
        [SerializeField] private Image barValue;
        
        public void UpdateProcessBar(float currentValue,float maxValue)
        {
            var percent = currentValue / maxValue;
        
            barValue.fillAmount = percent;
        }       
    }
}