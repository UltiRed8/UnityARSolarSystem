using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject panelToOpen;
    [SerializeField] List<GameObject> panelsToClose;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Apply);
    }

    void Apply()
    {
        Debug.Log("Apply");
        foreach (GameObject _panel in panelsToClose)
        {
            _panel.SetActive(false);
        }
        if(panelToOpen)
            panelToOpen.SetActive(true);
    }
}
