using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject interactHint;
    private bool showInteractHint = false;

    #endregion

    #region Properties

    public bool ShowInteractHint
    {
        get { return showInteractHint; }
        set { showInteractHint = value; }
    }

    #endregion

    #region Methods

    private void Awake()
    {
        interactHint.SetActive(false);
    }

    private void Update()
    {
        InteractHint();
    }

    private void InteractHint()
    {
        if (showInteractHint)
            interactHint.SetActive(true);
        else
            interactHint.SetActive(false);
    }

    #endregion
}
