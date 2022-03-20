using System;
using SandBox.UI;
using TigerForge;
using TMPro;
using UI.ScreenFlow;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        private const int OneSecond = 1;
        private static readonly TimeSpan OneSecondTimeSpan = TimeSpan.FromSeconds(OneSecond);
        private static readonly TimeSpan EndCountdownTimeSpan = TimeSpan.FromSeconds(-OneSecond);


        [SerializeField] private TMP_Text timerText;
        [SerializeField] private ScreenRequest request;
        [SerializeField] private int secondsLeft = 15;


        private TimeSpan _countdownTimeSpan = new TimeSpan();

        private TimeSpan CountdownTimeSpan
        {
            get => _countdownTimeSpan;

            set
            {
                _countdownTimeSpan = value;
                timerText.SetText(_countdownTimeSpan.ToString());

                if (_countdownTimeSpan != EndCountdownTimeSpan) return;
                EventManager.EmitEventData(UIEventName.RequestScreen, request);
            }
        }


        private void OnEnable() => ReCountdown();
        private void OnDisable() => StopCountdown();

        private void ReCountdown()
        {
            CountdownTimeSpan = TimeSpan.FromSeconds(secondsLeft);
            InvokeRepeating(nameof(Countdown), OneSecond, OneSecond);
        }

        private void Countdown() => CountdownTimeSpan -= OneSecondTimeSpan;

        private void StopCountdown() => CancelInvoke(nameof(Countdown));
    }
}