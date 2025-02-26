using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    private Vector3 _offset;
    
    // Start is called once before the first frame update.
    void Start()
    {
        // Calculate the initial offset between the camera's position and the player's position.
        _offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position + _offset;
    }
}
