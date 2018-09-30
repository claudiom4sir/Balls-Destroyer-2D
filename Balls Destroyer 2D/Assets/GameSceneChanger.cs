using UnityEngine;

public class GameSceneChanger : MonoBehaviour
{

    [SerializeField] float timeBeforeChangeScene = 3f;

    void Start()
    {
        ScenesManager.singleton.ChangeScene("GameScene", timeBeforeChangeScene);    
    }

}
