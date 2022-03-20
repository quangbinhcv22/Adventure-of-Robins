using Photon.Pun;
using UnityEngine;

namespace Network.SandBox
{
    public class TestCharacterManager : MonoBehaviour
    {
        public GameObject playerPrefab;

        private void Awake()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        }
    }
}