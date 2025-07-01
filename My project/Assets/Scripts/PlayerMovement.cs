using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ripplePrefab; // Prefab for the ripple effect
    public float moveSpeed = 5f; // Speed of movement

    private Vector2 moveDirection; // Movement direction vector
    private Camera mainCamera; // Reference to the main camera
    private Vector3 targetPosition; // Target position on the grid
    private bool isMoving = false; // Prevent overlapping moves
    private PathManager pathManager;

    void Start()
    {
        pathManager = FindAnyObjectByType<PathManager>();
        mainCamera = Camera.main; // Cache the main camera
        targetPosition = transform.position; // Initialize the target position
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

    private bool IsPositionValid(Vector3 position)
    {
        // Check if the position is within the path boundaries
        // Adjust the boundaries dynamically based on your level design
        float minX = -5f, maxX = 5f;
        float minY = 0f, maxY = 10f;

        return position.x >= minX && position.x <= maxX &&
               position.y >= minY && position.y <= maxY;
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;

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
            Vector2 tapPosition = Pointer.current.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(tapPosition.x, tapPosition.y, mainCamera.nearClipPlane));

            Instantiate(ripplePrefab, worldPosition, Quaternion.identity);
        }
    }
}
