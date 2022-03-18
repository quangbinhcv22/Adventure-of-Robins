using TigerForge;
using UI;
using UI.ScreenFlow;
using UnityEngine;
using UnityEngine.UI;

namespace SandBox.UI
{
    public class RequestScreenButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ScreenRequest request;

        private void Awake()
        {
            button.onClick.AddListener(EmitRequestScreen);
        }
    
        private void EmitRequestScreen()
        {
            EventManager.EmitEventData(UIEventName.RequestScreen, request);
        }
    }
}
