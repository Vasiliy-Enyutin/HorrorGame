using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    #region Fields

    [SerializeField] private int noteNumber;

    #endregion

    #region Methods

    public void Interact()
    {
        HUD.Instance.ShowNote(noteNumber);
    }

    #endregion
}
