using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UI.Network
{
    public class SetNickNamePanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nickNameInput;
        [SerializeField] private Button confirmButton;

        private void Awake()
        {
            Assert.IsNotNull(nickNameInput);
            Assert.IsNotNull(confirmButton);

            confirmButton.onClick.AddListener(ConfirmNickName);
        }

        private void ConfirmNickName() => PhotonNetwork.NickName = nickNameInput.text;
    }
}