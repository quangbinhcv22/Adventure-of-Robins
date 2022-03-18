using Network.Events;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterSkill1Button : MonoBehaviour
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
            var request = new CharacterSkill1Request {characterId = characterId};

            NetworkController.Instance.events.characterSkill1.SendRequest(request);
        }
    }
}