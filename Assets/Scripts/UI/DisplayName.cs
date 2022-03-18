using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DisplayName : MonoBehaviour
    {
        public string nameOfPlayer;
        public string saveName;
        public TMP_Text inputName;
        public TMP_Text displayName;

        private void Start()
        {
            inputName.text = PlayerPrefs.GetString("user_name");
        }

        private void Update()
        {
            nameOfPlayer = PlayerPrefs.GetString("name", "none");
            displayName.text = nameOfPlayer;
        }

        public void SetName()
        {
            saveName = inputName.text;
            PlayerPrefs.SetString("user_name", saveName);
            PlayerPrefs.Save();
        }
    }
}
