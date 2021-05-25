using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private float moveSpeed = 5f;

    private CharacterController controller;
    private AudioSource audioSource;

    #endregion

    #region Methods

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        controller.Move(moveDirection * moveSpeed * Time.fixedDeltaTime);

        WalkAudioEffect(x, z);
    }

    private void WalkAudioEffect(float x, float z)
    {
        if (x != 0 || z != 0)
        {
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(AudioStorage.Instance.SFX_PlayerWalk);
        }
        else
            audioSource.Stop();
    }

    #endregion
}
