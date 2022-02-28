using System;
using System.Diagnostics;
using GameEvent;
using Photon.Pun;
using TigerForge;
using UnityEngine;

namespace Network
{
    public class NetworkConnector : MonoBehaviourPunCallbacks
    {
        [SerializeField] private bool connectOnAwake = true;
        
        
        private readonly Stopwatch stopwatch = new Stopwatch();
        
        private const string ConnectingLog = "Connecting to server...";
        private string ConnectedLog => $"Connected to <color=yellow>{PhotonNetwork.CloudRegion}</color> sever in <color=yellow>{stopwatch.ElapsedMilliseconds}</color> ms";


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
    }
}