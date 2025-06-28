using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ripplePrefab; 

    public float moveSpeed = 5f;
    private Vector2 moveDirection;

    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    public void OnTap(InputValue value)
    {
        if (value.isPressed)
        {
            // Get the position of the tap
            //Vector2 tapPosition = Pointer.current.position.ReadValue();
            //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(tapPosition.x, tapPosition.y, 10));
            
            // Instantiate the ripple at the tap position
            Instantiate(ripplePrefab, transform.position, Quaternion.identity);
        }
    }


}
