using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[Serializable]
enum SoundType
{
    Sound,
    Music,
}

public class ToggleButton : MonoBehaviour
{
    [SerializeField] SoundType soundType;
    [SerializeField] Button button;
    [SerializeField] RawImage background;
    [SerializeField,HideInInspector] Color baseColor;
    [SerializeField] Color clickedColor;
    [SerializeField] bool clicked = false;
    [SerializeField] AudioResource soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonToggle);
        button.onClick.AddListener(() => SoundManager.Instance.PlaySound(soundToPlay));
        baseColor = background.color;
    }  

    void ButtonToggle()
    {
        clicked = !clicked;
        background.color = clicked ? clickedColor : baseColor;
        if (SoundType.Sound == soundType)
            ToggleSound();
        else ToggleMusic();
    }

    void ToggleSound()
    {
        SoundManager.Instance.SetSoundToggle(clicked);
    }

    void ToggleMusic()
    {
        SoundManager.Instance.SetMusicIsToggle(!clicked);
    }
}
