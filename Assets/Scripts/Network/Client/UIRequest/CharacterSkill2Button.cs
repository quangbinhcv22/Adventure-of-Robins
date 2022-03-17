using System;
using Network.Events;
using Photon.Pun;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Client.UIRequest
{
    public class CharacterSkill2Button : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image skillIcon;
        [SerializeField] private float duration;

        private float lastTime;
        private bool _isCoolingDown;
        
        private void Awake()
        {
            button.onClick.AddListener(SendRequest);
        }
        
        void SendRequest()
        {
            var request = new CharacterSkill2Request { characterId = PhotonNetwork.AuthValues.UserId};
            NetworkController.Instance.events.characterSkill2.SendRequest(request);
        }
        
        public void StartCoolDownSkill(Button button)
        {
            StartCoroutine(CharacterCoolDownSkill.CoolDownSkill(button,duration));
            _isCoolingDown = true;
            lastTime = Time.time;
        }

        private void Update()
        {
            if (!_isCoolingDown) return;
            var elapsedTime = Time.time - lastTime;

            if (elapsedTime >= duration)
            {
                _isCoolingDown = false;
            }
            else
            {
                skillIcon.fillAmount = elapsedTime / duration;
            }
        }
    }
}