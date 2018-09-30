using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    bool existsBullet;
    GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.singleton;    
    }

    public void Shoot()
    {
        if (existsBullet)
            return;
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        existsBullet = true;
    }

    void Update() // used only for test on pc
    {
        if (gameManager.IsGameOver() || gameManager.IsLevelCompleted() || gameManager.IsLevelCompleted())
            return;
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    public void SetExistsBullet(bool value)
    {
        existsBullet = value;
    }

    public bool GetExistsBullet()
    {
        return existsBullet;
    }

}
