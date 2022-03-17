using System;
using ExitGames.Client.Photon;
using Network;
using Network.Events;
using Photon.Pun;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class TestServer : MonoBehaviour
    {
        public ObjectPooler objectPooler;
        private void Update()
        {
            // EventManager.EmitEventData("CharacterMove",
            //     new CharacterMovement(HeroID.Gladiator,new Vector2(1,0)) );
            // EventManager.EmitEventData("CharacterJump",
            //     new CharacterMovement(HeroID.Gladiator,new Vector2(0,1)) );
            //EventManager.EmitEventData("CharacterAttack",CharacterAttack);
            // EventManager.EmitEventData("CharacterTakeDame",CharacterTakeDame);
            // if (Input.GetKey(KeyCode.Space))
            // {
            //    var newDamageText = objectPooler.SpawnFromPool(ObjectName.PopUptext, transform.position, transform.rotation);
            //    newDamageText.gameObject.GetComponent<PopUpText>().SetUp(100);
            // }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NetworkController.Instance.events.characterNew.SendRequest(new CharacterNewRequest()
                    {characterId = PhotonNetwork.AuthValues.UserId,heroID = HeroID.Gladiator,team = CharacterTeam.Blue,spawnPoint = new Vector2(-2,-3.5f)});
            }
        }
    }
}