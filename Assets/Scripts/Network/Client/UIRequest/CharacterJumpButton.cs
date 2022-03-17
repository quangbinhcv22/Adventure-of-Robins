using System;
using Network.Events;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterJumpButton : MonoBehaviour
    {
        [SerializeField] private Button button;


        private void Awake()
        {
            button.onClick.AddListener(SendRequest);
        }

        void SendRequest()
        {
            var request = new CharacterJumpRequest {characterId = PhotonNetwork.AuthValues.UserId};
            NetworkController.Instance.events.characterJump.SendRequest(request);
        }
    }
}