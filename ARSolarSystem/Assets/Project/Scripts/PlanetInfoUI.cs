using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI planetNameText;
    [SerializeField] TextMeshProUGUI planetSizeText;
    [SerializeField] TextMeshProUGUI SunDistValueText;
    [SerializeField] TextMeshProUGUI SunDistText;
    [SerializeField] PlanetInfo planetInfo;

    public PlanetInfo PlanetInfo {  get { return planetInfo; } set { planetInfo = value; } }
    
    public void UpdatePLanetInfoUI(PlanetInfo _planetInfo = null)
    {
        if (!_planetInfo)
        {
            if (!planetInfo) return;
            _planetInfo = planetInfo;
        }
        
        if (planetNameText)
        {
            planetNameText.text = PlanetInfo.PlanetName;
        }
        if(planetSizeText)
        {
            planetSizeText.text = PlanetInfo.PlanetSize.ToString() + " Km";
        }

        if (SunDistText)
        {
            SunDistText.text = PlanetInfo.IsAMoon ? "Planet Dist:" : "Sun Dist:";
        }
        if (SunDistValueText)
        {
            SunDistValueText.text = PlanetInfo.SunDistance.ToString() + " Km";
        }
    }
}

