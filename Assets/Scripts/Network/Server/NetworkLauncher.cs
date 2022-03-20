using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Network.Server
{
    public class NetworkLauncher : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            PhotonNetwork.NickName = Guid.NewGuid().ToString();

            PhotonNetwork.ConnectUsingSettings();

            // InvokeRepeating(nameof(LogTime), 0f, 1f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K)) LogTime();
        }

        void LogTime()
        {
            // Debug.Log(PhotonNetwork.CloudRegion);
            // if (PhotonNetwork.IsConnected) Debug.Log(

            // var b = PhotonNetwork.;
            // var c = PhotonNetwork.PlayerList;

            // print(b);
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }

        public override void OnJoinedLobby()
        {
            Debug.Log($"<color=yellow>Connected to server</color>");

            PhotonNetwork.CreateRoom("12345", new RoomOptions { MaxPlayers = 3 }, TypedLobby.Default);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"<color=yellow>Disconnect:</color> <color=orange>{cause}</color>");
        }

        public override void OnJoinedRoom()
        {
            var room = PhotonNetwork.CurrentRoom;
            Debug.Log($"<color=yellow>Joined room: </color><color=cyan>{room.Name}</color>");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.Log($"<color=yellow>Joined room failed: </color><color=orange>{message}</color>");
        }
    }
}