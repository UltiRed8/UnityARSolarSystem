using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehavior : MonoBehaviour
{
    [SerializeField] RawImage background;
    [SerializeField] RawImage foreground;
    [SerializeField] Slider slider;
    [SerializeField] float sliderValue;

    event Action onValueChanged;

    void Update()
    {
    }

    void UpdateValue(float _value)
    {
        sliderValue = _value;
        PlanetManager.Instance.SetTimeScale(sliderValue);
        onValueChanged?.Invoke();
    }

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateValue);
        onValueChanged += UpdateSlider;
    }

    void UpdateSlider()
    {
        float _sliderValue = sliderValue / slider.maxValue;
        background.uvRect = new Rect(new Vector2(0.0f, 0.0f),new Vector2(_sliderValue, 1.0f));
        background.rectTransform.anchorMax = new Vector2(_sliderValue, 1.0f);

        foreground.uvRect = new Rect(new Vector2(_sliderValue, 0.0f), new Vector2(1.0f - _sliderValue, 1.0f));
        foreground.rectTransform.anchorMin = new Vector2(_sliderValue, 0.0f);
    }
}
