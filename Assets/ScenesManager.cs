using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenesManager : MonoBehaviour {

    public static ScenesManager singleton;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void ChangeScene(string sceneName, float waitTime)
    {
        StartCoroutine(IChangeScene(sceneName, waitTime));
    }

    IEnumerator IChangeScene(string sceneName, float waitTime)
    {
        if (waitTime > 0)
            yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }

}
