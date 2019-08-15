using UnityEngine;
using UnityEngine.UI;

namespace Core
{

    public class ScoreBoard : MonoBehaviour
    {
        int score = 0;
        Text scoreText;

        void Start()
        {
            scoreText = GetComponent<Text>();
            scoreText.text = score.ToString();
        }

        public void AddToScore(int points)
        {
            score += points;
            scoreText.text = score.ToString();
        }
    }

}