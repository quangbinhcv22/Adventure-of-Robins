using Network.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterAttackButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private string characterId => characterIdInput.text;
        [SerializeField] private TMP_InputField characterIdInput;
        
        private void Awake()
        {
            button.onClick.AddListener(SendRequest);
        }
        
        void SendRequest()
        {
            var request = new CharacterAttackRequest { characterId = characterId};

            NetworkController.Instance.events.characterAttack.SendRequest(request);
        }
    }
}