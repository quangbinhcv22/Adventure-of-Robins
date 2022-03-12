using System;
using Network.Messages;
using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(CharacterMoveEvent), menuName = "Server/Event/CharacterMove")]
    public class CharacterMoveEvent : ScriptableObject
    {
        [SerializeField] private Response<CharacterMoveResponse> response;

        public void SendRequest(CharacterMoveRequest request)
        {
            Message.Instance().SetID(EventName.Server.Character.Move).SetRequest(request).Send();
        }

        public Response<CharacterMoveResponse> OnResponse(Response<object> drawResponse)
        {
            response = drawResponse.ToType<CharacterMoveResponse>();
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