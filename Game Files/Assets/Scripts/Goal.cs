using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes

/// <summary>
/// Handles the goal behavior and scene transition.
/// </summary>
public class Goal : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the Completion Text UI.")]
    private TMPro.TextMeshProUGUI completionText;

    private SpriteRenderer spriteRenderer; // For changing goal color
    private bool isActive = false; // Tracks whether the goal is activated

    private void Start()
    {
        // Assign sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is missing on the Goal object!");
        }

        // Ensure completion text is hidden at the start
        if (completionText != null)
        {
            completionText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("CompletionText is not assigned in the Inspector!");
        }
    }

    private void Update()
    {
        // Check if all fragments are collected
        if (!isActive && GameObject.FindGameObjectsWithTag("MemoryFragment").Length == 0)
        {
            ActivateGoal();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When the player touches the goal and it's active, load the next scene
        if (other.CompareTag("Player") && isActive)
        {
            SceneManager.LoadScene("LevelCompleteScene"); // Load the Level Complete scene
        }
    }

    private void ActivateGoal()
    {
        isActive = true; // Mark goal as active
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.green; // Change color to green
        }
    }
}
