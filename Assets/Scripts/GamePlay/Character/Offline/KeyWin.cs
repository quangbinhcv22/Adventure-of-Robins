using System;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class KeyWin : MonoBehaviour
    {
        [SerializeField] private GameFlow gameFlow;

        private void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.GetComponent<Character>();
            if (target && target.Info.id == "Player")
            {
                Destroy(gameObject);
                gameFlow.OnPlayerWin();
            }
        }
    }
}
