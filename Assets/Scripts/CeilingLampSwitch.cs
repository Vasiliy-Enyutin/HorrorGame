using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLampSwitch : MonoBehaviour, IInteractable
{
    #region Fields

    [SerializeField] private Light[] lightsToSwitch;
    private AudioSource audioSource;

    #endregion

    #region Methods

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        Switch();
    }

    private void Switch()
    {
        LampSwitchAudioEffect();
        foreach (Light light in lightsToSwitch)
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
