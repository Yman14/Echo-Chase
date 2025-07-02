using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public static class InputUtility
{
    /// <summary>
    /// Returns true if the current input (mouse or touch) is over any UI element.
    /// </summary>
    public static bool IsPointerOverUI()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
#elif UNITY_IOS || UNITY_ANDROID
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            int touchId = Touchscreen.current.primaryTouch.touchId.ReadValue();
            return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(touchId);
        }
        return false;
#else
        return false;
#endif
    }
}
