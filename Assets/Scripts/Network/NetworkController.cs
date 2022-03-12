using System.Diagnostics;
using ExitGames.Client.Photon;
using GameEvent;
using Network.Events;
using Network.Messages;
using Newtonsoft.Json;
using Photon.Pun;
using Photon.Realtime;
using TigerForge;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Network
{
    public class NetworkConnector : MonoBehaviourPunCallbacks, IOnEventCallback
    {
        [SerializeField] private bool connectOnAwake = true;


        private readonly Stopwatch stopwatch = new Stopwatch();

        private const string ConnectingLog = "Connecting to server...";

        private string ConnectedLog =>
            $"Connected to <color=yellow>{PhotonNetwork.CloudRegion}</color> sever in <color=yellow>{stopwatch.ElapsedMilliseconds}</color> ms";


        public EventGroup events;
        
        public static NetworkConnector

        private void Awake()
        {
            if (connectOnAwake is false) return;

            LogConnectingStatus();

            stopwatch.Start();
            PhotonNetwork.ConnectUsingSettings();


            void LogConnectingStatus() => print(ConnectingLog);
        }

        public override void OnConnected()
        {
            stopwatch.Stop();

            LogConnectedStatus();
            EmitEventServerConnected();


            void LogConnectedStatus() => print(ConnectedLog);
            void EmitEventServerConnected() => EventManager.EmitEvent(EventName.Server.Connected);
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("On connected to master");
            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("On joined lobby");
            PhotonNetwork.JoinRandomOrCreateRoom();
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("On joined room");
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code != Message.StandardEvent) return;

            var response = JsonConvert.DeserializeObject<Response<object>>((string)photonEvent.CustomData);
            EventManager.EmitEventData(eventName: response.id, response);

            Debug.Log($"Response: <color=yellow>{photonEvent.CustomData}</color>");
        }
    }
}