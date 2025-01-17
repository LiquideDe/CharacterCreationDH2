using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource clickSound, doneSound, cancelSound, warningSound, popUpSound, popDownSound;

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

    public void PlayPopUp()
    {
        popUpSound.Play();
    }

    public void PlayPopDown()
    {
        popDownSound.Play();
    }

}
