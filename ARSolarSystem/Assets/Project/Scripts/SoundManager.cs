using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource musicSource;
    bool soundIsToggle = false;

    private void Start()
    {
        soundSource = gameObject.AddComponent<AudioSource>();
    }


    public void SetSoundToggle(bool _value)
    {
        soundIsToggle = _value;
    }

    public void SetMusicIsToggle(bool _shouldPlay)
    {
        if(_shouldPlay)
            musicSource.Play();
        else musicSource.Stop();
    }

    public void PlaySound(AudioResource _source)
    {
        if (soundIsToggle) return;
        soundSource.resource = _source;
        soundSource.Play();
    }
}
