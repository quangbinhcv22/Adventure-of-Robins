using System;
using Network.Messages;
using Newtonsoft.Json;
using SandBox.Scripts;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterSkill3Event), menuName = "Server/Event/CharacterSkill3")]
    public class CharacterSkill3Event : ScriptableObject
    {
        [NonSerialized] private Response<CharacterSkill3Response> response;
        public Response<CharacterSkill3Response> Response => response;

        public void SendRequest(CharacterSkill3Request request)
        {
            Message.Instance().SetID(EventName.Server.Character.Skill3).SetRequest(request).Send();
        }

        public Response<CharacterSkill3Response> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterSkill3Response>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterSkill3Request
    {
        public string characterId;
        
    }

    [Serializable]
    public class CharacterSkill3Response
    {
        public string characterId;
        
    }
}