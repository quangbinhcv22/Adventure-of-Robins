using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class Items : MonoBehaviour
    {
        [SerializeField] private int point;
        [SerializeField] private string name;
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private ItemsCount itemsCount;
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var target = collider2D.GetComponent<Character>();

            if (!target) return;
            if (target.Info.heroID == HeroID.Monster) return;
            
            Destroy(gameObject);
            
            switch (name)
            {
                case "Key":
                    itemsCount.KeyCount++;
                    Scoring.AddPoint(point);
                    break;
                case "Coin":
                    itemsCount.CoinCount++;
                    Scoring.AddPoint(point);
                    break;
            }
            
        }
    }
}