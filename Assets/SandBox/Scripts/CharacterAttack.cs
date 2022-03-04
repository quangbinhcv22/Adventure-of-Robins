using System.Collections;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private GameObject hitBox;
        void Start()
        {
            HideHitBox();
        }

        public IEnumerator Attacking()
        {
            yield return new WaitForSeconds(0.5f);
            ShowHitBox();
            yield return new WaitForSeconds(1f);
            HideHitBox();
        }
        private void ShowHitBox()
        {
            if (hitBox.gameObject != null) hitBox.gameObject.SetActive(true);
        }

        private void HideHitBox()
        {
            if (hitBox.gameObject != null) hitBox.gameObject.SetActive(false);
        }
    }
}
