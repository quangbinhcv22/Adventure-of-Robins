using System;
using Network.Messages;
using Newtonsoft.Json;
using SandBox.Scripts;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterDieEvent), menuName = "Server/Event/CharacterDie")]
    public class CharacterDieEvent : ScriptableObject
    {
        [NonSerialized] private Response<CharacterDieResponse> response;
        public Response<CharacterDieResponse> Response => response;

        public void SendRequest(CharacterDieRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.Die).SetRequest(request).Send();
        }

        public Response<CharacterDieResponse> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterDieResponse>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterDieRequest
    {
        public string characterId;
    }

    [Serializable]
    public class CharacterDieResponse
    {
        public string characterId;
    }
}