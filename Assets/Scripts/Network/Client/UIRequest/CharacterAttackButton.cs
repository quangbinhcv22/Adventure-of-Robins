using Network.Events;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterAttackButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(SendRequest);
        }
        
        void SendRequest()
        {
            var request = new CharacterAttackRequest { characterId = PhotonNetwork.AuthValues.UserId};
            NetworkController.Instance.events.characterAttack.SendRequest(request);
        }
    }
}