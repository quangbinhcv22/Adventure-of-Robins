using Network.Events;
using Photon.Pun;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterSelectButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private HeroID heroID;
        
        private void Awake()
        {
            button.onClick.AddListener(SendRequest);
        }
        
        void SendRequest()
        {
            var request = new CharacterSelectRequest { characterId = PhotonNetwork.AuthValues.UserId,heroID = heroID};
            
            NetworkController.Instance.events.characterSelect.GetHeroList(request);
        }
    }
}