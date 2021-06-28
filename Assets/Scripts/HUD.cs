using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : Singleton<HUD>
{
    #region Fields

    [SerializeField] private GameObject[] notes;
    [SerializeField] private GameObject interactHint;
    [SerializeField] private GameObject doorKeyHint;
    [SerializeField] private GameObject doorLockedHint;

    private GameObject activeHint;
    private GameObject activeNote;

    private PlayerMovement playerMovement;
    private MouseLook mouseLook;

    #endregion

    #region Methods

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        mouseLook = FindObjectOfType<MouseLook>();
    }

    private void Update()
    {
        if (activeNote != null && Input.GetKeyDown(KeyCode.Escape))
            HideNote();
    }

    public void ShowNote(int noteNumber)
    {
        HideActiveHint();
        activeNote = notes[noteNumber];
        activeNote.SetActive(true);
        playerMovement.enabled = false;
        mouseLook.enabled = false;
    }

    private void HideNote()
    {
        activeNote.SetActive(false);
        activeNote = null;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
    }

    public void HideActiveHint()
    {
        if (activeHint != null)
        {
            activeHint.SetActive(false);
            activeHint = null;
        }
    }

    public void ShowInteractHint()
    {
        if (activeHint != null || activeNote != null)
            return;

        HideActiveHint();
        activeHint = interactHint;
        activeHint.SetActive(true);
    }

    public void ShowDoorLockedHint()
    {
        HideActiveHint();
        activeHint = doorLockedHint;
        activeHint.SetActive(true);
    }

    public void ShowDoorKeyHint()
    {
        HideActiveHint();
        activeHint = doorKeyHint;
        activeHint.SetActive(true);
    }

    #endregion
}
