using System;
using Network.Messages;
using Newtonsoft.Json;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterStartGameEvent), menuName = "Server/Event/CharacterNew")]
    public class CharacterStartGameEvent : ScriptableObject
    {

        public void SendRequest()
        {
            Message.Instance().SetID(EventName.Server.Character.New).Send();
        }

        public Response<CharacterNewResponse> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterNewResponse>>(message);
            return response;
        }
    }
}