﻿using UnityEngine;

public class BallsManager : MonoBehaviour {

    public static BallsManager singleton;

    [SerializeField] GameObject firstBallPrefabs;
    [SerializeField] BallsSpawner ballsSpawner;

    int ballsInGame = 0;
    bool gameStarted;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    public GameObject GetFirstBallPrefabs()
    {
        return firstBallPrefabs;
    }

    public void StartGame(int ballsNumber)
    {
        ballsSpawner.CreateBalls(ballsNumber);
    }

    public void UpdateBallsInGame(string sign)
    {
        if (sign == "+")
            ballsInGame++;
        else if (sign == "-")
            ballsInGame--;
        if (ballsInGame == 0)
            GameManager.singleton.LevelCompleted();
    }

    

}
