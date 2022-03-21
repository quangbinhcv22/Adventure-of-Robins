using System;
using Photon.Chat;
using SandBox.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay.Character.Offline
{
    public class ItemsCount : MonoBehaviour
    {
        [SerializeField] private TMP_Text coins;
        [SerializeField] private TMP_Text keys;
        [SerializeField] private GameFlow gameFlow;

        private int coinCount;
        private int keyCount;

        public int CoinCount
        {
            get => coinCount;
            set
            {
                coinCount = value;
                coins.text = coinCount.ToString();
            }
        }

        public int KeyCount
        {
            get => keyCount;
            set
            {
                keyCount = value;
                keys.text = keyCount.ToString();
            }
        }
        private void Start()
        {
            coinCount = 0;
            keyCount = 0;
        }
    }
}