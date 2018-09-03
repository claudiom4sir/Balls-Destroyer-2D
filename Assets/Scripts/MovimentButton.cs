using UnityEngine;

public class MovimentButton : MonoBehaviour {

    [SerializeField] bool leftButton;
    [SerializeField] bool rightButton;
    PlayerMotor playerMotor;

    void Start()
    {
        playerMotor = GetComponentInParent<MovimentButtons>().GetPlayerMotor(); ;
        if (playerMotor == null)
            Debug.LogError("playerMotor is null");
        if (leftButton && rightButton || !leftButton && !rightButton)
            Debug.LogError("Only one of right or left buttons must be checked, not both or anyone");
    }

    public void SetLeftOrRight(string buttonName)
    {
        if (buttonName == "Left")
        {
            leftButton = true;
            rightButton = false;
        }
        else if (buttonName == "Right")
        {
            leftButton = false;
            rightButton = true;
        }
        else
            Debug.LogError("buttonName argument is not valid");
    }

    public void OnPressing()
    {
        InvokeRepeating("Move", 0f, Time.deltaTime);
    }

    void Move()
    {
        if (leftButton && !rightButton)
            playerMotor.SetDirection(-1);
        else if (!leftButton && rightButton)
            playerMotor.SetDirection(1);
    }

    public void OnStopPressing() 
    {
        CancelInvoke("Move");
        playerMotor.SetDirection(0);
    }

}
