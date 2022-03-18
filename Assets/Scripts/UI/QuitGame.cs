using UnityEngine;

namespace UI
{
    public class QuitGame : MonoBehaviour
    {
        public void EndGame()
        {
            Application.Quit();
            Debug.Log("Quit!");
        }
    }
}
