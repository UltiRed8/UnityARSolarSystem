using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] float soundsVolume;
    [SerializeField] float musicVolume;
    bool soundIsToggle = false;

    private void Start()
    {
        soundSource = gameObject.AddComponent<AudioSource>();
        soundSource.volume = soundsVolume;
        musicSource.volume = musicVolume;
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
        soundSource.volume = _overrideVolume == -1.0f ? soundsVolume : _overrideVolume;
        soundSource.resource = _source;
        soundSource.Play();
    }
}
