using System;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using InputTouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InteractionBehaviour : MonoBehaviour
{
    public event Action<GameObject> interactedWithGameObject = null;
    public event Action<PlanetInfo> interactedWithPlanet = null;

    [SerializeField] Camera playerCamera = null;
    [SerializeField] InputSystem inputs = null;
    [SerializeField] LayerMask layerToDetect;

    public void SimulateClick(GameObject _object)
    {
        interactedWithGameObject?.Invoke(_object);
        PlanetInfo _info = _object.GetComponent<PlanetInfo>();
        interactedWithPlanet?.Invoke(_info);
    }

    private void Start()
    {
        if (inputs)
        {
            inputs.ClickedOnScreen += (ReadOnlyArray<InputTouch> _touches) => {
                if (_touches.Count == 1)
                    if (_touches[0].began)
                        Interact(_touches[0].screenPosition);
            };
        }
    }

    public void Interact(Vector2 _hitPosition)
    {
        Ray _ray = playerCamera.ScreenPointToRay(_hitPosition);
        if (Physics.Raycast(_ray, out RaycastHit _hit, 1000.0f, layerToDetect))
        {
            interactedWithGameObject?.Invoke(_hit.collider.gameObject);
            PlanetInfo _info = _hit.collider.gameObject.GetComponent<PlanetInfo>();
            interactedWithPlanet?.Invoke(_info);
        }
    }
}
