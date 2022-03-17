using SandBox.UI;
using TigerForge;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private float secondsLeft = 15;
        [SerializeField] private ScreenRequest request;
        private bool _stopTimer;

        private void Start()
        {
            _stopTimer = false;
        }

        void Update()
        {
            var time = secondsLeft - Time.time;
            var minutes = Mathf.FloorToInt(time / 60);
            var seconds = Mathf.FloorToInt(time - minutes * 60f);
            var textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time <= 0)
            {
                _stopTimer = true;
                EventManager.EmitEventData(UIEventName.RequestScreen,request);
            }

            if (_stopTimer == false)
            {
                timerText.text = textTime;
            }
        }
    }
}
