using ExitGames.Client.Photon;
using Newtonsoft.Json;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Network.Messages
{
    public class Message
    {
        public const byte StandardEvent = 1;

        private string _id;
        private object _data;

        public Message SetID(string id)
        {
            _id = id;
            return this;
        }

        public Message SetRequest(object data)
        {
            _data = data;
            return this;
        }

        public void Send()
        {
            var request = JsonConvert.SerializeObject(new Request { id = _id, data = _data });

            var raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(StandardEvent, request, raiseEventOptions, SendOptions.SendReliable);

            Debug.Log($"Request: <color=cyan>{request}</color>");
        }

        public static Message Instance()
        {
            return new Message();
        }
    }
}