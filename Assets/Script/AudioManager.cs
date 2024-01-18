using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    bool canmusic = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && canmusic == true)
        {
            PlayLoop();
        }
    }

    public void PlayLoop()
    {
        canmusic = true;
        audioSource.clip = playlist[1];
        audioSource.Play();
    }
    public void StopSong()
    {
        canmusic = false;
        audioSource.Stop();
    }

    public void RestartSong()
    {
        canmusic = true;
        audioSource.clip = playlist[0];
        audioSource.Play();
    }
}
