using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<int> playerScores;
    [SerializeField] private List<TextMeshProUGUI> playerScoreTexts;

    private static GameManager instance;
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    /// <summary>
    /// When the ball enters either Player's goal, increase the score by 1 to the player who scored
    /// </summary>
    public static void IncrementScore(PlayerType playerType)
    {
        if (instance == null)
        {
            return;
        }
        
        if (instance.playerScoreTexts.Count <= (int) playerType)
        {
            return;
        }
        
        instance.playerScores[(int) playerType]++;
        TextMeshProUGUI scoreText = instance.playerScoreTexts[(int)playerType];
        scoreText.text = instance.playerScores[(int)playerType].ToString();
    }

}
