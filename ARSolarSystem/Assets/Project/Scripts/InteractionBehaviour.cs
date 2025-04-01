using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionBehaviour : MonoBehaviour
{
    public event Action<GameObject> interactedWithGameObject = null;
    public event Action<PlanetInfo> interactedWithPlanet = null;

    [SerializeField] Camera playerCamera = null;
    [SerializeField] IAA_Player inputs;
    [SerializeField] InputAction interactAction;
    [SerializeField] LayerMask layerToDetect;

    private void Awake()
    {
        inputs = new IAA_Player();
        interactAction = inputs.Player.Interact;
        interactAction.Enable();
        interactAction.performed += Interact;
    }

    public void Interact(InputAction.CallbackContext _context)
    {
        Vector2 _hitPosition = _context.ReadValue<Vector2>();
        Ray _ray = playerCamera.ScreenPointToRay(_hitPosition);
        if (Physics.Raycast(_ray, out RaycastHit _hit, 1000.0f, layerToDetect))
        {
            Debug.Log("AAAAAA");
            //_hit.collider.gameObject.SetActive(false);
            interactedWithGameObject?.Invoke(_hit.collider.gameObject);
            PlanetInfo _info = _hit.collider.gameObject.GetComponent<PlanetInfo>();
            interactedWithPlanet?.Invoke(_info);
        }
    }
}
