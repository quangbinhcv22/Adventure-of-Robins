using Photon.Pun;
using UnityEngine;

namespace Network.SandBox
{
    public class TestPlayerController : MonoBehaviourPun
    {
        [SerializeField] private new PhotonView photonView;
        [SerializeField] private float speed = 10f;

        private void FixedUpdate()
        {
            if (photonView.IsMine)
            {
                ProcessInput();
            }
        }

        private void ProcessInput()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var moveDirection = new Vector3(horizontalInput, default).normalized * speed;

            transform.position += moveDirection;
        }
    }
}