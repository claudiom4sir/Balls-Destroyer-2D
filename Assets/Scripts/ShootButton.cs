using UnityEngine;

public class ShootButton : MonoBehaviour {

    PlayerWeapon playerWeapon;

    void Start()
    {
        playerWeapon = GetComponentInParent<ControlButtons>().GetPlayerWeapon();
        if (playerWeapon == null)
            Debug.LogError("playerWeapon is null");
    }

    public void OnClick()
    {
        if (playerWeapon.GetExistsBullet())
            return;
        playerWeapon.Shoot();
    }

}
