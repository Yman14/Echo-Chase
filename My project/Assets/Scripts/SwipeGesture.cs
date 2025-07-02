using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeGesture : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    public GameObject capsule;


    void Start()
    {
        
    }

    void Update()
    {
        if (Touchscreen.current == null)
            return;

        var touch = Touchscreen.current.primaryTouch;

        // Detect start of touch
        if (touch.press.wasPressedThisFrame)
        {
            startTouchPosition = touch.position.ReadValue();
        }

        // Detect end of touch and handle swipe
        if (touch.press.wasReleasedThisFrame)
        {
            endTouchPosition = touch.position.ReadValue();
            
            if(endTouchPosition.x < startTouchPosition.x)
            {
                Left();
            }

            if(endTouchPosition.x > startTouchPosition.x)
            {
                Right();
            }
            
        }
    }

    private void Left()
    {
        capsule.transform.position = new Vector3(capsule.transform.position.x -1, capsule.transform.position.y, capsule.transform.position.z);
    }
    private void Right()
    {
        capsule.transform.position = new Vector3(capsule.transform.position.x +1, capsule.transform.position.y, capsule.transform.position.z);
    }

}
