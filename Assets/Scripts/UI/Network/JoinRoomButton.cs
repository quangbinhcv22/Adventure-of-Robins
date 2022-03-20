using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Network
{
    [RequireComponent(typeof(Button))]
    public class JoinRoomButton : MonoBehaviourPunCallbacks
    {
        private Button _button;

        public void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(JoinRoom);
        }

        private static void JoinRoom() => PhotonNetwork.JoinRandomRoom();
    }
}