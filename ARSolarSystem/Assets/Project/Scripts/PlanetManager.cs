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
    event Action<float> onTimeScaleChanged;

    private void Start()
    {
        Invoke(nameof(Apply),0.0f);
    }

    void Apply()
    {
        GameObject _sun = GameObject.FindGameObjectWithTag("Sun");
        _sun.transform.localScale *= multiplier;
        foreach (PlanetBehavior _behavior in planetBehaviors)
        {
            _behavior.UpdateWithMultiplier(multiplier);
        }
    }

    public void SetTimeScale(float _sliderValue)
    {
        timeScale = ((_sliderValue - 0.5f) * maxTimeScale) * 2.0f;
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
