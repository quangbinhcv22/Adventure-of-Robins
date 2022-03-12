using System;
using Network.Messages;
using Newtonsoft.Json;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterMoveEvent), menuName = "Server/Event/CharacterMove")]
    public class CharacterMoveEvent : ScriptableObject
    {
        [NonSerialized] private Response<CharacterMoveResponse> response;
        public Response<CharacterMoveResponse> Response => response;

        public void SendRequest(CharacterMoveRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.Move).SetRequest(request).Send();
        }

        public Response<CharacterMoveResponse> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterMoveResponse>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterMoveRequest
    {
        public string characterId;
        public int direction;
    }

    [Serializable]
    public class CharacterMoveResponse
    {
        public string characterId;
        public int direction;
    }
}