using ExitGames.Client.Photon;
using Photon.Pun;
using SandBox.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Network
{
    [RequireComponent(typeof(Button))]
    public class SelectCharacterButton : MonoBehaviour
    {
        [SerializeField] private HeroID heroID;

        private Button _button;

        public void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SelectCharacter);
        }

        private void SelectCharacter()
        {
            PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable { { "hero", heroID } });
            print(PhotonNetwork.LocalPlayer.CustomProperties["hero"]);
        }
    }
}