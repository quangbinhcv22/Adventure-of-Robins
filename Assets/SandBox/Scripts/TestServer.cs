using System;
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
        }
    }
}