using UnityEngine;

public class ControlButtons : MonoBehaviour
{

    [SerializeField] GameObject leftMoviment;
    [SerializeField] GameObject rightMoviment;
    [SerializeField] GameObject shoot;

    void Start()
    {
        leftMoviment.GetComponent<MovimentButton>().SetLeftOrRight("Left");
        rightMoviment.GetComponent<MovimentButton>().SetLeftOrRight("Right");
    }

    public PlayerMotor GetPlayerMotor()
    {
        GameObject player = GameManager.singleton.GetPlayer();
        PlayerMotor pm = player.GetComponent<PlayerMotor>();
        return pm;
    }

    public PlayerWeapon GetPlayerWeapon()
    {
        GameObject player = GameManager.singleton.GetPlayer();
        PlayerWeapon pw = player.GetComponent<PlayerWeapon>();
        return pw;
    }

}
