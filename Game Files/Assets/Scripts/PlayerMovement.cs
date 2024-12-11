using UnityEngine;

/// <summary>
/// Handles player movement in a 2D environment.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Movement speed of the player.")]
    private float moveSpeed = 5f; // Default speed

    private void Update()
    {
        // Get input for horizontal and vertical movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Apply movement to the player's position
        transform.Translate(movement);
    }
}
