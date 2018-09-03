using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    bool existsBullet;

    public void Shoot()
    {
        if (existsBullet)
            return;
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        existsBullet = true;
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
