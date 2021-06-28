using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : Singleton<HUD>
{
    #region Fields

    [SerializeField] private GameObject interactHint;
    [SerializeField] private GameObject doorKeyHint;
    [SerializeField] private GameObject doorLockedHint;
    private bool showInteractHint = false;
    private bool showDoorKeyHint = false;
    private bool showDoorLockedHint = false;

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
    }

    private void Update()
    {
        ShowHint();
    }

    public void HideAllHints()
    {
        showInteractHint = false;
        showDoorKeyHint = false;
        showDoorLockedHint = false;
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
