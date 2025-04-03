using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetSelectorBehavior : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown = null;
    [SerializeField] List<GameObject> gameObjectsToSelect = new List<GameObject>();
    [SerializeField] InteractionBehaviour interaction = null;
    [SerializeField] PlayerMovement movement = null;

    private void Start()
    {
        if (dropdown)
            dropdown.onValueChanged.AddListener(SelectionChanged);
    }

    private void SelectionChanged(int _index)
    {
        if (gameObjectsToSelect.Count < _index)
            return;
        if (!interaction)
            return;
        if (_index == 0) movement.SetTarget(null);
        else interaction.SimulateClick(gameObjectsToSelect[_index]);
        dropdown.SetValueWithoutNotify(0);
    }
}
