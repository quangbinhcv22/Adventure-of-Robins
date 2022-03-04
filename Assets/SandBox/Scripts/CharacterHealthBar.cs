using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace SandBox.Scripts
{
    public class CharacterHealthBar : MonoBehaviour
    {
        [SerializeField] private Image hpValueImage;
        [SerializeField] private bool isPersistance;
        [SerializeField] private Character character;
        

        private void UpdateHealthBar()
        {
            var healthStat = character.stats.GetStat(CharacterStatType.Health);
            hpValueImage.fillAmount = healthStat.current / healthStat.Value;
        }

        private void ShowInAwhile()
        {
            StartCoroutine(ShowHealthBarInAwhile());
        }

        private IEnumerator ShowHealthBarInAwhile()
        {
            Show();
            yield return new WaitForSeconds(1f);
            Hide();
        }

        private void Show() => hpValueImage.gameObject.SetActive(true);
        private void Hide() => hpValueImage.gameObject.SetActive(false);
    }
}