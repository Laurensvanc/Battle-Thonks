﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask m_TankMask;                        
    public ParticleSystem m_ExplosionParticles;       
    //public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                    
    public float m_ExplosionForce = 1000f;              
    public float m_MaxLifeTime = 2f;                    
    public float m_ExplosionRadius = 5f;                


    private void Start()
    {        
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            PlayerHealth targetHealth = targetRigidbody.GetComponent<PlayerHealth>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
            Debug.Log("Hit target");
        }

        // Unparent the particles from the shell.
        m_ExplosionParticles.transform.parent = null;

        // Play the particle system.
        m_ExplosionParticles.Play();

        // Play the explosion sound effect.
        //m_ExplosionAudio.Play();

        // Once the particles have finished, destroy the gameobject they are on.
        //NewMethod();

        Debug.Log("Shell Exploded");
        Destroy(gameObject);
    }

    private void NewMethod()
    {
        //Destroy(m_ExplosionParticles.gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {        
        Vector3 explosionToTarget = targetPosition - transform.position;
        
        float explosionDistance = explosionToTarget.magnitude;
        
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        float damage = relativeDistance * m_MaxDamage;
        
        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
