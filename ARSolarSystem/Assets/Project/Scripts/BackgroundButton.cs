using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButton : MonoBehaviour
{
    [SerializeField] Button skybox;
    [SerializeField] Button darkIRL;
    [SerializeField] Button baseIRL;

    [SerializeField] RawImage skyboxImage;
    [SerializeField] RawImage darkIRLImage;
    [SerializeField] RawImage baseIRLImage;

    [SerializeField] GameObject darkIRLBackground;
    [SerializeField] GameObject skyboxBackground;

    [SerializeField] int currentButton = 2;

    void Start()
    {
        SetColors();
        skybox.onClick.AddListener(() => SetIndex(1));
        darkIRL.onClick.AddListener(() => SetIndex(2));
        baseIRL.onClick.AddListener(() => SetIndex(3));
    }

    void SetIndex(int _index)
    {
        currentButton = _index;
        SetColors();
        SetBackground();
    }

    void SetColors()
    {
        Color _skyboxColor = currentButton == 1 ? Color.green : Color.red;
        Color _darkIRLColor = currentButton == 2 ? Color.green : Color.red;
        Color _baseIRLColor = currentButton == 3 ? Color.green : Color.red;

        skyboxImage.color = _skyboxColor;
        darkIRLImage.color = _darkIRLColor;
        baseIRLImage.color = _baseIRLColor;
    }

    void SetBackground()
    {
        switch (currentButton)
        {
            case 1:
                SetSkybox();
                break;
            case 2:
                SetDarkIRl();
                break;
            case 3:
                SetBaseIRl();
                break;
            default:
                break;
        }
    }

    void SetSkybox()
    {
        darkIRLBackground.SetActive(false);
        skyboxBackground.SetActive(true);
    }

    void SetDarkIRl()
    {
        darkIRLBackground.SetActive(true);
        skyboxBackground.SetActive(false);
    }

    void SetBaseIRl()
    {
        darkIRLBackground.SetActive(false);
        skyboxBackground.SetActive(false);
    }
}
