using System.Collections.Generic;
using Network;
using Photon.Pun;
using SandBox.Scripts;
using TigerForge;
using UI.Network;
using Unity.Mathematics;
using UnityEngine;
using EventName = Network.Events.EventName;


namespace GamePlay.MovementSimulation
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private List<Character.Character> characterPrefabs;
        [SerializeField] private Vector3 spawnPoint;

        // private void OnEnable()
        // {
        //     EventManager.StartListening(EventName.Server.Character.New, OnNew);
        // }
        //
        // private void OnDisable()
        // {
        //     EventManager.StopListening(EventName.Server.Character.New, OnNew);
        // }
        //
        // private void OnNew()
        // {
        //     var newResponse = NetworkController.Instance.events.characterNew.Response.data;
        //     
        //     var characterPrefab = characterPrefabs.Find(prefab => prefab.Info.heroID == newResponse.heroID);
        //
        //     var newCharacter = Instantiate(characterPrefab);
        //
        //     newCharacter.transform.position = newResponse.spawnPoint;
        //     newCharacter.Info.team = newResponse.team;
        //     newCharacter.Info.id = newResponse.characterId;
        // }

        private void OnEnable()
        {
            var selectedHeroID = (HeroID) PhotonNetwork.LocalPlayer.CustomProperties[PlayerCustomProperty.Hero];
            var characterPrefab = characterPrefabs.Find(prefab => prefab.Info.heroID == selectedHeroID);

            var newCharacter = PhotonNetwork.Instantiate(characterPrefab.name, spawnPoint, quaternion.identity);
            Debug.Log(characterPrefab.name);
            // newCharacter.Info.team = newResponse.team;
            // newCharacter.Info.id = newResponse.characterId;
        }
    }
}