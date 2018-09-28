using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager singleton;

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
}
