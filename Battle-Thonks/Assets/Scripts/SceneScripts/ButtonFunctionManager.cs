using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionManager : MonoBehaviour
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
