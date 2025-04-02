using System;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using InputTouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    public event Action OnPlayerMovedForward = null;

    [SerializeField] private Transform target = null;
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private Vector3 positionOffset = Vector3.zero;
    [SerializeField] private InteractionBehaviour interaction = null;
    [SerializeField] private InputSystem inputs = null;
    [SerializeField] private bool goingToTarget = false;
    [SerializeField] private Transform forwardTransform = null;
    [SerializeField] private PlanetInfoUI infoUI = null;

    private void Start()
    {
        interaction.interactedWithGameObject += (GameObject _object) => SetTarget(_object.transform);
        if (inputs)
        {
            inputs.ClickedOnScreen += (ReadOnlyArray<InputTouch> _touches) => {
                if (_touches.Count == 2)
                    MoveForward();
                else if (_touches.Count == 3)
                    Recenter();
            };
        }
        if (infoUI)
            infoUI.OnUIClosed += StopFollowing;
    }

    public void Recenter()
    {

    }

    public void SetTarget(Transform _newTarget)
    {
        target = _newTarget;
        goingToTarget = true;
    }

    private void Update()
    {
        if (!goingToTarget)
            return;
        Vector3 _newPosition = Vector3.MoveTowards(transform.position, target.position + positionOffset, Time.deltaTime * movementSpeed);
        transform.position = _newPosition;
    }

    private void StopFollowing()
    {
        goingToTarget = false;
    }

    private void MoveForward()
    {
        Vector3 _newPosition = transform.position + forwardTransform.forward * Time.deltaTime * movementSpeed;
        transform.position = _newPosition;
        OnPlayerMovedForward?.Invoke();
    }
}
