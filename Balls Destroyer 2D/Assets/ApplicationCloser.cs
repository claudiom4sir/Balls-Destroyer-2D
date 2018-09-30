using System.Collections;
using UnityEngine;

public class ApplicationCloser : MonoBehaviour {

    [SerializeField] float timeBeforeQuit = 3f;

    void Start()
    {
        StartCoroutine(IQuit());
    }

    IEnumerator IQuit()
    {
        yield return new WaitForSeconds(timeBeforeQuit);
        Debug.Log("Quitting...");
        Application.Quit();
    }

}
