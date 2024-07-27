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
        if (PlayerPrefs.HasKey("Best")) // ���� � ��� ���� ���������� ��� ������ Best
        {
            bestScore = PlayerPrefs.GetInt("Best"); // ���������� ������ �� ���������� "Best" � ���������� bestScore
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
            if (!ball.gameObject.activeSelf) // ���� ����� ����������
            {
                ball.gameObject.SetActive(true);
                ball.transform.position = SpawnPosition;
                return; // ���� if ��������, ���������� ��� � ������������� ����. ��� �� ��� ���� �� ������������
            }
        }
        // ���� ��������� return, �� ��������� �� ������ ��������� ����, �� � ������ ��� ������ �� ����� �����

        Ball ballPrefab = Instantiate(BallPrefab, SpawnPosition, Quaternion.identity);
        ballPrefab.transform.parent = SpawnParent; // ���������� � ���������� ��������� ��� � �������� ������
        Balls.Add(ballPrefab); // ��������� � ���� ��������� ���

        spawnBallsCounter++;
        Txt.text = "Ball Greates: " + spawnBallsCounter;

        if (spawnBallsCounter > bestScore)
        {
            bestScore = spawnBallsCounter;

            PlayerPrefs.SetInt("Best", bestScore);
        }

    }
}
