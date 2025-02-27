using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Speed at which the player moves.
    public float speed;
    
    // Rigidbody of the player.
    private Rigidbody _rb;
    // Movement along X and Y axes.
    private float _movementX;
    private float _movementY;
    
    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        _rb = GetComponent<Rigidbody>();
    }
    
    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        // Store the X and Y components of the movement.
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }
    
    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        // Apply force to the Rigidbody to move the player.
        _rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
        }
        
    }
}
