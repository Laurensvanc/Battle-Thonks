using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTank : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);            
        }
    }
}
