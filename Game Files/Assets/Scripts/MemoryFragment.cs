using UnityEngine;

/// <summary>
/// Represents a collectible memory fragment.
/// Tracks collection and updates the UI.
/// </summary>
public class MemoryFragment : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the Progress Text UI.")]
    private TMPro.TextMeshProUGUI progressText;

    private static int collectedFragments = 0; // Tracks collected fragments
    private static int totalFragments; // Total fragments in the scene

    private void Start()
    {
        if (progressText == null)
        {
            Debug.LogError("ProgressText is not assigned in the Inspector!");
        }

        // Count total fragments on scene load
        totalFragments = GameObject.FindGameObjectsWithTag("MemoryFragment").Length;

        // Update UI at the start
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectedFragments++; // Increment collected count
            UpdateUI(); // Refresh progress UI
            Destroy(gameObject); // Destroy fragment object
        }
    }

    private void UpdateUI()
    {
        // Update the progress text
        if (progressText != null)
        {
            progressText.text = $"Fragments Collected: {collectedFragments}/{totalFragments}";
        }
    }
}
