using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject panelToOpen;
    [SerializeField] List<GameObject> panelsToClose;
    [SerializeField] AudioResource soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Apply);
        button.onClick.AddListener(() => SoundManager.Instance.PlaySound(soundToPlay));
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
