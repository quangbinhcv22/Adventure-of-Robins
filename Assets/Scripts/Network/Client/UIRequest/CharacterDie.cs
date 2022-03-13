

using GamePlay.MovementSimulation;
using Network.Events;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterDieButton : MonoBehaviour
    {
        [SerializeField] private Character  character;
        [SerializeField] private string characterId => characterIdInput.text;
        [SerializeField] private TMP_InputField characterIdInput;
        
        private void Awake()
        {
            if (character.Info.health.Current == 0) SendRequest();
            
        }
        
        void SendRequest()
        {
           
            var request = new CharacterDieRequest { characterId = characterId};

            NetworkController.Instance.events.characterDie.SendRequest(request);
        }
    }
}