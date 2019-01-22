using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("AI Framework");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
