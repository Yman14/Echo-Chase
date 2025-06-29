using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ripplePrefab; // Prefab for the ripple effect
    public float moveSpeed = 5f; // Speed of movement

    private Vector2 moveDirection; // Movement direction vector
    private Camera mainCamera; // Reference to the main camera

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera for position calculations
    }

    // Called when movement input is detected
    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    // Called every frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Move the player based on input direction
        if (moveDirection != Vector2.zero)
        {
            Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);

            // Ensure the player stays on the visible path (optional logic for path boundaries)
            ClampPositionToPath();
        }
    }

    private void ClampPositionToPath()
    {
        // Example: Clamp the player's position within a predefined area
        float minX = -5f, maxX = 5f; // Adjust based on your level design
        float minY = 0f, maxY = 10f;
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );
        transform.position = clampedPosition;
    }

    // Called when a tap is detected
    public void OnTap(InputValue value)
    {
        if (value.isPressed)
        {
            // Get the tap position from the screen
            Vector2 tapPosition = Pointer.current.position.ReadValue();

            // Convert the screen tap position to world position
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(tapPosition.x, tapPosition.y, mainCamera.nearClipPlane));

            // Instantiate the ripple effect at the tap position
            Instantiate(ripplePrefab, worldPosition, Quaternion.identity);
        }
    }
}
