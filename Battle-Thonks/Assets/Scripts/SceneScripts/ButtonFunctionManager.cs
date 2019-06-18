using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    public void doChangeScene()
    {
        SceneManager.LoadScene("ThonkGround", LoadSceneMode.Single);
    }

    public void doExitGame()
    {
        Application.Quit();
    }

}
