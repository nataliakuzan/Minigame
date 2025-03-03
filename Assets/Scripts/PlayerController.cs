using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // Speed at which the player moves.
    [SerializeField] private float speed;
    // UI text component to display count of "PickUp" objects collected.
    [SerializeField] private TextMeshProUGUI countText;
    // UI object to display winning text.
    [SerializeField] private GameObject winTextObject;
    // Amount of "PickUp" objects in the scene.
    [SerializeField] private int collectiblesCount;
    
    // Rigidbody of the player.
    private Rigidbody _rb;
    // Variable to keep track of collected "PickUp" objects.
    private int _count;
    // Movement along X and Y axes.
    private float _movementX;
    private float _movementY;
    
    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        _rb = GetComponent<Rigidbody>();
        
        // Initialize count to zero.
        _count = 0;
        
        // Update the count display.
        SetCountText();
        
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
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

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Update the count text with the current count.
        countText.text = "Score: " + _count.ToString();
        
        // Check if the count has reached or exceeded the win condition.
        if (_count >= collectiblesCount)
        {
            // Display the win text.
            winTextObject.SetActive(true);
            winTextObject.gameObject.GetComponent<TextMeshProUGUI>().text = "YOU WIN!";
            winTextObject.gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
            
            // Destroy enemy
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    
    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        // Apply force to the Rigidbody to move the player.
        _rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            
            // Set the text to "You lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.gameObject.GetComponent<TextMeshProUGUI>().text = "YOU LOSE!";
            winTextObject.gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            
            // Increment the count of "PickUp" objects collected.
            _count++;
            
            // Update the count display.
            SetCountText();
        }
        
    }
}
