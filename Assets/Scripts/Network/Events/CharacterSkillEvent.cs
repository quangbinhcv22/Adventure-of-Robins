using System;
using Network.Messages;
using Newtonsoft.Json;
using SandBox.Scripts;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterSkillEvent), menuName = "Server/Event/CharacterSkill")]
    public class CharacterSkillEvent : ScriptableObject
    {
        [NonSerialized] private Response<CharacterSkillResponse> response;
        public Response<CharacterSkillResponse> Response => response;

        public void SendRequest(CharacterSkillRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.Skill).SetRequest(request).Send();
        }

        public Response<CharacterSkillResponse> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterSkillResponse>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterSkillRequest
    {
        public string characterId;
        
        public SkillName skillName;
    }

    [Serializable]
    public class CharacterSkillResponse
    {
        public string characterId;
        
        public SkillName skillName;
    }
}