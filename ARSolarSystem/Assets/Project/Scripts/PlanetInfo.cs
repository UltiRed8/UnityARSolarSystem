using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    [SerializeField] string planetName = "Earth";
    [SerializeField] float planetSize = 6378.0f; // KM
    [SerializeField] float sunDistance = 149597870.7f; // KM
    [SerializeField] bool isAMoon = false;

    public string PlanetName => planetName;
    public float PlanetSize => planetSize;
    public float SunDistance => sunDistance;
    public bool IsAMoon => isAMoon;
}
