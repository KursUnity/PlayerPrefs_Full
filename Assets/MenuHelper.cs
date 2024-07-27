using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHelper : MonoBehaviour
{
    public Text BestTxt;
    int bestScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Best"))
        {
            bestScore = PlayerPrefs.GetInt("Best");
        }

        BestTxt.text = "Best Score: " + bestScore;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
}
