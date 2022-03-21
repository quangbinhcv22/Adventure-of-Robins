using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay.Character.Offline
{
    public class Scoring : MonoBehaviour
    {
        public string HighScoreKey = "highScore";
        public TMP_Text scoreText;
        private int scoreValue;
        public static Scoring Instance;

        public UnityEvent onGetPoint;
        public int Score
        {
            get => scoreValue;
            set
            {
                scoreValue = value;
                scoreText.text = scoreValue.ToString();
            }
        }
        private void Awake()
        {
            Instance = this;
            Score = 0;
        }
        public void UpdateHighScore()
        {
            var highScore = GetHighScore();
            if (Score > highScore)
            {
                SetHighScore(Score);
            }
        }
        public void SetHighScore(int highScore) => PlayerPrefs.SetInt(HighScoreKey, highScore);

        public int GetHighScore() => PlayerPrefs.GetInt(HighScoreKey, 0);
        
        public static void AddPoint(int score) => Scoring.Instance.Score += score * 10;
    }
}