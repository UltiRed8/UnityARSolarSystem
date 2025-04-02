using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation; //AR Manager
using UnityEngine.XR.ARSubsystems; // trackables
using InputTouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class SelectPosSolarSystem : MonoBehaviour
{
    [SerializeField] ARPlaneManager planeManager;
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] GameObject solarSystem;
    [SerializeField] List<GameObject> allUIToActive;

    private bool IsValid => planeManager && raycastManager && solarSystem;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void Update()
    {
        if (!IsValid) return;

        if (TryGetTouchPosition(out Vector2 _touchPosition))
        {
            PlaceObject(_touchPosition);
        }
    }

    private bool TryGetTouchPosition(out Vector2 _touchPosition)
    {
        if (InputTouch.activeTouches.Count > 0 && InputTouch.activeTouches[0].began)
        {
            _touchPosition = InputTouch.activeTouches[0].screenPosition;
            return true;
        }

        _touchPosition = default;
        return false;
    }

    private void PlaceObject(Vector2 _touchPosition)
    {
        List<ARRaycastHit> _outResults = new List<ARRaycastHit>();
        if (raycastManager.Raycast(_touchPosition, _outResults, TrackableType.Planes))
        {
            Pose _pose = _outResults[0].pose; // Pose = equivalent du hitLocation sur unreal
            solarSystem.SetActive(true);
            solarSystem.transform.position = _pose.position;
            ActiveUI();
        }
    }

    void ActiveUI()
    {
        foreach (GameObject _ui in allUIToActive)
        {
            _ui.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
