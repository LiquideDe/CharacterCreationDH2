using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource clickSound, doneSound, cancelSound, warningSound;

    public void PlayClick()
    {
        //if(TryPlaySound())
            clickSound.Play();
    }

    public void PlayDone()
    {
        //if (TryPlaySound())
            doneSound.Play();
    }

    public void PlayCancel()
    {
        //if (TryPlaySound())
            cancelSound.Play();
    }

    public void PlayWarning()
    {
        //if (TryPlaySound())
            warningSound.Play();
    }

    private bool TryPlaySound()
    {
        if (clickSound.isPlaying || doneSound.isPlaying || cancelSound.isPlaying || warningSound.isPlaying)
            return false;

        return true;
    }
}
