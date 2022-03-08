using TigerForge;
using UI;
using UnityEngine;

namespace SandBox.UI
{
    [DefaultExecutionOrder(100)]
    public class RequestScreenEventListener : MonoBehaviour
    {
        [SerializeField] private ScreenFrame screenFrame;

        private void Awake()
        {
            EventManager.StartListening(UIEventName.RequestScreen, OnRequestScreen);
        }

        private void OnRequestScreen()
        {
            var screenRequest = EventManager.GetData(UIEventName.RequestScreen);
            if (screenRequest is null) return;
        
            screenFrame.Request((ScreenRequest)screenRequest);
        }

  
    }

    public static class UIEventName
    {
        public const string RequestScreen = "RequestScreen";
    }
}