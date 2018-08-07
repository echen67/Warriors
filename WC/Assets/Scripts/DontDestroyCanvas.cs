using UnityEngine;
using System.Collections;

public class DontDestroyCanvas : MonoBehaviour {

    public static GameObject self;

	void Awake()
    {
        if (self == null)
        {
            DontDestroyOnLoad(gameObject);
            self = gameObject;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }
    }
}
