

using GamePlay.MovementSimulation;
using Network.Events;
using Photon.Pun;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterDieButton : MonoBehaviour
    {
        [SerializeField] private Character  character;

        private void Awake()
        {
            if (character.Info.health.Current == 0) SendRequest();
            
        }
        
        void SendRequest()
        {
            var request = new CharacterDieRequest { characterId = PhotonNetwork.AuthValues.UserId};
            NetworkController.Instance.events.characterDie.SendRequest(request);
        }
    }
}