using System;
using Network.Messages;
using Newtonsoft.Json;
using SandBox.Scripts;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterNewEvent), menuName = "Server/Event/CharacterNew")]
    public class CharacterNewEvent : ScriptableObject
    {
        [NonSerialized] private Response<CharacterNewResponse> response;
        public Response<CharacterNewResponse> Response => response;

        public void SendRequest(CharacterNewRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.New).SetRequest(request).Send();
        }

        public Response<CharacterNewResponse> OnResponse(string message)
        {
            response = JsonConvert.DeserializeObject<Response<CharacterNewResponse>>(message);
            return response;
        }
    }

    [Serializable]
    public class CharacterNewRequest
    {
        public Vector2 spawnPoint;
        public string characterId;
        public HeroID heroID;
        public CharacterTeam team;
    }

    [Serializable]
    public class CharacterNewResponse
    {
        public Vector2 spawnPoint;
        public string characterId;
        public HeroID heroID;
        public CharacterTeam team;
    }
}