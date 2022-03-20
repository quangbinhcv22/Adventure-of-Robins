using Photon.Pun;
using Photon.Realtime;
using QBStudio.Collection;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Network
{
    public class SelectedHero : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Color unSelectedColor;
        [SerializeField] private Color selectedColor;

        [SerializeField] private Image hero;
        [SerializeField] private SafeQueryDictionary<HeroID, Sprite> heroSprites;

        public void UpdateView(Player player)
        {
            var isValidPlayer = player != null;

            gameObject.SetActive(isValidPlayer);
            if (isValidPlayer is false) return;

            text.SetText(player.NickName);
            text.color = player.UserId == PhotonNetwork.LocalPlayer.UserId ? selectedColor : unSelectedColor;

            var selectedHero = player.CustomProperties[PlayerCustomProperty.Hero];
            var isSelectHero = selectedHero != null;

            hero.gameObject.SetActive(isSelectHero);
            if (isSelectHero) hero.sprite = heroSprites[(HeroID)selectedHero];
        }
    }
}