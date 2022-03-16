using System;
using Network.Messages;
using Newtonsoft.Json;
using SandBox.Scripts;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterAttackEvent), menuName = "Server/Event/CharacterAttack")]
    public class CharacterAttackEvent : ScriptableObject
    {
        [NonSerialized] private Response<CharacterAttackResponse> response;
        public Response<CharacterAttackResponse> Response => response;

        public void SendRequest(CharacterAttackRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.Attack).SetRequest(request).Send();
        }

        public Response<CharacterAttackResponse> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterAttackResponse>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterAttackRequest
    {
        public string characterId;
    }

    [Serializable]
    public class CharacterAttackResponse
    {
        public string characterId;
    }
}