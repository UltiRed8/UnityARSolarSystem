using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : Singleton<PlanetManager>
{
    [SerializeField] List<PlanetBehavior> planetBehaviors;
    [SerializeField] float multiplier = 1f;
    [SerializeField] float maxTimeScale = 10f;
    [SerializeField] float timeScale = 1f;
    [SerializeField] SelectPosSolarSystem placeSolarSystem = null;
    event Action<float> onTimeScaleChanged;

    private void Start()
    {
        if (placeSolarSystem)
            placeSolarSystem.OnPlaceSolarSystem += () =>
            {
                Invoke(nameof(Apply), 0.0f);
                Invoke(nameof(InitSpeed), 0.0f);
            };
    }

    private void InitSpeed()
    {
        SetTimeScale(20);
    }

    void Apply()
    {
        GameObject _sun = GameObject.FindGameObjectWithTag("Sun");
        if (!_sun) return;
        _sun.transform.localScale *= multiplier;
        foreach (PlanetBehavior _behavior in planetBehaviors)
        {
            _behavior.UpdateWithMultiplier(multiplier);
        }
    }

    public void SetTimeScale(float _sliderValue)
    {
        timeScale = (((_sliderValue - 20.0f) / 40.0f) * maxTimeScale) * 2.0f;
        onTimeScaleChanged?.Invoke(timeScale);
    }
    

    public void Add(PlanetBehavior _behavior)
    {
        if(!planetBehaviors.Contains(_behavior))
        {
            planetBehaviors.Add(_behavior);
            onTimeScaleChanged += _behavior.SetTimeScale;
        }
    }

    public void Remove(PlanetBehavior _behavior)
    {
        if(planetBehaviors.Contains(_behavior))
        {
            onTimeScaleChanged -= _behavior.SetTimeScale;
            planetBehaviors.Remove(_behavior);
        }
    }
}
