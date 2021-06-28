using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    #region Fields

    [SerializeField] private DoorAccessLevels accessLevel;
    private PlayerInventory playerInventory;
    private Animator animator;
    private bool doorIsOpen = false;
    private bool pauseInteraction = false;
    private float waitTimer = 1f;

    private HUD hud;

    #endregion

    #region Methods

    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        animator = GetComponent<Animator>();
        hud = FindObjectOfType<HUD>();
    }

    public void Interact()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        if (accessLevel == DoorAccessLevels.locked)
        {
            // sound locked door
            hud.ShowDoorLockedHint = true;
            return;
        }

        if (pauseInteraction)
            return;

        if (!doorIsOpen)
        {
            foreach (DoorAccessLevels key in playerInventory.Keys)
            {
                if (key == accessLevel)
                {
                    animator.Play("DoorOpen");
                    doorIsOpen = true;
                    break;
                }
            }
            if (!doorIsOpen)
            {
                hud.ShowDoorKeyHint = true;
            }
        }
        else
        {
            animator.Play("DoorClose");
            doorIsOpen = false;
        }

        StartCoroutine(PauseDoorInteraction());
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    #endregion
}


