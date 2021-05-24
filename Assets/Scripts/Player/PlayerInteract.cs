using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Fields

    [SerializeField] private LayerMask objToHit;
    private RaycastHit hit;
    private HUD hud;

    #endregion

    #region Methods

    private void Awake()
    {
        hud = FindObjectOfType<HUD>();
    }

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 2.5f, Color.yellow);

        DetectInteractableObject();
    }

    private void DetectInteractableObject()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2.5f))
        {
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                hud.ShowInteractHint = true;
                if (Input.GetMouseButtonDown(0))
                    interactable.Interact();
            }
            else
            {
                hud.ShowInteractHint = false;
            }
        }
        else
        {
            hud.ShowInteractHint = false;
        }
    }

    #endregion
}
