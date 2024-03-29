﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    //public AudioSource m_MovementAudio;
    //public AudioClip m_EngineIdling;
    //public AudioClip m_EngineDriving;
    public float m_PitchRange = 0.2f;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;   
    private float m_OriginalPitch;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;

        m_MovementInputValue = 0f;      
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void Start()
    {
        m_MovementAxisName = "Vertical";
        

        //m_OriginalPitch = m_MovementAudio.pitch;
    }

    private void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        
        //EngineAudio();
    }

    //void EngineAudio()
    //{
    //    if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f)
    //    {
    //        if (m_MovementAudio.clip == m_EngineDriving)
    //        {
    //            m_MovementAudio.clip = m_EngineIdling;
    //            m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
    //            m_MovementAudio.Play();
    //        }
    //    }
    //    else
    //    {
    //        if (m_MovementAudio.clip == m_EngineIdling)
    //        {
    //            m_MovementAudio.clip = m_EngineDriving;
    //            m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch = m_OriginalPitch + m_PitchRange);
    //            m_MovementAudio.Play();
    //        }
    //    }
    //}

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -2, 0);
        }
    }
}
