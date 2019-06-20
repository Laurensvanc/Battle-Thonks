using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    public int secondsToDestroy = 5;

    public float speed = 70;


    void Update()
    {
        Destroy(this, secondsToDestroy);
        return;
    }
}
