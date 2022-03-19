using TMPro;
using UnityEngine;

namespace Other
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