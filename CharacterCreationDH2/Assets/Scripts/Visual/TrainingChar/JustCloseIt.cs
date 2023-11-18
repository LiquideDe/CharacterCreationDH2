using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustCloseIt : MonoBehaviour
{
    public void CloseIt()
    {
        gameObject.SetActive(false);
    }
}
