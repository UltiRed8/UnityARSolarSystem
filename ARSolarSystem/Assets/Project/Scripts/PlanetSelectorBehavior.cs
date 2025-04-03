using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class PlanetSelectorBehavior : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown = null;
    [SerializeField] List<GameObject> gameObjectsToSelect = new List<GameObject>();
    [SerializeField] InteractionBehaviour interaction = null;
    [SerializeField] PlayerMovement movement = null;
    [SerializeField] AudioResource buttonClickSound = null;

    private void Start()
    {
        if (dropdown)
            dropdown.onValueChanged.AddListener(SelectionChanged);
    }

    private void SelectionChanged(int _index)
    {
        SoundManager.Instance.PlaySound(buttonClickSound);
        if (gameObjectsToSelect.Count < _index)
            return;
        if (!interaction)
            return;
        if (_index == 0) movement.SetTarget(null);
        else interaction.SimulateClick(gameObjectsToSelect[_index]);
        dropdown.SetValueWithoutNotify(0);
    }
}
