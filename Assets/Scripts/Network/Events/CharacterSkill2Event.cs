using System;
using Network.Messages;
using Newtonsoft.Json;
using SandBox.Scripts;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterSkill2Event), menuName = "Server/Event/CharacterSkill2")]
    public class CharacterSkill2Event : ScriptableObject
    {
        [NonSerialized] private Response<CharacterSkill2Response> response;
        public Response<CharacterSkill2Response> Response => response;

        public void SendRequest(CharacterSkill2Request request)
        {
            Message.Instance().SetID(EventName.Server.Character.Skill2).SetRequest(request).Send();
        }

        public Response<CharacterSkill2Response> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterSkill2Response>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterSkill2Request
    {
        public string characterId;
        public HeroID side;
        
    }

    [Serializable]
    public class CharacterSkill2Response
    {
        public string characterId;
        public HeroID side;
        
    }
}