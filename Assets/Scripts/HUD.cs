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
    private bool showInteractHint = false;
    private bool showDoorKeyHint = false;
    private bool showDoorLockedHint = false;

    PlayerMovement playerMovement;
    MouseLook mouseLook;

    #endregion

    #region Properties

    public bool ShowInteractHint
    {
        get { return showInteractHint; }
        set { showInteractHint = value; }
    }
    public bool ShowDoorKeyHint
    {
        get { return showDoorKeyHint; }
        set { showDoorKeyHint = value; }
    }
    public bool ShowDoorLockedHint
    {
        get { return showDoorLockedHint; }
        set { showDoorLockedHint = value; }
    }

    #endregion

    #region Methods

    private void Awake()
    {
        interactHint.SetActive(false);
        playerMovement = FindObjectOfType<PlayerMovement>();
        mouseLook = FindObjectOfType<MouseLook>();
    }

    private void Update()
    {
        ShowHint();
        if (Input.GetKeyDown(KeyCode.Escape))
            HideNote();
    }

    public void ShowNote(int noteNumber)
    {
        notes[noteNumber].SetActive(true);
        playerMovement.enabled = false;
        mouseLook.enabled = false;
    }

    public void HideAllHints()
    {
        playerMovement.enabled = true;
        mouseLook.enabled = true;

        showInteractHint = false;
        showDoorKeyHint = false;
        showDoorLockedHint = false;
    }

    private void HideNote()
    {
        foreach (GameObject note in notes)
        {
            if (note.activeSelf)
                note.SetActive(false);
        }
    }

    private void ShowHint()
    {
        if (showInteractHint && !showDoorKeyHint && !showDoorLockedHint)
            interactHint.SetActive(true);
        else
            interactHint.SetActive(false);

        if (showDoorKeyHint)
            doorKeyHint.SetActive(true);
        else
            doorKeyHint.SetActive(false);

        if (showDoorLockedHint)
            doorLockedHint.SetActive(true);
        else
            doorLockedHint.SetActive(false);

    }

    #endregion
}
