using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    public string sceneName;
    public Vector2 vector;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = vector;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
