using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoUI : MonoBehaviour
{
    [SerializeField] List<string> tutoList = new List<string>();
    [SerializeField] TextMeshProUGUI textTuto;
    [SerializeField] InteractionBehaviour interact;
    [SerializeField] PlayerMovement move;
    [SerializeField] int timeTuto;
    //[SerializeField] int currentTuto = 0;

    private void Start()
    {
        Invoke("FirstTuto", timeTuto+5);
    }

    public void ChangeText(string _text)
    {
        if (!textTuto) return;
        textTuto.text = _text;
        textTuto.gameObject.SetActive(true);
    }

    void HideTuto()
    {
        textTuto.gameObject.SetActive(false);
    }

    void FirstTuto()
    {
        ChangeText(tutoList[0]);
        interact.interactedWithPlanet += SwitchFirstTuto;
    }

    void SwitchFirstTuto(PlanetInfo _info)
    {
        HideTuto();
        Invoke("SecondTuto", timeTuto);
        interact.interactedWithPlanet -= SwitchFirstTuto;
    }

    void SecondTuto()
    {
        ChangeText(tutoList[1]);
        move.OnPlayerMovedForward += SwitchSecondTuto;
    }

    void SwitchSecondTuto()
    {
        HideTuto();
        Invoke("SecondTuto", timeTuto);
        move.OnPlayerMovedForward -= SwitchSecondTuto;

    }
}
