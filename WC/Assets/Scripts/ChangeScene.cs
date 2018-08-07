using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string scene;

    void OnMouseDown()
	{
        //Application.LoadLevel ("ThunderClanCamp");
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

}
