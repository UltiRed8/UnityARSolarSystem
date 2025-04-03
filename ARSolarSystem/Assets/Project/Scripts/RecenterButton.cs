using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecenterButton : MonoBehaviour
{
    [SerializeField] Button button = null;
    [SerializeField] PlayerMovement movement = null;

    private void Start()
    {
        if (!button)
            return;
        if (!movement)
            return;
        button.onClick.AddListener(() => { movement.Recenter(); });
    }
}
