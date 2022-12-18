using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;

    public int previousSong;

    public void Start()
    {
        previousSong = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[previousSong], PlayerPrefs.GetFloat("MusicVolume", 0));
    }

    public void Update()
    {
        if (!audioSource.isPlaying)
        {
            print("THERE SHOULD ONLY BE ONE");
            int temp = Random.Range(0, clips.Length);
            if (temp != previousSong)
            {
                previousSong = temp;
                audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)], PlayerPrefs.GetFloat("MusicVolume", 0));
            }
        }
    }
}
