using System;
using Network.Messages;
using Newtonsoft.Json;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterSelectEvent), menuName = "Server/Event/CharacterAttack")]
    public class CharacterSelectEvent : ScriptableObject
    {
        [NonSerialized] private Response<CharacterSelectResponse> response;
        public Response<CharacterSelectResponse> Response => response;

        public void GetHeroList(CharacterSelectRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.Select).SetRequest(request).Send();
        }

        public Response<CharacterSelectResponse> SelectCharacter(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterSelectResponse>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterSelectRequest
    {
        public string characterId;
    }

    [Serializable]
    public class CharacterSelectResponse
    {
        public string characterId;
    }
}