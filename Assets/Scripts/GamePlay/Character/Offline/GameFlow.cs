using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Character.Offline
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameOverCanvas gameLoseCanvas;
        [SerializeField] private GameOverCanvas gameWinCanvas;
        private void Start()
        {
            gameLoseCanvas.Hide();
            gameWinCanvas.Hide();
        }
        public void OnPlayerDeath() => gameLoseCanvas.Show();
        public void OnPlayerWin() => gameWinCanvas.Show();
        public void OnQuitBtnClicked() => SceneManager.LoadScene("MainMenu");
    }
}
