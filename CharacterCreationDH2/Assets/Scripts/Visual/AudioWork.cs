using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWork : MonoBehaviour
{
    [SerializeField] AudioSource clickSound, doneSound, cancelSound, warningSound;

    public void PlayClick()
    {
        if(!doneSound.isPlaying)
        clickSound.Play();
    }

    public void PlayDone()
    {
        doneSound.Play();
    }

    public void PlayCancel()
    {
        cancelSound.Play();
    }

    public void PlayWarning()
    {
        warningSound.Play();
    }

}
