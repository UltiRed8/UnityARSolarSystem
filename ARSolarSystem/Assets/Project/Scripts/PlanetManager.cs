using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : Singleton<PlanetManager>
{
    [SerializeField] List<PlanetBehavior> planetBehaviors;
    [SerializeField] float multiplier = 1f;
    event Action<float> onTimeScaleChanged;
    float timeScale = 1f;

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

    public float TimeScale {
        get
        {
            return timeScale;
        }

        set 
        { 
            timeScale = value;
            onTimeScaleChanged?.Invoke(timeScale);
        }
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
