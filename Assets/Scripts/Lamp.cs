using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    #region Fields

    private Light[] lights;
    private AudioSource audioSource;

    #endregion

    #region Methods

    private void Awake()
    {
        lights = GetComponentsInChildren<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        Switch();
    }

    private void Switch()
    {
        LampSwitchAudioEffect();
        foreach (Light light in lights)
        {
            if (light.enabled)
                light.enabled = false;
            else
                light.enabled = true;
        }
    }

    private void LampSwitchAudioEffect()
    {
        audioSource.PlayOneShot(AudioStorage.Instance.SFX_LampSwitch);
    }
    #endregion
}
