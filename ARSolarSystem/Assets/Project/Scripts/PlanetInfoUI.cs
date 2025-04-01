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
    [SerializeField] InteractionBehaviour intract;

    public PlanetInfo PlanetInfo {  get { return planetInfo; } set { planetInfo = value; } }

    private void Start()
    {
        gameObject.SetActive(false);
        if (!intract) return;
        intract.interactedWithPlanet += UpdatePLanetInfoUI;
    }

    public void UpdatePLanetInfoUI(PlanetInfo _planetInfo = null)
    {
        if(!gameObject.activeInHierarchy)
            gameObject.SetActive(true);


        if (!_planetInfo)
        {
            if (!planetInfo) return;
            _planetInfo = planetInfo;
        }
        
        if (planetNameText)
        {
            planetNameText.text = _planetInfo.PlanetName;
        }
        if(planetSizeText)
        {
            planetSizeText.text = _planetInfo.PlanetSize.ToString() + " Km";
        }

        if (SunDistText)
        {
            SunDistText.text = _planetInfo.IsAMoon ? "Planet Dist:" : "Sun Dist:";
        }
        if (SunDistValueText)
        {
            SunDistValueText.text = _planetInfo.Distance.ToString() + " Km";
        }
    }
}

