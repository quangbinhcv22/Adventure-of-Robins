using System;
using Network.Messages;
using Newtonsoft.Json;
using SandBox.Scripts;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterSkill1Event), menuName = "Server/Event/CharacterSkill1")]
    public class CharacterSkill1Event : ScriptableObject
    {
        [NonSerialized] private Response<CharacterSkill1Response> response;
        public Response<CharacterSkill1Response> Response => response;

        public void SendRequest(CharacterSkill1Request request)
        {
            Message.Instance().SetID(EventName.Server.Character.Skill1).SetRequest(request).Send();
        }

        public Response<CharacterSkill1Response> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterSkill1Response>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterSkill1Request
    {
        public string characterId;
        
    }

    [Serializable]
    public class CharacterSkill1Response
    {
        public string characterId;
        
    }
}