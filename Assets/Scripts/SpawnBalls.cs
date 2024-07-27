using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBalls : MonoBehaviour
{
    public Ball BallPrefab;
    public Vector3 SpawnPosition;
    public List<Ball> Balls;
    public Text Txt;
    public Transform SpawnParent;

    int bestScore;
    int spawnBallsCounter;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Best")) // Если у нас есть сохранение под именем Best
        {
            bestScore = PlayerPrefs.GetInt("Best"); // Записываем данные из сохранения "Best" в переменную bestScore
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        foreach (Ball ball in Balls)
        {
            if (!ball.gameObject.activeSelf) // Если мячик неактивный
            {
                ball.gameObject.SetActive(true);
                ball.transform.position = SpawnPosition;
                return; // Если if сработал, активируем шар и останавливаем цикл. Что бы все шары не активировать
            }
        }
        // Если сработает return, то программа не только остановит цикл, но и дальше код читать не будет внизу

        Ball ballPrefab = Instantiate(BallPrefab, SpawnPosition, Quaternion.identity);
        ballPrefab.transform.parent = SpawnParent; // Перемещает в инспекторе созданный шар в дочерний объект
        Balls.Add(ballPrefab); // Добавляем в лист созданный шар

        spawnBallsCounter++;
        Txt.text = "Ball Greates: " + spawnBallsCounter;

        if (spawnBallsCounter > bestScore)
        {
            bestScore = spawnBallsCounter;

            PlayerPrefs.SetInt("Best", bestScore);
        }

    }
}
