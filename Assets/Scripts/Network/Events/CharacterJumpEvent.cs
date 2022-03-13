using System;
using Network.Messages;
using Newtonsoft.Json;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterJumpEvent), menuName = "Server/Event/CharacterJump")]
    public class CharacterJumpEvent : ScriptableObject
    {
        [NonSerialized] private Response<CharacterJumpResponse> response;
        public Response<CharacterJumpResponse> Response => response;

        public void SendRequest(CharacterJumpRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.Jump).SetRequest(request).Send();
        }
        
        public Response<CharacterJumpResponse> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterJumpResponse>>(message);
            return response;
        }
    }
    
    [Serializable]
    public class CharacterJumpRequest
    {
        public string characterId;
    }
    
    [Serializable]
    public class CharacterJumpResponse
    {
        public string characterId;
    }
}
