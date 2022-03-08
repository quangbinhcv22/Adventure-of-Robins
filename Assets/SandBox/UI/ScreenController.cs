using TigerForge;
using UI;
using UnityEngine;

namespace SandBox.UI
{
    [DefaultExecutionOrder(200)]
    public class ScreenController : MonoBehaviour
    {

        [SerializeField] private ScreenRequest requestOnAwake;
        private void Awake()
        {
            EventManager.EmitEventData(UIEventName.RequestScreen, requestOnAwake);
        }
    }
}
