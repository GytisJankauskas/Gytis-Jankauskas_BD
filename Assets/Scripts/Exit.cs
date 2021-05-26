using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    bool doubleTap =false;

    public void OnClickExit()
    {
        StartCoroutine(exit());
    }

    IEnumerator exit()
    {
        if (doubleTap == true) // double tap to exit
        {
            Debug.LogWarning("exit by user");
            Application.Quit();
            doubleTap = false;
        }
        else
        {
            doubleTap = true;
        }
        yield return new WaitForSeconds(0.5f);
        doubleTap = false;


    }
}
