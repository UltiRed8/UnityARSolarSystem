using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] float globalVolume;
    bool soundIsToggle = false;

    private void Start()
    {
        soundSource = gameObject.AddComponent<AudioSource>();
        soundSource.volume = globalVolume;
        musicSource.volume = globalVolume;
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

    public void PlaySound(AudioResource _source, float _overrideVolume = -1.0f)
    {
        if (soundIsToggle) return;
        soundSource.volume = _overrideVolume == -1.0f ? globalVolume : _overrideVolume;
        soundSource.resource = _source;
        soundSource.Play();
    }
}
