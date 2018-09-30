using UnityEngine;
using System.Collections;

public class BallsSpawner : MonoBehaviour {

    [SerializeField] float timeBetweenballsSpawn = 0.5f;
    GameObject firstBall;
    Transform[] ballsSpawnPoints;
    BallsManager ballsManager;

    void Awake()
    {
        ballsManager = BallsManager.singleton;
        ballsSpawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < ballsSpawnPoints.Length; i++)
            ballsSpawnPoints[i] = transform.GetChild(i);
    }

    public void CreateBalls(int ballsNumber)
    {
        firstBall = ballsManager.GetFirstBallPrefabs();
        StartCoroutine(ICreateBall(ballsNumber));
    }

    IEnumerator ICreateBall(int ballsNumber)
    {
        for(int i = 0; i < ballsNumber; i++)
        {
            if (i >= ballsSpawnPoints.Length) // to avoid indexOutOfBound exception
                i = 0;
            SpawnsBall(i);
            yield return new WaitForSeconds(timeBetweenballsSpawn);
        }
    }

    void SpawnsBall(int indexOfSpawnPoint)
    {
        GameObject ball =  Instantiate(firstBall, ballsSpawnPoints[indexOfSpawnPoint].position, Quaternion.identity);
        ball.GetComponent<Ball>().AddInitialForce();
        ballsManager.UpdateBallsInGame("+");
    }

}
