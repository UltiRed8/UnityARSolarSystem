using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    [SerializeField] string planetName = "Earth";
    [SerializeField] float planetSize = 6378.0f; // KM
    [SerializeField] float distance = 149597870.7f; // KM // SunDistance if is a planet, Planet Distance if is a moon
    [SerializeField] bool isAMoon = false;

    public string PlanetName => planetName;
    public float PlanetSize => planetSize;
    public float Distance => distance;
    public bool IsAMoon => isAMoon;
}
