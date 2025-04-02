using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Utilities;
using InputTouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputSystem : MonoBehaviour
{
    public event Action<ReadOnlyArray<InputTouch>> ClickedOnScreen = null;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        if (InputTouch.activeTouches.Count > 0)
            ClickedOnScreen?.Invoke(InputTouch.activeTouches);
    }
}
