using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ripplePrefab; // Prefab for the ripple effect
    public float moveSpeed = 5f; // Speed of movement

    private Vector2 moveDirection; // Movement direction vector
    private Camera mainCamera; // Reference to the main camera
    private Vector3 targetPosition; // Target position on the grid
    private bool isMoving = false; // Prevent overlapping moves
    private PathManager pathManager;

    //swipe gesture
    private Vector2 startTouchPosition, endTouchPosition;
    private float swipeThreshold = 50f; // Adjust as needed

    void Start()
    {
        pathManager = FindAnyObjectByType<PathManager>();
        mainCamera = Camera.main; // Cache the main camera
        targetPosition = transform.position; // Initialize the target position
    }

    void Update()
    {
        if (Touchscreen.current == null || isMoving)
            return;

        var touch = Touchscreen.current.primaryTouch;


        if (touch.press.wasPressedThisFrame)
            startTouchPosition = touch.position.ReadValue();

        if (touch.press.wasReleasedThisFrame)
        {
            endTouchPosition = touch.position.ReadValue();
            Vector2 swipeDelta = endTouchPosition - startTouchPosition;

            if (swipeDelta.magnitude > swipeThreshold)
            {
                Vector2 moveDir = Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y)
                    ? (swipeDelta.x > 0 ? Vector2.right : Vector2.left)
                    : (swipeDelta.y > 0 ? Vector2.up : Vector2.down);

                AttemptMove(moveDir);
            }
        }
    }

    private void AttemptMove(Vector2 direction)
    {
        Vector3 moveVector = new Vector3(direction.x, direction.y, 0);
        Vector3 newTarget = transform.position + moveVector;

        if (pathManager.IsPositionValid(newTarget))
        {
            targetPosition = newTarget;
            StartCoroutine(MoveToTarget());
        }
    }

    public void OnMove(InputValue value)
    {
        // Read move direction
        if (!isMoving) // Allow input only if not already moving
        {
            moveDirection = value.Get<Vector2>();

            // Determine the target position based on the move direction
            if (moveDirection != Vector2.zero)
            {
                Vector3 moveVector = new Vector3(moveDirection.x, moveDirection.y, 0);
                targetPosition = transform.position + moveVector;

                // Check if the new position is valid
                if (pathManager.IsPositionValid(targetPosition))
                {
                    StartCoroutine(MoveToTarget());
                }
            }
        }
    }


    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;
        //SFX
        AudioManager.instance.PlaySFX(AudioManager.instance.moveSFX);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // Smoothly move the player to the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition; // Snap to target position
        isMoving = false;
    }


    public void OnTap(InputValue value)
    {
        if (value.isPressed)
        {
            StartCoroutine(HandleTapDelayed());
        }
    }

    private System.Collections.IEnumerator HandleTapDelayed()
    {
        //error:Calling IsPointerOverGameObject() from within event processing (such as from InputAction callbacks) will 
        // not work as expected; it will query UI state from the last frame.
        //apparently, so i need to wait so Unity has time to update the pointer state
        yield return null; // wait one frame


        //Check if tap is over UI
        if (InputUtility.IsPointerOverUI())
            yield break;// Block tap if it's over a UI element


        Vector2 tapPosition = Pointer.current.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(tapPosition.x, tapPosition.y, mainCamera.nearClipPlane));

        //ripple effect when tapping the screen
        Instantiate(ripplePrefab, worldPosition, Quaternion.identity);
    }
}
