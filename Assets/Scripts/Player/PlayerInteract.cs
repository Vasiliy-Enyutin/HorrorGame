using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Fields

    [SerializeField] private LayerMask objToHit;
    private RaycastHit hit;

    #endregion

    #region Methods

    private void Awake()
    {
    }

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 2f, Color.yellow);

        DetectInteractableObject();
    }

    private void DetectInteractableObject()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2.5f))
        {
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                HUD.Instance.ShowInteractHint();
                if (Input.GetMouseButtonDown(0))
                    interactable.Interact();
            }
            else
            {
                HUD.Instance.HideActiveHint();
            }
        }
        else
        {
            HUD.Instance.HideActiveHint();
        }
    }

    #endregion
}
