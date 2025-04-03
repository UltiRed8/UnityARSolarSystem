using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoUI : MonoBehaviour
{
    public event Action OnUIClosed = null;

    [SerializeField] TextMeshProUGUI planetNameText;
    [SerializeField] TextMeshProUGUI planetSizeText;
    [SerializeField] TextMeshProUGUI SunDistValueText;
    [SerializeField] TextMeshProUGUI SunDistText;
    [SerializeField] PlanetInfo planetInfo;
    [SerializeField] InteractionBehaviour intract;
    [SerializeField] Button removeButton;
    [SerializeField] PlanetSelectorBehavior planetSelector = null;

    public PlanetInfo PlanetInfo {  get { return planetInfo; } set { planetInfo = value; } }

    private void OnEnable()
    {
        if (planetSelector)
            planetSelector.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (planetSelector)
            planetSelector.gameObject.SetActive(true);
    }

    private void Start()
    {
        gameObject.SetActive(false);
        if (intract)
            intract.interactedWithPlanet += UpdatePLanetInfoUI;
        if (removeButton)
            removeButton.onClick.AddListener(RemoveUI);
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

    void RemoveUI()
    {
        OnUIClosed?.Invoke();
        gameObject.SetActive(false);
    }
}

