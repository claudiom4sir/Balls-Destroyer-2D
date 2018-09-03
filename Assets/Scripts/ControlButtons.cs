using UnityEngine;

public class ControlButtons : MonoBehaviour
{

    [SerializeField] GameObject leftMoviment;
    [SerializeField] GameObject rightMoviment;
    [SerializeField] PlayerMotor playerMotor;

    void Start()
    {
        leftMoviment.GetComponent<MovimentButton>().SetLeftOrRight("Left");
        rightMoviment.GetComponent<MovimentButton>().SetLeftOrRight("Right");
    }

    public PlayerMotor GetPlayerMotor()
    {
        return playerMotor;
    }

}
