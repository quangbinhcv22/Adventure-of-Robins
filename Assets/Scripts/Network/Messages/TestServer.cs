using System;
using Network.Events;
using TigerForge;
using UnityEngine;

namespace Network.Messages
{
    public class TestServer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventManager.StartListening("MoveCharacter", OnMoveCharacter);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // NetworkController.Instance.events.characterMove.SendRequest(new CharacterMoveRequest{characterId = "Valhein", direction = 1});
            }
        }

        public void OnMoveCharacter()
        {
            EventManager.GetData("MoveCharacter");
        }
    }
}