using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Character.Offline
{
    public class GameOverCanvas : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
            // currentScoreText.text = Scoring.Instance.Score.ToString();
            // highScoreText.text = Scoring.Instance.GetHighScore().ToString();
            // Scoring.Instance.UpdateHighScore();
        }
        public void Hide() => gameObject.SetActive(false);
        public void OnQuitBtnClicked() => SceneManager.LoadScene("MainMenu");
    }
}
