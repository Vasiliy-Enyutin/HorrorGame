using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    #region Fields

    [SerializeField] private DoorAccessLevels accessLevel;
    [SerializeField] private Keys key;
    private PlayerInventory playerInventory;
    private Animator animator;
    private bool doorIsOpen = false;
    private bool pauseInteraction = false;
    private float waitTimer = 1f;


    #endregion

    #region Methods

    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        animator = GetComponent<Animator>();
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
            HUD.Instance.ShowDoorLockedHint();
            return;
        }

        if (pauseInteraction)
            return;

        if (!doorIsOpen)
        {
            if (accessLevel == DoorAccessLevels.open)
            {
                animator.Play("DoorOpen");
                doorIsOpen = true;
            }
            else if (accessLevel == DoorAccessLevels.locked)
            {
                HUD.Instance.ShowDoorKeyHint();
            }
            else if (accessLevel == DoorAccessLevels.key)
            {
                foreach (Keys playerKey in playerInventory.PlayerKeys)
                {
                    if (playerKey == key)
                    {
                        animator.Play("DoorOpen");
                        doorIsOpen = true;
                        break;
                    }
                }
                if (!doorIsOpen)
                    HUD.Instance.ShowDoorKeyHint();
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


