using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Network
{
    [RequireComponent(typeof(Button))]
    public class SelectCharacterButton : MonoBehaviourPunCallbacks
    {
        [SerializeField] private HeroID heroID;

        [SerializeField] [Space] private TMP_Text heroNameText;
        [SerializeField] private Color unSelectedColor;
        [SerializeField] private Color selectedColor;

        [SerializeField] [Space] private Color unSelectedButtonColor;
        [SerializeField] private Color selectedButtonColor;

        private Button _button;

        public void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SelectCharacter);
        }

        private void SelectCharacter()
        {
            PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable { { PlayerCustomProperty.Hero, (int)heroID } });
        }


        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            var isSelf = targetPlayer.UserId == PhotonNetwork.LocalPlayer.UserId;
            if (isSelf is false) return;

            var selectedHero = (HeroID)targetPlayer.CustomProperties[PlayerCustomProperty.Hero];
            var isSelected = selectedHero == heroID;

            _button.enabled = isSelected is false;
            _button.image.color = isSelected ? selectedButtonColor : unSelectedButtonColor;

            heroNameText.color = isSelected ? selectedColor : unSelectedColor;
        }
    }
}