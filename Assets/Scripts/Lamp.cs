using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    #region Fields

    private Light[] lights;

    #endregion

    #region Methods

    private void Awake()
    {
        lights = GetComponentsInChildren<Light>();
    }

    private void Switch()
    {
        foreach (Light light in lights)
        {
            if (light.enabled)
                light.enabled = false;
            else
                light.enabled = true;
        }
    }

    public void Interact()
    {
        Switch();
    }

    #endregion
}
