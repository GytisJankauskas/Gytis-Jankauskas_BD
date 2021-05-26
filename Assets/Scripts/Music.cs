using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] ost;

    AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Debug.Log(audioSrc.isPlaying);
        if (audioSrc.clip == null)
        {
            audioSrc.Stop();
        }
        if (audioSrc.isPlaying == false)//play ost if not playing
        {
            audioSrc.clip = ost[Random.Range(0, 3)];
            audioSrc.Play();
        }
    }
    void OnLevelWasLoaded()
    {
        Debug.Log(audioSrc.isPlaying);
        if (audioSrc.clip == null)
        {
            audioSrc.Stop();
        }
        if (audioSrc.isPlaying == false)//play ost if not playing
        {
            audioSrc.clip = ost[Random.Range(0, 3)];
            audioSrc.Play();
        }
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log(audioSrc.isPlaying);
        if (audioSrc.isPlaying == false)//play ost if not playing
        {
            audioSrc.clip = ost[Random.Range(0, 3)];
            audioSrc.Play();
            
        }
    }
}
