﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    public void ChangeScene()
    {
        SceneManager.LoadScene("ThonkGround", LoadSceneMode.Single);
    }

}