using System;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Network.SandBox
{
    public class TestPlayerController : MonoBehaviour
    {
        [SerializeField] private new PhotonView photonView;
        [SerializeField] private Transform flipModel;
        [SerializeField] private float speed = 10f;

        [SerializeField] private int health = 100;

        private int Health
        {
            get => health;
            set
            {
                health = value;
                healthText.SetText(health.ToString());

                if (health <= 0) PhotonNetwork.Destroy(gameObject);
            }
        }

        [SerializeField] private TMP_Text healthText;

        private void Awake()
        {
            if (!photonView.IsMine) Destroy(this);

            Health = 3;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Health++;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Health--;
            }
        }

        private void FixedUpdate()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var moveDirection = new Vector3(horizontalInput, default).normalized * speed;

            transform.position += moveDirection;

            var isFlipModel = horizontalInput != 0;
            var flipEuler = horizontalInput > 0 ? Vector3.zero : new Vector3(default, -180f);

            if (isFlipModel) flipModel.rotation = Quaternion.Euler(flipEuler);
        }
    }
}