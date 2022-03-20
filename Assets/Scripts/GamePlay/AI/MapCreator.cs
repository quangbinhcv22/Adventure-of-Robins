using Network.Events;
using SandBox.UI;
using TigerForge;
using UI.ScreenFlow;
using UnityEngine;

namespace GamePlay.AI
{
    public class MapCreator : MonoBehaviour
    {
        [SerializeField] private GameObject map;
        [SerializeField] private ScreenRequest screenRequest;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Battle.Start, OnStartGame);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Battle.Start, OnStartGame);
        }

        private void OnStartGame()
        {
            Instantiate(map);
            EventManager.EmitEventData(UIEventName.RequestScreen, screenRequest);
        }
    }
}