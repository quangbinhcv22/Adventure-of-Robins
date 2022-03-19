using System.Diagnostics;
using ExitGames.Client.Photon;
using GameEvent;
using Network.Events;
using Network.Messages;
using Newtonsoft.Json;
using Photon.Pun;
using Photon.Realtime;
using TigerForge;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;
using EventName = Network.Events.EventName;

namespace Network
{
    public class NetworkController : MonoBehaviourPunCallbacks, IOnEventCallback
    {
        private readonly Stopwatch stopwatch = new Stopwatch();

        private const string ConnectingLog = "Connecting to server...";

        private string ConnectedLog =>
            $"Connected to <color=yellow>{PhotonNetwork.CloudRegion}</color> sever in <color=yellow>{stopwatch.ElapsedMilliseconds}</color> ms";


        public static NetworkController Instance;

        public EventGroup events;

        [SerializeField] private bool connectOnAwake = true;
        [SerializeField] private TMP_Text logText;


        private void Awake()
        {
            Instance ??= this;

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
            // EmitEventServerConnected();


            void LogConnectedStatus() => print(ConnectedLog);
            // void EmitEventServerConnected() => EventManager.EmitEvent(EventName.Server.Connected);
        }

        public override void OnConnectedToMaster()
        {
            logText.SetText("On connected to master");
            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }

        public override void OnJoinedLobby()
        {
            logText.SetText("On joined lobby");
            PhotonNetwork.JoinRandomOrCreateRoom();
        }

        public override void OnJoinedRoom()
        {
            logText.SetText($"On joined room: {PhotonNetwork.CurrentRoom.Name}");
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code != Message.StandardEvent) return;

            var message = (string)photonEvent.CustomData;
            var response = JsonConvert.DeserializeObject<Response<object>>(message);

            switch (response.id)
            {
                case EventName.Server.Character.Attack:
                    events.characterAttack.OnResponse(message);
                    break;
                case EventName.Server.Character.Die:
                    events.characterDie.OnResponse(message);
                    break;
                case EventName.Server.Character.Jump:
                    events.characterJump.OnResponse(message);
                    break;
                case EventName.Server.Character.Move:
                    events.characterMove.OnResponse(message);
                    break;
                case EventName.Server.Character.New:
                    events.characterNew.OnResponse(message);
                    break;
                // case EventName.Server.Character.Skill:
                //     events.characterSkill.OnResponse(message);
                //     break;
                case EventName.Server.Character.Skill1:
                    events.characterSkill1.OnResponse(message);
                    break;
                case EventName.Server.Character.Skill2:
                    events.characterSkill2.OnResponse(message);
                    break;
                case EventName.Server.Character.Skill3:
                    events.characterSkill3.OnResponse(message);
                    break;
                case EventName.Server.Character.Select:
                    events.characterSelect.SelectCharacter(message);
                    break;
            }

            EventManager.EmitEventData(eventName: response.id, response);
            //Debug.Log($"Response: <color=yellow>{photonEvent.CustomData}</color>");
        }
    }
}