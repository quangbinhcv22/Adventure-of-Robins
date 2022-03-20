using System;
using Network.Messages;
using Newtonsoft.Json;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(StartGameEvent), menuName = "Server/Event/StartGame")]
    public class StartGameEvent : ScriptableObject
    {
        public void SendRequest()
        {
            Message.Instance().SetID(EventName.Server.Battle.Start).Send();
        }
    }
}