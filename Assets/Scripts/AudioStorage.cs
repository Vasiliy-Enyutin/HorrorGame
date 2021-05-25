using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStorage : Singleton<AudioStorage>
{
    #region Fields

    [SerializeField] private AudioClip sfx_PlayerWalk;
    [SerializeField] private AudioClip sfx_LampSwitch;

    #endregion

    #region Properties

    public AudioClip SFX_PlayerWalk => sfx_PlayerWalk;
    public AudioClip SFX_LampSwitch => sfx_LampSwitch;

    #endregion
}
